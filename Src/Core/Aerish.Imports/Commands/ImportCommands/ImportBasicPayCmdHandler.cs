using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Aerish.Application.Common.Entities.Staging;
using Aerish.Commands.Imports;
using Aerish.Domain.Entities.Staging;
using Aerish.Domain.Models;
using Aerish.Domain.Models.Imports;
using Aerish.Imports.Common.Base;
using Aerish.Interfaces;
using Aerish.Application;

using AutoMapper;

using FluentValidation;
using AutoMapper.QueryableExtensions;
using Aerish.Domain.Entities.Parameters;

namespace Aerish.Imports.Commands.ImportCommands
{
    public class ImportBasicPayCmdHandler : BaseImportHandler<ImportBasicPayCmd, StagingBasicPayBO, StagingBasicPayBO>
    {
        private readonly IMapper p_Mapper;
        private readonly Dictionary<int, IEnumerable<ValidationFailureBO>> errorsPerRow = new Dictionary<int, IEnumerable<ValidationFailureBO>>();

        


        public ImportBasicPayCmdHandler(IAerishDbContext dbContext, IAppSession appSession, IMapper mapper) 
            : base(dbContext, appSession)
        {
            p_Mapper = mapper;
        }

        public override void Initialize(ImportBasicPayCmd request)
        {
            base.Initialize(request);

            // master process will save the context once the handler process is completed
            ProcessTracker.SaveContext = true;
        }

        public override StagingBasicPayBO Run(StagingBasicPayBO key, ImportBasicPayCmd request)
        {
            bool hasError = false;

            if (errorsPerRow.ContainsKey(key.RowIndex))
            {
                hasError = true;
                key.ValidationFailures = errorsPerRow[key.RowIndex];
            }

            if (!hasError)
            {
                var newBasicPay = new BasicPay
                {
                    Amount = key.Amount,
                    ClientID = AppSession.ClientID,
                    EmployeeID = EmployeeIDs[key.EmployeeSysID],
                    AmountBasis = GetAmountBasis(key.Basis),
                    Effectivity = CommonUtility.DateTimeUtility.ParseDateTime(key.Effectivity),
                    PeriodStartID = GetPeriodID(key.PeriodStart).GetValueOrDefault(),
                    PeriodEndID = GetPeriodID(key.PeriodEnd)
                };

                DbContext.BasicPays.Add(newBasicPay);
            }

            return key;
        }

        public virtual AmountBasis GetAmountBasis(string value)
        {
            if (value == "M")
            {
                return AmountBasis.Monthly;
            }

            return AmountBasis.Monthly;
        }

        public virtual short? GetPeriodID(string periodData)
        {
            return 6;
        }

        public override IEnumerable SelectionCriteria(ImportBasicPayCmd request)
        {
            if (ProcessTracker.Aborted == true)
            {
                return new List<StagingBasicPayBO>();
            }

            return DbContext.StagingBasicPays
                .Where(a => a.ProcessInstanceID == ProcessTracker.ProcessInstanceID)
                .ProjectTo<StagingBasicPayBO>(p_Mapper.ConfigurationProvider)
                .OrderBy(a => a.RowIndex)
                .ToList();
        }

        protected override BaseCsvMapping<StagingBasicPayBO> GetMapping()
        {
            return new BaseCsvMapping<StagingBasicPayBO>()
                .MapProperty(0, x => x.EmployeeSysID)
                .MapProperty(1, x => x.PeriodStart)
                .MapProperty(2, x => x.PeriodEnd)
                .MapProperty(3, x => x.Amount)
                .MapProperty(4, x => x.Basis)
                .MapProperty(5, x => x.Effectivity);
        }

        protected override BaseValidator<StagingBasicPayBO> GetValidator()
        {
            var validator = new BaseValidator<StagingBasicPayBO>();

            validator.RuleFor(a => a.EmployeeSysID)
                    .NotEmpty().WithMessage("EmployeeSysID is required")
                    .MaximumLength(50).WithMessage("Has maxlength");

            return validator;
        }

        protected override bool Validate(StagingBasicPayBO entry, int rowIndex, ref List<ValidationFailureBO> validationFailures)
        {
            bool isValid = base.Validate(entry, rowIndex, ref validationFailures);

             

            if (!string.IsNullOrWhiteSpace(entry.EmployeeSysID)
                && !EmployeeIDs.ContainsKey(entry.EmployeeSysID))
            {
                isValid = false;

                validationFailures.Add(new ValidationFailureBO
                {
                    RowIndex = rowIndex,
                    PropertyName = nameof(StagingBasicPayBO.EmployeeSysID),
                    ProcessInstanceID = ProcessTracker.ProcessInstanceID,
                    ErrorMessage = "EmployeeSysID not found in DB"
                });
            }

            return isValid;
        }

        protected override void StageData(ImportBasicPayCmd request)
        {
            // read the csv (file, data, stream) then return the mapped converted data
            var result = ReadCsv(request);
            int recordCount = result.Count();
            int errorCount = 0;

            // try to convert each result to staging entity data
            foreach (var entry in result)
            {
                var each = new StagingBasicPay();

                if (entry.Result != null)
                {
                    each = p_Mapper.Map<StagingBasicPay>(entry.Result);
                }

                each.ProcessInstanceID = ProcessTracker.ProcessInstanceID;
                each.ImportIsValid = entry.IsValid;
                each.RowIndex = entry.RowIndex;

                if (!entry.IsValid)
                {
                    each.Err_ColumnIndex = entry.Error.ColumnIndex;
                    each.Err_UnmappedRow = entry.Error.UnmappedRow;
                    each.Err_Value = entry.Error.Value;

                    each.ValidationIsValid = false;
                }
                else
                {
                    each.ValidationIsValid = true;

                    List<ValidationFailureBO> validationFailures = new List<ValidationFailureBO>();

                    // validate the staging entity before saving to database
                    if (!Validate(entry.Result, entry.RowIndex, ref validationFailures))
                    {
                        errorsPerRow[entry.RowIndex] = validationFailures;

                        each.ValidationIsValid = false;

                        validationFailures.Select(er => p_Mapper.Map<ValidationFailure>(er))
                            .ToList()
                            .ForEach(error =>
                            {
                                errorCount++;
                                DbContext.ValidationFailures.Add(error);
                            });
                    }
                }

                DbContext.StagingBasicPays.Add(each);
            }

            ProcessTracker.LogMessage("Records Count: {0}", recordCount);
            ProcessTracker.LogMessage("Errors Count: {0}", errorCount);

            try
            {
                DbContext.BulkSaveChanges();
            }
            catch (Exception ex)
            {
                ProcessTracker.LogError(ex);
                ProcessTracker.Abort();
            }
        }
    }
}
