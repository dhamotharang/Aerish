namespace Aerish.Domain.Entities.Parameters
{
    public class JobParameter
    {
        public short ClientID { get; set; }
        public short JobID { get; set; }
        public string Name { get; set; }
        public string Display { get; set; }

        public string DefaultValue { get; set; }
        public string DataType { get; set; }
        public int? MaxLength { get; set; }


        public bool IsRequired { get; set; }
        public short Order { get; set; }
    }
}
