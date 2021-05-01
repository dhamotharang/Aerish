using Aerish.Domain.Entities.Common;

namespace Aerish.Infrastructure.Persistence.Configurations
{
    public partial class ProcessInstanceMessage_Configuration
    {
        protected override void KeyBuilder(BaseKeyBuilder<ProcessInstanceMessage> builder)
        {
            builder.HasKey(a => a.JobMessageID);
        }

        protected override void ConfigureProperty(BasePropertyBuilder<ProcessInstanceMessage> builder)
        {
            builder.Property(a => a.Message)
                .IsRequired();
        }

        protected override void ConfigureRelationship(BaseRelationshipBuilder<ProcessInstanceMessage> builder)
        {
            builder.HasOne<ProcessInstance>()
                .WithMany(a => a.N_InstanceMessages)
                .HasForeignKey(a => a.ProcessInstanceID);
        }
    }
}
