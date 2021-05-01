using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Aerish.Admin.Client.ViewModels;

namespace Aerish.Admin.Shared.ViewModels
{
    public class MasterDataSummaryVM
    {
        public int EmployeeID { get; set; }
        public short ClientID { get; set; }
        public short CalcID { get; set; }
        public short PlanYear { get; set; }
        public short PayRunID { get; set; }

        public RecordStatus RecordStatus { get; set; }

        public virtual decimal? DaysFactor { get; set; }
        public virtual decimal? HourlyRate { get; set; }
        public virtual decimal? DailyRate { get; set; }
        public virtual decimal? MonthlyRate { get; set; }
        public virtual AmountBasis? BasicPayBasis { get; set; }

        public virtual decimal? TotalTaxableIncome { get; set; }
        public virtual decimal? TotalNonTaxableIncome { get; set; }
        public virtual decimal? NetTaxableIncome { get; set; }
        public virtual decimal? WitholdingTax { get; set; }
        public virtual decimal? TotalDeduction { get; set; }
        public virtual decimal? NetSalary { get; set; }

        public PayRunVM PayRun { get; set; }
    }
}
