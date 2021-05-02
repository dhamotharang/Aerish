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

namespace Aerish.Imports.Commands.ImportCommands
{
    public class ImportBasicPayCmdHandler : BaseImportHandler<ImportBasicPayCmd, StagingBasicPayBO, StagingBasicPayBO>
    {
        private readonly IMapper p_Mapper;
        private readonly IAerishDbContext p_DbContext;
        private readonly IAppSession p_AppSession;
        private List<string> EmployeeSysIDs = null;
        private readonly Dictionary<int, IEnumerable<ValidationFailureBO>> errorsPerRow = new Dictionary<int, IEnumerable<ValidationFailureBO>>();

        public ImportBasicPayCmdHandler(IMapper mapper, IAerishDbContext dbContext, IAppSession appSession)
        {
            p_Mapper = mapper;
            p_DbContext = dbContext;
            p_AppSession = appSession;
        }

        public override StagingBasicPayBO Run(StagingBasicPayBO key, ImportBasicPayCmd request)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable SelectionCriteria(ImportBasicPayCmd request)
        {
            throw new NotImplementedException();
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

            if (EmployeeSysIDs == null)
            {
                EmployeeSysIDs = p_DbContext.Employees.Select(a => a.EmployeeSysID).ToList();
            }

            if (!string.IsNullOrWhiteSpace(entry.EmployeeSysID)
                && !EmployeeSysIDs.Contains(entry.EmployeeSysID))
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
                                p_DbContext.ValidationFailures.Add(error);
                            });
                    }
                }

                p_DbContext.StagingBasicPays.Add(each);
            }

            ProcessTracker.LogMessage("Records Count: {0}", recordCount);
            ProcessTracker.LogMessage("Errors Count: {0}", errorCount);

            try
            {
                p_DbContext.BulkSaveChanges();
            }
            catch (Exception ex)
            {
                ProcessTracker.LogError(ex);
                ProcessTracker.Abort();
            }
        }
    }
}
