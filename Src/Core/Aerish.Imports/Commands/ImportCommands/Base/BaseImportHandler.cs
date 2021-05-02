using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Aerish.Commands.Base;
using Aerish.Domain.Models;
using Aerish.Imports.Commands.ImportCommands;
using Aerish.Interfaces;

using FluentValidation;

using TasqR;

using TinyCsvParser;
using TinyCsvParser.Mapping;

namespace Aerish.Imports.Common.Base
{
    public abstract class BaseImportHandler<TProcess, TKey, TResponse> : TasqHandler<TProcess, TKey, TResponse>
        where TProcess : ITasq<TKey, TResponse>
        where TKey : class, new()
    {
        private Dictionary<string, int> employeeIds = null;

        protected IProcessTracker ProcessTracker { get; private set; }
        protected IAerishDbContext DbContext { get; }
        protected IAppSession AppSession { get; }

        protected Dictionary<string, int> EmployeeIDs
        {
            get => employeeIds ?? (employeeIds = DbContext.Employees
                .Select(a => new { a.EmployeeSysID, a.EmployeeID })
                .ToDictionary(a => a.EmployeeSysID, a => a.EmployeeID));
        }

        protected BaseImportHandler(IAerishDbContext dbContext, IAppSession appSession)
        {
            DbContext = dbContext;
            AppSession = appSession;
        }

        public override void Initialize(TProcess request)
        {
            if (request is BaseImportCommand baseImportCmd)
            {
                ProcessTracker = (IProcessTracker)baseImportCmd.ProcessTracker;
            }

            StageData(request);

            base.Initialize(request);
        }

        protected abstract void StageData(TProcess request);
        protected abstract BaseCsvMapping<TKey> GetMapping();
        protected abstract BaseValidator<TKey> GetValidator();

        protected IEnumerable<CsvMappingResult<TKey>> ReadCsv(TProcess request)
        {
            var csvParser = GetCsvParser();

            List<CsvMappingResult<TKey>> result = null;

            if (request is BaseImportCommand importCommand)
            {
                switch (importCommand.LoadType)
                {
                    case ImportLoadType.File:
                        result = csvParser.ReadFromFile
                            (
                                importCommand.Path,
                                Encoding.ASCII
                            ).ToList();
                        break;
                    case ImportLoadType.Data:
                        result = csvParser.ReadFromString
                            (
                                new CsvReaderOptions(new[] { Environment.NewLine }),
                                importCommand.Data
                            ).ToList();
                        break;
                }
            }            

            if (result == null)
            {
                throw new AerishException("Mapping Result is null");
            }

            return result;
        }

        protected virtual bool Validate(TKey entry, int rowIndex, ref List<ValidationFailureBO> validationFailures)
        {
            var validator = GetValidator();

            var validationResult = validator.Validate(entry);
            var validationFailureList = new List<ValidationFailureBO>();

            foreach (var error in validationResult.Errors)
            {
                validationFailureList.Add(new ValidationFailureBO
                {
                    ProcessInstanceID = ProcessTracker.ProcessInstanceID,
                    RowIndex = rowIndex,
                    PropertyName = error.PropertyName,
                    ErrorMessage = error.ErrorMessage
                });
            }

            validationFailures = validationFailureList;

            return !validationResult.Errors.Any();
        }

        protected virtual CsvParser<TKey> GetCsvParser()
        {
            var csvParserOptions = new CsvParserOptions(true, ',');
            return new CsvParser<TKey>(csvParserOptions, GetMapping());
        }
    }
}
