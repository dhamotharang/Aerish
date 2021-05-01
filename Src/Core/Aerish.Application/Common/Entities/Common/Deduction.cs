namespace Aerish.Domain.Entities.Common
{
    public class Deduction
    {
        public short DeductionID { get; set; }
        
        public short ClientID { get; set; }
        public string Code { get; set; }

        public string ShortDesc { get; set; }
        public string LongDesc { get; set; }
        public string AltDesc { get; set; }
        public short DeductionTypeID { get; set; }
        public bool IsEnabled { get; set; }

        public bool IsExcludedInTax { get; set; }

        public int? TaskHandlerProviderID { get; set; }


        public DeductionType N_DeductionType { get; set; }
        public TaskHandlerProvider N_TaskHandlerProvider { get; set; }


        public override string ToString()
        {
            return AltDesc ?? LongDesc ?? ShortDesc;
        }
    }
}