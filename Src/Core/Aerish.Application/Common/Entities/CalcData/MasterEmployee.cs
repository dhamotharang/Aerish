using Aerish.Domain.Common.Keys;
using Aerish.Domain.Entities.Common;
using Aerish.Domain.Entities.Parameters;
using System.Collections.Generic;

namespace Aerish.Domain.Entities.CalcData
{
    public class MasterEmployee : MasterEmployeeKey
    {
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

        public virtual PayRun N_PayRun { get; set; }

        public Employee N_Employee { get; set; }

        public virtual ICollection<MasterEmployeeDeduction> N_MasterEmployeeDeductions { get; set; } = new HashSet<MasterEmployeeDeduction>();
        public virtual ICollection<MasterEmployeeEarning> N_MasterEmployeeEarnings { get; set; } = new HashSet<MasterEmployeeEarning>();
        public virtual ICollection<MasterEmployeeLoan> N_MasterEmployeeLoans { get; set; } = new HashSet<MasterEmployeeLoan>();
    }
}
