using Aerish.Domain.Entities.Common;

namespace Aerish.Infrastructure.Persistence.Configurations
{
    public partial class ProcessInstanceParameter_Configuration
    {
        protected override void KeyBuilder(BaseKeyBuilder<ProcessInstanceParameter> builder)
        {
            builder.HasKey(a => a.ProcessInstanceParameterID);
        }

        protected override void ConfigureRelationship(BaseRelationshipBuilder<ProcessInstanceParameter> builder)
        {
            builder.HasOne<ProcessInstance>()
                .WithMany(a => a.N_InstanceParameters)
                .HasForeignKey(a => a.ProcessInstanceID);
        }
    }
}
