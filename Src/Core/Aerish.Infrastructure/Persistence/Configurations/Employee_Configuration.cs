using Aerish.Constants;
using Aerish.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aerish.Infrastructure.Persistence.Configurations
{
    public partial class Employee_Configuration
    {
        protected override void KeyBuilder(BaseKeyBuilder<Employee> builder)
        {
            builder.HasKey(a => new
            {
                a.EmployeeID,
                a.ClientID
            });
        }

        protected override void ConfigureRelationship(BaseRelationshipBuilder<Employee> builder)
        {
            builder.HasOne(a => a.N_Person)
                .WithMany()
                .HasForeignKey(a => a.EmployeeID);

            builder.HasOne(a => a.N_Client)
                .WithMany()
                .HasForeignKey(a => a.ClientID);
        }

        protected override void ConfigureIndex(BaseIndexBuilder<Employee> builder)
        {
            builder.HasIndex(a => new
                {
                    a.ClientID,
                    a.Code,
                    a.EmployeeID
                })
                .IsUnique(true);
        }
    }
}
