using Aerish.Domain.Common.Keys;
using Aerish.Domain.Entities.Common;
using Aerish.Domain.Entities.Parameters;

namespace Aerish.Domain.Entities.CalcData
{
    public class MasterEmployeeDeduction : MasterEmployeeKey
    {
        public int MasterEmployeeDeductionID { get; set; }
        public short DeductionID { get; set; }


        public string ShortDesc { get; set; }
        public string LongDesc { get; set; }
        public string AltDesc { get; set; }


        public decimal EmployeeAmount { get; set; }
        public decimal EmployerAmount { get; set; }

        public RecordStatus RecordStatus { get; set; }

        public PayRun N_PayRun { get; set; }
        public Deduction N_Deduction { get; set; }
    }
}
