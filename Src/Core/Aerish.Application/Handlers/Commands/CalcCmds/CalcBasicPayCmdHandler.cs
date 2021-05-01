using System;
using System.Linq;
using Aerish.Application.Common.Models;
using Aerish.Application.Queries.BasicPayQrs;
using Aerish.Application.Queries.EarningQrs;
using Aerish.Commands.CalcCmds;
using Aerish.Common.Models;
using Aerish.Constants;
using Aerish.Domain.Entities.CalcData;
using Aerish.Domain.Entities.Common;
using Aerish.Domain.Models;
using Aerish.Interfaces;
using Aerish.Queries.BasicPayQrs;
using Aerish.Queries.EarningQrs;

using TasqR;

namespace Aerish.Application.Commands.CalcCmds
{
    public class CalcBasicPayCmdHandler : TasqHandler<CalcBasicPayCmd>
    {
        private readonly IAerishDbContext p_DbContext;
        private readonly ITasqR p_Processor;
        private IProcessTracker p_ProcessTracker;

        public CalcBasicPayCmdHandler
            (
                IAerishDbContext dbContext, 
                ITasqR processor
            )
        {
            p_DbContext = dbContext;
            p_Processor = processor;
        }

        public override void Initialize(CalcBasicPayCmd request)
        {
            p_ProcessTracker = (IProcessTracker)request.ProcessTracker;
        }

        public override void Run(CalcBasicPayCmd request)
        {
            p_ProcessTracker.LogMessage("Calculate Basic Pay - Start");

            var basicPayEarnRef = request.BasicPay;

            var basicPay = p_Processor.Run(new GetBasicPayQr
                (
                    request.m_NewMasterData.EmployeeID,
                    request.m_NewMasterData.PlanYear,
                    request.m_NewMasterData.PayRunID
                ));

            var earning = p_Processor.Run(new GetEarningQr(EarningCodeConstants.BasicPay));

            var newCalcdEarning = new MasterEmployeeEarningBO
            {
                EarningID = earning.EarningID,
                Amount = basicPay.Amount,
                AmountBasis = basicPay.AmountBasis,
                IsAdjustIfAbsent = basicPayEarnRef.IsAdjustIfAbsent,
                IsComputed = basicPayEarnRef.IsComputed,
                IsDeMinimis = basicPayEarnRef.IsDeMinimis,
                IsNegativeComputation = basicPayEarnRef.IsNegativeComputation,
                IsPartOfBasicPay = basicPayEarnRef.IsPartOfBasicPay,
                IsReceivable = basicPayEarnRef.IsReceivable,
                IsTaxable = basicPayEarnRef.IsTaxable,
                ShortDesc = earning.ShortDesc,
                LongDesc = earning.LongDesc,
                AltDesc = earning.AltDesc
            };

            var existingEarning = request.m_NewMasterData.MasterEmployeeEarnings
                .SingleOrDefault(a => a.EarningID == earning.EarningID);

            if (HasChanges(request.m_NewMasterData, existingEarning, newCalcdEarning))
            {
                p_ProcessTracker.LogMessage("Calculate Basic Pay - Has Changes");

                request.m_NewMasterData.AddNewEmployeeEarning(newCalcdEarning);
            }
            else
            {
                p_ProcessTracker.LogMessage("Calculate Basic Pay - No Change");
            }

            p_ProcessTracker.LogMessage("Calculate Basic Pay - End");

        }

        protected virtual bool HasChanges(MasterDataBO newMasterData, MasterEmployeeEarningBO oldEarn, MasterEmployeeEarningBO basicEarn)
        {
            if (oldEarn == null)
            {
                return basicEarn != null;
            }

            if (newMasterData.MonthlyRate != basicEarn.Amount && basicEarn.Amount > 0)
            {
                return true;
            }

            if (newMasterData.BasicPayBasis != basicEarn.AmountBasis)
            {
                return true;
            }

            return false;
        }
    }
}