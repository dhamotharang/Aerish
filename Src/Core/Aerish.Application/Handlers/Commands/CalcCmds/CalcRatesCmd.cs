using System;
using System.Linq;

using Aerish.Application.Queries.EarningQrs;
using Aerish.Commands.Base;
using Aerish.Common.Models;
using Aerish.Constants;
using Aerish.Domain.Models;
using Aerish.Interfaces;
using Aerish.Queries.EarningQrs;

using TasqR;

namespace Aerish.Application.Commands.CalcCmds
{
    public class CalcRatesCmd : BaseCalculationCommand, ITasq
    {
        public CalcRatesCmd(IProcessTrackerBase processTracker, MasterDataBO oldMasterData, MasterDataBO newMasterData)
            : base(processTracker, oldMasterData, newMasterData, null)
        {

        }

        public class CalcRatesCmdHandler : TasqHandler<CalcRatesCmd>
        {
            private readonly IAerishDbContext p_DbContext;
            private readonly ITasqR p_Processor;

            public CalcRatesCmdHandler
                (
                    IAerishDbContext dbContext,
                    ITasqR processor
                )
            {
                p_DbContext = dbContext;
                p_Processor = processor;
            }

            public override void Run(CalcRatesCmd request)
            {
                var earning = p_Processor.Run(new GetEarningQr(EarningCodeConstants.BasicPay));
                var basicPay = request.m_NewMasterData.MasterEmployeeEarnings
                    .SingleOrDefault(a => a.EarningID == earning.EarningID);

                if (basicPay == null)
                {
                    throw new AerishException("No basic pay configured?");
                }

                switch (basicPay.AmountBasis)
                {
                    case AmountBasis.Monthly:
                        ComputeAsMonthly(request.m_NewMasterData, basicPay);
                        break;
                    case AmountBasis.SemiMontly:
                        break;
                    case AmountBasis.BiWeekly:
                        ComputeAsBiWeekly(request.m_NewMasterData, basicPay);
                        break;
                    case AmountBasis.Weekly:
                        break;
                    case AmountBasis.Daily:
                        break;
                    case AmountBasis.Hourly:
                        break;
                    default:
                        break;
                }
            }

            public virtual void ComputeAsMonthly(MasterDataBO masterData, MasterEmployeeEarningBO basicPay)
            {
                decimal days = masterData.DaysFactor.GetValueOrDefault() / 12;

                masterData.BasicPayBasis = basicPay.AmountBasis;
                masterData.MonthlyRate = basicPay.Amount;
                masterData.DailyRate = basicPay.Amount / days;
            }

            public virtual void ComputeAsBiWeekly(MasterDataBO masterData, MasterEmployeeEarningBO basicPay)
            {
                decimal days = masterData.DaysFactor.GetValueOrDefault() / 12;

                masterData.BasicPayBasis = basicPay.AmountBasis;
                masterData.MonthlyRate = basicPay.Amount;
                masterData.DailyRate = basicPay.Amount / days;
            }
        }
    }
}
