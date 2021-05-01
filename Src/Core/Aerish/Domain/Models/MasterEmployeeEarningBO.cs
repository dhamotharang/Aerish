using System;
using System.Collections.Generic;
using System.Text;

namespace Aerish.Domain.Models
{
    public class MasterEmployeeEarningBO
    {
        public int MasterEmployeeEarningID { get; set; }
        public short EarningID { get; set; }

        public short PlanYear { get; set; }
        public short PayRunID { get; set; }

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

        public EarningBO Earning { get; set; }
    }
}
