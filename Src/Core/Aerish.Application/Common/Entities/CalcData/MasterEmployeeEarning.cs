using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aerish.Domain.Common.Keys;
using Aerish.Domain.Entities.Common;
using Aerish.Domain.Entities.Parameters;

namespace Aerish.Domain.Entities.CalcData
{
    public class MasterEmployeeEarning : MasterEmployeeKey
    {
        public int MasterEmployeeEarningID { get; set; }
        public short EarningID { get; set; }

        public string ShortDesc { get; set; }
        public string LongDesc { get; set; }
        public string AltDesc { get; set; }


        public bool IsComputed { get; set; }
        public bool IsTaxable { get; set; }
        public bool IsReceivable { get; set; }
        public bool IsPartOfBasicPay { get; set; }
        public bool IsDeMinimis { get; set; }
        public bool IsAdjustIfAbsent { get; set; }
        public bool IsNegativeComputation { get; set; }


        public AmountBasis AmountBasis { get; set; }
        public ComputedBy? ComputedBy { get; set; }
        public decimal? ComputedByValue { get; set; }
        public decimal Amount { get; set; }
        public RecordStatus RecordStatus { get; set; }

        public PayRun N_PayRun { get; set; }
        public Earning N_Earning { get; set; }
    }
}