using Aerish.Domain.Entities.Common;

namespace Aerish.Infrastructure.Persistence.Configurations
{
    public partial class ProcessInstanceError_Configuration
    {
        protected override void KeyBuilder(BaseKeyBuilder<ProcessInstanceError> builder)
        {
            builder.HasKey(a => a.JobErrorID);
        }

        protected override void ConfigureProperty(BasePropertyBuilder<ProcessInstanceError> builder)
        {
            builder.Property(a => a.ErrorType)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(a => a.Message)
                .IsRequired();

            builder.Property(a => a.StackTrace)
                .IsRequired();
        }

        protected override void ConfigureRelationship(BaseRelationshipBuilder<ProcessInstanceError> builder)
        {
            builder.HasOne<ProcessInstance>()
                .WithMany(a => a.N_InstanceErrors)
                .HasForeignKey(a => a.ProcessInstanceID);
        }
    }
}
