using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Aerish.Common.Models;
using Aerish.ViewModels;

using TasqR;

namespace Aerish.Queries.EmployeeQrs
{
    public class GetEmployeesQr : ITasq<CollectionResult<EmployeeSummaryBO>>
    {
        public GetEmployeesQr(string filter, DataResultType dataResultType = DataResultType.Summary)
        {
            Filter = filter?.Trim();
            DataResultType = dataResultType;

            FilterField = EmployeeFilterField.FullName;

            if (string.IsNullOrEmpty(Filter))
            {
                FilterField = EmployeeFilterField.None;
            }
        }

        public string Filter { get; }
        public DataResultType DataResultType { get; }
        public EmployeeFilterField FilterField { get; }
    }
}
