
namespace Aerish.Domain.Common.Keys
{
    public abstract class MasterEmployeeKey : EmployeeKey
    {
        public short CalcID { get; set; }
        public virtual short PlanYear { get; set; }
        public virtual short PayRunID { get; set; }

    }
}
