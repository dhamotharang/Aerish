using System;
using System.Collections.Generic;
using System.Text;

using Aerish.Application.Commands.DeductionCmds.Contributions;
using Aerish.Commands;
using Aerish.Commands.CalcCmds;
using Aerish.Commands.DeductionCmds.Contributions;
using Aerish.Commands.DeductionCmds.Deductions;
using Aerish.Commands.EarningCmds.Earnings;
using Aerish.Commands.LoanCmds.CompanyLoans;
using Aerish.Constants;
using Aerish.Domain.Entities.Common;
using Aerish.Imports.Commands;

namespace Aerish.Infrastructure.Persistence.Configurations
{
    public partial class TaskHandlerProvider_Configuration
    {
        protected override void KeyBuilder(BaseKeyBuilder<TaskHandlerProvider> builder)
        {
            builder.HasKey(a => a.ID);
        }

        protected override void ConfigureProperty(BasePropertyBuilder<TaskHandlerProvider> builder)
        {
            builder.Property(a => a.ID)
                .ValueGeneratedNever();

            builder.Property(p => p.TaskAssembly)
                .IsRequired()
                .HasMaxLength(StringLengthConstant.Assembly);

            builder.Property(p => p.TaskClass)
                .IsRequired()
                .HasMaxLength(StringLengthConstant.ClassName);

            builder.Property(p => p.HandlerAssembly)
                .HasMaxLength(StringLengthConstant.Assembly);

            builder.Property(p => p.HandlerClass)
                .HasMaxLength(StringLengthConstant.ClassName);
        }

        protected override void SeedData(BaseSeeder<TaskHandlerProvider> builder)
        {
            builder.HasData(new TaskHandlerProvider
            {
                ID = TaskHandlerProviderConstants.BasicPay,
                TaskAssembly = typeof(CalcBasicPayCmd).Assembly.FullName,
                TaskClass = typeof(CalcBasicPayCmd).FullName
            });

            builder.HasData(new TaskHandlerProvider
            {
                ID = TaskHandlerProviderConstants.DefaultEarning,
                TaskAssembly = typeof(CalcEmployeeEarningCmd).Assembly.FullName,
                TaskClass = typeof(CalcEmployeeEarningCmd).FullName
            });

            builder.HasData(new TaskHandlerProvider
            {
                ID = TaskHandlerProviderConstants.CashAdvanceDeduction,
                TaskAssembly = typeof(CashAdvanceDeductionCmd).Assembly.FullName,
                TaskClass = typeof(CashAdvanceDeductionCmd).FullName
            });

            builder.HasData(new TaskHandlerProvider
            {
                ID = TaskHandlerProviderConstants.OtherDeduction,
                TaskAssembly = typeof(OtherDeductionCmd).Assembly.FullName,
                TaskClass = typeof(OtherDeductionCmd).FullName
            });

            builder.HasData(new TaskHandlerProvider
            {
                ID = TaskHandlerProviderConstants.ContributionDeductionSSS,
                TaskAssembly = typeof(ContributionDeductionCmd).Assembly.FullName,
                TaskClass = typeof(ContributionDeductionCmd).FullName,
                HandlerAssembly = typeof(SSSContributionDeductionCmdHandler).Assembly.FullName,
                HandlerClass = typeof(SSSContributionDeductionCmdHandler).FullName
            });

            builder.HasData(new TaskHandlerProvider
            {
                ID = TaskHandlerProviderConstants.ContributionDeductionPagIBIG,
                TaskAssembly = typeof(ContributionDeductionCmd).Assembly.FullName,
                TaskClass = typeof(ContributionDeductionCmd).FullName,
                HandlerAssembly = typeof(PagIBIGContributionDeductionCmdHandler).Assembly.FullName,
                HandlerClass = typeof(PagIBIGContributionDeductionCmdHandler).FullName
            });

            builder.HasData(new TaskHandlerProvider
            {
                ID = TaskHandlerProviderConstants.ContributionDeductionPhilHealth,
                TaskAssembly = typeof(ContributionDeductionCmd).Assembly.FullName,
                TaskClass = typeof(ContributionDeductionCmd).FullName,
                HandlerAssembly = typeof(PhilHealthContributionDeductionCmdHandler).Assembly.FullName,
                HandlerClass = typeof(PhilHealthContributionDeductionCmdHandler).FullName
            });


            builder.HasData(new TaskHandlerProvider
            {
                ID = TaskHandlerProviderConstants.MainCalc,
                TaskAssembly = typeof(MainCalcCmd).Assembly.FullName,
                TaskClass = typeof(MainCalcCmd).FullName
            });

            builder.HasData(new TaskHandlerProvider
            {
                ID = TaskHandlerProviderConstants.RollbackCalc,
                TaskAssembly = typeof(RollbackEmployeeCmd).Assembly.FullName,
                TaskClass = typeof(RollbackEmployeeCmd).FullName
            });

            builder.HasData(new TaskHandlerProvider
            {
                ID = TaskHandlerProviderConstants.ImportPerson,
                TaskAssembly = typeof(ImportPersonCmd).Assembly.FullName,
                TaskClass = typeof(ImportPersonCmd).FullName
            });


            builder.HasData(new TaskHandlerProvider
            {
                ID = TaskHandlerProviderConstants.HMOPremiumPayableLoan,
                TaskAssembly = typeof(HMOPremiumPayableLoanCmd).Assembly.FullName,
                TaskClass = typeof(HMOPremiumPayableLoanCmd).FullName
            });
        }
    }
}
