using Aerish.Constants;
using Aerish.Domain.Entities.Common;
using Aerish.Infrastructure.Constants;

namespace Aerish.Infrastructure.Persistence.Configurations
{
    public partial class Client_Configuration
    {
        protected override string Schema => SchemaConstant.CommonDataModel;

        protected override void KeyBuilder(BaseKeyBuilder<Client> builder)
        {
            builder.HasKey(a => a.ClientID);
        }

        protected override void ConfigureProperty(BasePropertyBuilder<Client> builder)
        {
            builder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(200);
        }

        protected override void SeedData(BaseSeeder<Client> builder)
        {
            builder.HasData(new Client
            {
                ClientID = ClientConstant.Default,
                Name = "Aerish Inc."
            });
        }
    }
}
