using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aerish.Application.Common.Models;
using Aerish.Application.Queries.DeductionQrs;
using Aerish.Commands.DeductionCmds.Deductions;
using Aerish.Constants;
using Aerish.Domain.Entities.CalcData;
using Aerish.Domain.Entities.Common;
using Aerish.Domain.Entities.Parameters;
using Aerish.Domain.Models;
using Aerish.Interfaces;
using Aerish.Queries.DeductionQrs;

using Microsoft.EntityFrameworkCore;
using TasqR;

namespace Aerish.Application.Commands.DeductionCmds.Deductions
{
    public class OtherDeductionCmdHandler : TasqHandler<OtherDeductionCmd>
    {
        private readonly IAerishDbContext p_DbContext;
        private readonly ITasqR p_Processor;
        private readonly IAppSession p_AppSession;

        public OtherDeductionCmdHandler
            (
                IAerishDbContext dbContext,
                ITasqR processor,
                IAppSession appSession
            )
        {
            p_DbContext = dbContext;
            p_Processor = processor;
            p_AppSession = appSession;
        }

        public override void Run(OtherDeductionCmd process)
        {
            var ded = p_Processor.Run(new GetDeductionQr(DeductionCodeConstants.Others));

            var empDeduction = p_DbContext.EmployeeDeductionRefs
                .AsNoTracking()
                .Include(a => a.N_EmployeeDeductions.Where(b => b.PlanYear == process.m_NewMasterData.PlanYear
                                                            && b.PayRunID == process.m_NewMasterData.PayRunID))
                .Include(a => a.N_Deduction)
                .SingleOrDefault(a => a.DeductionID == ded.DeductionID
                    && a.ClientID == p_AppSession.ClientID
                    && a.EmployeeID == process.m_NewMasterData.EmployeeID);

            if (empDeduction == null)
            {
                return;
            }

            var deduction = empDeduction.N_EmployeeDeductions
                .Select(a => new MasterEmployeeDeductionBO
                {
                    DeductionID = empDeduction.DeductionID,
                    ShortDesc = empDeduction.OvrdShortDesc ?? empDeduction.N_Deduction.ShortDesc,
                    LongDesc = empDeduction.OvrdLongDesc ?? empDeduction.N_Deduction.LongDesc,
                    AltDesc = empDeduction.OvrdAltDesc ?? empDeduction.N_Deduction.AltDesc,
                    EmployeeAmount = a.Amount,
                    RecordStatus = RecordStatus.Active
                })
                .SingleOrDefault();

            var existingDeduction = process.m_NewMasterData.MasterEmployeeDeductions
                .SingleOrDefault(a => a.DeductionID == ded.DeductionID);

            if (HasChanges(existingDeduction, deduction))
            {
                process.m_NewMasterData.AddNewEmployeeDeduction(deduction);
            }
        }

        protected virtual bool HasChanges(MasterEmployeeDeductionBO previousDeduction, MasterEmployeeDeductionBO newComputed)
        {
            if (previousDeduction == null)
            {
                return true;
            }

            if (previousDeduction.EmployeeAmount != newComputed.EmployeeAmount
                || previousDeduction.EmployerAmount != newComputed.EmployerAmount)
            {
                return true;
            }

            return false;
        }
    }
}