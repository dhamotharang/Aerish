using Aerish.Domain.Entities.Common;

namespace Aerish.Infrastructure.Persistence.Configurations
{
    public partial class ProcessInstance_Configuration
    {
        protected override void KeyBuilder(BaseKeyBuilder<ProcessInstance> builder)
        {
            builder.HasKey(a => a.ProcessInstanceID);
        }

        protected override void ConfigureRelationship(BaseRelationshipBuilder<ProcessInstance> builder)
        {
            builder.HasOne(a => a.N_Job)
                .WithMany()
                .HasForeignKey(a => new
                {
                    a.ClientID,
                    a.JobID
                });
        }
    }
}
