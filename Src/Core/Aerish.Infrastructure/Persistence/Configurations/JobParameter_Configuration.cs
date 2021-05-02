using Aerish.Constants;
using Aerish.Domain.Entities.Parameters;
using Aerish.Infrastructure.Constants;

namespace Aerish.Infrastructure.Persistence.Configurations
{
    public partial class JobParameter_Configuration
    {
        protected override void KeyBuilder(BaseKeyBuilder<JobParameter> builder)
        {
            builder.HasKey(a => new
            {
                a.ClientID,
                a.JobID,
                a.Name
            });
        }

        protected override void ConfigureProperty(BasePropertyBuilder<JobParameter> builder)
        {
            builder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(StringLengthConstant.CommonName);

            builder.Property(a => a.Display)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(a => a.DataType)
                .IsRequired()
                .HasMaxLength(20);
        }

        protected override void ConfigureRelationship(BaseRelationshipBuilder<JobParameter> builder)
        {
            builder.HasOne<Job>()
                .WithMany(a => a.N_JobParameters)
                .HasForeignKey(a => new
                {
                    a.ClientID,
                    a.JobID
                });
        }

        protected override void SeedData(BaseSeeder<JobParameter> builder)
        {
            builder.HasData(new JobParameter
            {
                ClientID = ClientConstant.Default,
                JobID = MainConstants.Job.MainCalc,
                Name = "PlanYear",
                Display = "Plan Year",
                DefaultValue = "2021",
                DataType = InputDataTypeConstants.SmallInt,
                IsRequired = true,
                Order = 1
            });

            builder.HasData(new JobParameter
            {
                ClientID = ClientConstant.Default,
                JobID = MainConstants.Job.MainCalc,
                Name = "PayRunID",
                Display = "Pay Run ID",
                DefaultValue = "1",
                DataType = InputDataTypeConstants.SmallInt,
                IsRequired = true,
                Order = 2
            });

            builder.HasData(new JobParameter
            {
                ClientID = ClientConstant.Default,
                JobID = MainConstants.Job.MainCalc,
                Name = "PersonID",
                Display = "Person ID",
                DefaultValue = null,
                DataType = InputDataTypeConstants.Int,
                IsRequired = false,
                Order = 3
            });

            builder.HasData(new JobParameter
            {
                ClientID = ClientConstant.Default,
                JobID = MainConstants.Job.MainCalc,
                Name = "SpecialGroupID",
                Display = "Special Group ID",
                DefaultValue = null,
                DataType = InputDataTypeConstants.Int,
                Order = 100
            });


            builder.HasData(new JobParameter
            {
                ClientID = ClientConstant.Default,
                JobID = 404,
                Name = "EmployeeID",
                Display = "Employee ID",
                DataType = InputDataTypeConstants.Int,
                IsRequired = true
            });


            builder.HasData(new JobParameter
            {
                ClientID = ClientConstant.Default,
                JobID = 700,
                Name = "Path",
                Display = "File Path",
                DataType = InputDataTypeConstants.String,
                IsRequired = true,
                DefaultValue = @"D:\Git Workspace\Personal\Aerish\Docs\Sample Imports"
            });
        }
    }
}
