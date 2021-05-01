using System;
using System.Collections.Generic;
using System.Text;

using Aerish.Domain.Models;

using TasqR;

namespace Aerish.Queries.NavigationQrs
{
    public class GetNavigationQr : ITasq<NodeItemSetBO>
    {
        public GetNavigationQr(int? employeeID, string filter = null, string currentUri = null)
        {
            EmployeeID = employeeID;
            Filter = filter;
            CurrentUri = currentUri;
        }

        public int? EmployeeID { get; }
        public string Filter { get; }
        public string CurrentUri { get; }
    }
}
