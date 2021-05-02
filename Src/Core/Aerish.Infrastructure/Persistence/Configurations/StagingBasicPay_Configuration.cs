using System;
using System.Collections.Generic;
using System.Text;

using Aerish.Application.Common.Entities.Staging;
using Aerish.Infrastructure.Constants;

namespace Aerish.Infrastructure.Persistence.Configurations
{
    public partial class StagingBasicPay_Configuration
    {
        protected override string Schema => SchemaConstant.Staging;

        protected override void KeyBuilder(BaseKeyBuilder<StagingBasicPay> builder)
        {
            builder.HasKey(a => a.ID);
        }

        protected override void ConfigureProperty(BasePropertyBuilder<StagingBasicPay> builder)
        {
            builder.Property(a => a.EmployeeSysID)
                .IsRequired()
                .HasMaxLength(20);
        }

        protected override void ConfigureRelationship(BaseRelationshipBuilder<StagingBasicPay> builder)
        {
            builder.HasOne(a => a.N_JobInstance)
                .WithMany()
                .HasForeignKey(a => a.ProcessInstanceID);
        }
    }
}
