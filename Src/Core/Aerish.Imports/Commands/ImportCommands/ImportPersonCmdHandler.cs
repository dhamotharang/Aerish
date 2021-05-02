using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Aerish.Domain.Entities.Staging;
using Aerish.Domain.Models;
using Aerish.Imports.Common.Base;
using Aerish.Interfaces;
using Aerish.Application;

using AutoMapper;

using FluentValidation;

using Microsoft.EntityFrameworkCore;

using TinyCsvParser;
using TinyCsvParser.Mapping;
using AutoMapper.QueryableExtensions;
using Aerish.Domain.Entities.Common;
using Microsoft.Extensions.Caching.Memory;

namespace Aerish.Imports.Commands.ImportCommands
{
    public class ImportPersonCmdHandler : BaseImportHandler<ImportPersonCmd, StagingPersonBO, StagingPersonBO>
    {
        private readonly IMapper p_Mapper;
        private readonly IAerishDbContext p_DbContext;
        private readonly DbContext p_BaseDbContext;
        private readonly IAppSession p_AppSession;
        private readonly Dictionary<int, IEnumerable<ValidationFailureBO>> errorsPerRow = new Dictionary<int, IEnumerable<ValidationFailureBO>>();
        private List<string> TaxNumbers = null;

        public ImportPersonCmdHandler(IMapper mapper, IAerishDbContext dbContext, DbContext baseDbContext, IAppSession appSession)
        {
            p_Mapper = mapper;
            p_DbContext = dbContext;
            p_BaseDbContext = baseDbContext;
            p_AppSession = appSession;
        }

        protected override BaseCsvMapping<StagingPersonBO> GetMapping()
        {
            return new BaseCsvMapping<StagingPersonBO>()
                .MapProperty(0, x => x.TaxIdNumber)
                .MapProperty(1, x => x.EmployeeSysID)
                .MapProperty(2, x => x.FirstName)
                .MapProperty(3, x => x.MiddleName)
                .MapProperty(4, x => x.LastName);
        }

        public override void Initialize(ImportPersonCmd request)
        {
            base.Initialize(request);

            // master process will save the context once the handler process is completed
            ProcessTracker.SaveContext = true;
        }

        protected override void StageData(ImportPersonCmd request)
        {
            // read the csv (file, data, stream) then return the mapped converted data
            var result = ReadCsv(request);
            int recordCount = result.Count();
            int errorCount = 0;

            // try to convert each result to staging entity data
            foreach (var entry in result)
            {
                var each = new StagingPerson();

                if (entry.Result != null)
                {
                    each = p_Mapper.Map<StagingPerson>(entry.Result);
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

                p_DbContext.StagingPersons.Add(each);
            }

            ProcessTracker.LogMessage("Records Count: {0}", recordCount);
            ProcessTracker.LogMessage("Errors Count: {0}", errorCount);

            try
            {
                p_BaseDbContext.BulkSaveChanges();
            }
            catch (Exception ex)
            {
                ProcessTracker.LogError(ex);
                ProcessTracker.Abort();
            }
        }

        public override IEnumerable SelectionCriteria(ImportPersonCmd request)
        {
            if (ProcessTracker.Aborted == true)
            {
                return new List<StagingPersonBO>();
            }

            return p_DbContext.StagingPersons
                .Where(a => a.ProcessInstanceID == ProcessTracker.ProcessInstanceID)
                .ProjectTo<StagingPersonBO>(p_Mapper.ConfigurationProvider)
                .OrderBy(a => a.RowIndex)
                .ToList();
        }

        public override StagingPersonBO Run(StagingPersonBO key, ImportPersonCmd request)
        {
            bool hasError = false;

            if (errorsPerRow.ContainsKey(key.RowIndex))
            {
                hasError = true;
                key.ValidationFailures = errorsPerRow[key.RowIndex];
            }

            if (!hasError)
            {
                p_DbContext.Employees.Add(new Employee
                {
                    ClientID = p_AppSession.ClientID,
                    EmployeeSysID = key.EmployeeSysID,
                    N_Person = new Person
                    {
                        TaxIdNumber = key.TaxIdNumber,
                        FirstName = key.FirstName,
                        MiddleName = key.MiddleName,
                        LastName = key.LastName,
                        Birthdate = key.Birthdate,
                        Gender = key.Gender
                    }
                });
            }

            return key;
        }


        protected override bool Validate(StagingPersonBO entry, int rowIndex, ref List<ValidationFailureBO> validationFailures)
        {
            bool isValid = base.Validate(entry, rowIndex, ref validationFailures);

            if (TaxNumbers == null)
            {
                TaxNumbers = p_DbContext.Persons.Select(a => a.TaxIdNumber).ToList();
            }

            if (TaxNumbers.Contains(entry.TaxIdNumber))
            {
                isValid = false;

                validationFailures.Add(new ValidationFailureBO
                {
                    RowIndex = rowIndex,
                    PropertyName = nameof(StagingPersonBO.TaxIdNumber),
                    ProcessInstanceID = ProcessTracker.ProcessInstanceID,
                    ErrorMessage = "Tax ID already exists in the database"
                });
            }

            return isValid;
        }

        protected override BaseValidator<StagingPersonBO> GetValidator()
        {
            var validator = new BaseValidator<StagingPersonBO>();

            validator.RuleFor(a => a.FirstName)
                    .NotEmpty().WithMessage("First name is required")
                    .MaximumLength(50).WithMessage("Has maxlength");

            return validator;
        }
    }
}