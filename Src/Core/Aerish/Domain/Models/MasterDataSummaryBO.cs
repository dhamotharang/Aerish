using System;
using System.Collections.Generic;
using System.Text;



namespace Aerish.Domain.Models
{
    public class MasterDataSummaryBO 
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

        public PayRunBO PayRun { get; set; }
    }
}
