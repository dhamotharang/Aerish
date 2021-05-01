using System;
using System.Linq;

using Aerish.Application.Queries.EarningQrs;
using Aerish.Commands.EarningCmds.Earnings;
using Aerish.Common.Models;
using Aerish.Constants;
using Aerish.Domain.Entities.CalcData;
using Aerish.Domain.Models;
using Aerish.Interfaces;
using Aerish.Queries.EarningQrs;

using FluentValidation;

using TasqR;

namespace Aerish.Application.Commands.EarningCmds.Earnings
{
    public class ComputeEmployeeEarningCmdHandler : TasqHandler<CalcEmployeeEarningCmd>
    {
        private readonly IAerishDbContext p_DbContext;
        private readonly ITasqR p_Processor;

        public ComputeEmployeeEarningCmdHandler
            (
                IAerishDbContext dbContext,
                ITasqR processor
            )
        {
            p_DbContext = dbContext;
            p_Processor = processor;
        }

        public override void Run(CalcEmployeeEarningCmd process)
        {
            var query = process.m_NewMasterData.MasterEmployeeEarnings
                .Where(a => a.PlanYear == process.m_NewMasterData.PlanYear
                    && a.EarningID == process.Earning.EarningID);

            var earning = query.SingleOrDefault();

            var newComputedEarning = new MasterEmployeeEarningBO
            {
                EarningID = process.Earning.EarningID,
                IsAdjustIfAbsent = process.Earning.IsAdjustIfAbsent,
                IsComputed = process.Earning.IsComputed,
                IsDeMinimis = process.Earning.IsDeMinimis,
                IsNegativeComputation = process.Earning.IsNegativeComputation,
                IsPartOfBasicPay = process.Earning.IsPartOfBasicPay,
                IsReceivable = process.Earning.IsReceivable,
                IsTaxable = process.Earning.IsTaxable,
                RecordStatus = RecordStatus.Active,
                ShortDesc = process.Earning.ShortDesc,
                LongDesc = process.Earning.LongDesc,
                AltDesc = process.Earning.AltDesc
            };

            var clothing = p_Processor.Run(new GetEarningQr(EarningCodeConstants.ClothingAllowance));
            if (process.Earning.EarningID == clothing.EarningID)
            {
                newComputedEarning.Amount = 5000;
            }

            var shift = p_Processor.Run(new GetEarningQr(EarningCodeConstants.ShiftAllowance));
            if (process.Earning.EarningID == shift.EarningID)
            {
                newComputedEarning.Amount = 19786.29m;
            }

            if (IsDrop(process.m_NewMasterData, earning, newComputedEarning))
            {
                process.m_NewMasterData.DropEmployeeEarning(process.Earning.EarningID);
            }
            else
            {
                if (HasChanges(process.m_NewMasterData, earning, newComputedEarning))
                {
                    process.m_NewMasterData.AddNewEmployeeEarning(newComputedEarning);

                }
            }
        }

        protected virtual bool IsDrop(MasterDataBO newMasterData, MasterEmployeeEarningBO existingEarn, MasterEmployeeEarningBO newEarn)
        {
            if (existingEarn != null && newEarn != null && newEarn.Amount == 0)
            {
                return true;
            }

            return false;
        }

        protected virtual bool HasChanges(MasterDataBO newMasterData, MasterEmployeeEarningBO existingEarn, MasterEmployeeEarningBO newEarn)
        {
            if (existingEarn == null && newEarn != null && newEarn.Amount > 0)
            {
                return true;
            }

            if (existingEarn == null && newEarn != null && newEarn.Amount == 0)
            {
                return false;
            }

            if (existingEarn.Amount != newEarn.Amount && newEarn.Amount > 0)
            {
                return true;
            }

            if (existingEarn.AmountBasis != newEarn.AmountBasis)
            {
                return true;
            }

            return false;
        }
    }
}