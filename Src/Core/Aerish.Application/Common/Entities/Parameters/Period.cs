namespace Aerish.Domain.Entities.Parameters
{
    public class Period
    {
        public short PeriodID { get; set; }
        public short PaymentModeID { get; set; }
        public string ShortDesc { get; set; }
        public string LongDesc { get; set; }
        public string AltDesc { get; set; }


        public short Order { get; set; }
        public bool IsEveryPayroll { get; set; }
        public bool IsNeedPayoutPlace { get; set; }

        public PaymentMode N_PaymentMode { get; set; }
    }
}