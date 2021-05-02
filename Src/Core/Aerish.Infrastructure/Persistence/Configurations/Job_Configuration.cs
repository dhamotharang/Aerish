using Aerish.Commands;
using Aerish.Commands.CalcCmds;
using Aerish.Constants;
using Aerish.Domain.Entities.Parameters;
using Aerish.Infrastructure.Constants;

namespace Aerish.Infrastructure.Persistence.Configurations
{
    public partial class Job_Configuration
    {
        protected override void KeyBuilder(BaseKeyBuilder<Job> builder)
        {
            builder.HasKey(p => new
            {
                p.ClientID,
                p.JobID
            });
        }

        protected override void ConfigureProperty(BasePropertyBuilder<Job> builder)
        {
            builder.Property(a => a.JobID)
                .ValueGeneratedNever();

            builder.Property(a => a.ShortDesc)
                .IsRequired()
                .HasMaxLength(StringLengthConstant.ShortDesc);

            builder.Property(a => a.LongDesc)
                .IsRequired()
                .HasMaxLength(StringLengthConstant.LongDesc);

            builder.Property(a => a.AltDesc)
                .HasMaxLength(StringLengthConstant.AltDesc);
        }

        protected override void ConfigureRelationship(BaseRelationshipBuilder<Job> builder)
        {
            builder.HasOne(a => a.N_TaskHandlerProvider)
                .WithMany()
                .HasForeignKey(a => a.TaskHandlerProviderID);
        }

        protected override void SeedData(BaseSeeder<Job> builder)
        {
            builder.HasData(new Job
            {
                ClientID = ClientConstant.Default,
                JobID = MainConstants.Job.MainCalc,
                ShortDesc = "Main Calc",
                LongDesc = "Main Calc",
                IsEnabled = true,
                TaskHandlerProviderID = TaskHandlerProviderConstants.MainCalc
            });

            builder.HasData(new Job
            {
                ClientID = ClientConstant.Default,
                JobID = 404,
                ShortDesc = "Rollback Employee",
                LongDesc = "Rollback Employee",
                IsEnabled = true,
                TaskHandlerProviderID = TaskHandlerProviderConstants.RollbackCalc
            });

            builder.HasData(new Job
            {
                ClientID = ClientConstant.Default,
                JobID = MainConstants.Job.ImportPerson,
                ShortDesc = "Import Person Data",
                LongDesc = "Import Person Data",
                IsEnabled = true,
                TaskHandlerProviderID = TaskHandlerProviderConstants.ImportPerson
            });

            builder.HasData(new Job
            {
                ClientID = ClientConstant.Default,
                JobID = MainConstants.Job.ImportBasicPay,
                ShortDesc = "Import Basic Pay Data",
                LongDesc = "Import Basic Pay Data",
                IsEnabled = true,
                TaskHandlerProviderID = TaskHandlerProviderConstants.ImportBasicPay
            });
        }
    }
}