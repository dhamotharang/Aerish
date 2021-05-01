using TasqR;

namespace Aerish.Commands
{
    public class RollbackEmployeeCmd : ITasq
    {

        public RollbackEmployeeCmd(int employeeID)
        {
            EmployeeID = employeeID;
        }

        public int EmployeeID { get; }
    }
}
