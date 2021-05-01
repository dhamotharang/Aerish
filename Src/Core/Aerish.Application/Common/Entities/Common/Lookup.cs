namespace Aerish.Domain.Entities.Common
{
    public class Lookup
    {
        public string Type { get; set; }
        public string Code { get; set; }
        public string ShortDesc { get; set; }
        public string LongDesc { get; set; }
        public string AltDesc { get; set; }

        public bool IsEnabled { get; set; }
    }
}
