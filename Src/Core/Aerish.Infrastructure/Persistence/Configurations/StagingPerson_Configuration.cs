using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aerish.Constants;
using Aerish.Domain.Entities.Staging;
using Aerish.Infrastructure.Constants;

namespace Aerish.Infrastructure.Persistence.Configurations
{
    public partial class StagingPerson_Configuration
    {
        protected override string Schema => SchemaConstant.Staging;

        protected override void KeyBuilder(BaseKeyBuilder<StagingPerson> builder)
        {
            builder.HasKey(a => a.ID);
        }

        protected override void ConfigureProperty(BasePropertyBuilder<StagingPerson> builder)
        {
            builder.Property(a => a.EmployeeSysID)
                .IsRequired()
                .HasMaxLength(20);
        }

        protected override void ConfigureRelationship(BaseRelationshipBuilder<StagingPerson> builder)
        {
            builder.HasOne(a => a.N_JobInstance)
                .WithMany()
                .HasForeignKey(a => a.ProcessInstanceID);
        }
    }
}
