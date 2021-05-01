using System;
using System.Collections.Generic;
using System.Text;

namespace Aerish.Constants
{
    public abstract class TaskHandlerProviderConstants
    {
        protected TaskHandlerProviderConstants() { }

        #region Earnings 100s
        public const int BasicPay = 100;
        public const int DefaultEarning = 101;
        #endregion

        #region Deductions 200s
        public const int DefaultDeduction = 200;
        public const int CashAdvanceDeduction = 201;
        public const int OtherDeduction = 202;
        #endregion

        #region Contributions 300s
        public const int ContributionDeductionSSS = 300;
        public const int ContributionDeductionPagIBIG = 301;
        public const int ContributionDeductionPhilHealth = 302;
        #endregion

        #region Loans 400s
        public const int HMOPremiumPayableLoan = 401;
        #endregion

        #region Jobs 1000s
        public const int MainCalc = 1000;
        public const int RollbackCalc = 1001;
        public const int ImportPerson = 2000;
        #endregion
    }
}
