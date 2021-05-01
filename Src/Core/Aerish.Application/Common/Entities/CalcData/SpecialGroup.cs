using System.Collections.Generic;

namespace Aerish.Domain.Entities.CalcData
{
    public class SpecialGroup
    {
        public int GroupID { get; set; }
        public string Name { get; set; }


        public ICollection<SpecialGroupMember> Members { get; set; } = new HashSet<SpecialGroupMember>();
    }
}
