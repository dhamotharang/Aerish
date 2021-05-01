using Aerish.Commands;
using Aerish.Interfaces;

using TasqR;

namespace Aerish.Application.Commands.CommonJobCmds
{
    public class RollbackEmployeeCmdHandler : TasqHandler<RollbackEmployeeCmd>
    {
        private readonly IAerishDbContext dbContext;
        private readonly IAppSession appSession;

        public RollbackEmployeeCmdHandler(IAerishDbContext dbContext, IAppSession appSession)
        {
            this.dbContext = dbContext;
            this.appSession = appSession;
        }

        public override void Run(RollbackEmployeeCmd process)
        {
            //var query = dbContext.MasterEmployees
            //   .Where(a => a.EmployeeID == process.employeeID && a.ClientID == appSession.ClientID)
            //   .OrderByDescending(a => a.PlanYear)
            //   .OrderByDescending(a => a.PayPeriodID);

            //var latestCalc = query.FirstOrDefault();

            //if (latestCalc == null)
            //{
            //    return;
            //}

            //dbContext.MasterEmployeeDeductions.RemoveRange(dbContext.MasterEmployeeDeductions
            //    .Where(a => a.PlanYear == latestCalc.PlanYear
            //        && a.PayPeriodID == latestCalc.PayPeriodID
            //        && a.EmployeeID == latestCalc.EmployeeID
            //        && a.ClientID == latestCalc.ClientID));

            //dbContext.MasterEmployeeEarnings.RemoveRange(dbContext.MasterEmployeeEarnings
            //    .Where(a => a.PlanYear == latestCalc.PlanYear
            //        && a.PayPeriodID == latestCalc.PayPeriodID
            //        && a.EmployeeID == latestCalc.EmployeeID
            //        && a.ClientID == latestCalc.ClientID));

            //dbContext.MasterEmployees.Remove(latestCalc);
        }
    }
}