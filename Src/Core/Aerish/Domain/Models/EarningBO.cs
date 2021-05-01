using System;
using System.Collections.Generic;
using System.Text;

namespace Aerish.Domain.Models
{
    public class EarningBO
    {
        public short EarningID { get; set; }

        public short ClientID { get; set; }
        public string Code { get; set; }


        public string ShortDesc { get; set; }
        public string LongDesc { get; set; }
        public string AltDesc { get; set; }
        public short EarningTypeID { get; set; }
        public bool IsEnabled { get; set; }


        public bool IsComputed { get; set; }
        public bool IsTaxable { get; set; }
        public bool IsReceivable { get; set; }
        public bool IsPartOfBasicPay { get; set; }
        public bool IsDeMinimis { get; set; }
        public bool IsAdjustIfAbsent { get; set; }
        public bool IsNegativeComputation { get; set; }
        public ComputedBy? ComputedBy { get; set; }

        public int? TaskHandlerProviderID { get; set; }

        public TaskHandlerProviderBO TaskHandlerProvider { get; set; }
    }
}
