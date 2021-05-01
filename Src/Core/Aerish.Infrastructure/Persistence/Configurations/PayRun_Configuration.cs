using Aerish.Constants;
using Aerish.Domain.Entities.Common;
using Aerish.Domain.Entities.Parameters;
using Aerish.Infrastructure.Constants;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerish.Infrastructure.Persistence.Configurations
{
    public partial class PayRun_Configuration
    {
        protected override string Schema => SchemaConstant.Parameter;

        protected override void KeyBuilder(BaseKeyBuilder<PayRun> builder)
        {
            builder.HasKey(a => new
            {
                a.ClientID,
                a.PayRunID,
                a.PlanYear
            });
        }

        protected override void ConfigureRelationship(BaseRelationshipBuilder<PayRun> builder)
        {
            builder.HasOne(a => a.N_PlanYear)
                .WithMany()
                .HasForeignKey(a => a.PlanYear);

            builder.HasOne<Client>()
                .WithMany()
                .HasForeignKey(a => a.ClientID);
        }

        protected override void SeedData(BaseSeeder<PayRun> builder)
        {
            #region 2021
            builder.HasData(new PayRun
            {
                ClientID = ClientConstant.Default,
                PlanYear = 2021,
                PayRunID = 1,
                PayoutDate = new DateTime(2021, 1, 16),
                CutOffStart = new DateTime(2020, 12, 1),
                CutOffEnd = new DateTime(2020, 12, 31),
                PeriodStart = new DateTime(2021, 1, 1),
                PeriodEnd = new DateTime(2021, 1, 31)
            });

            builder.HasData(new PayRun
            {
                ClientID = ClientConstant.Default,
                PlanYear = 2021,
                PayRunID = 2,
                PayoutDate = new DateTime(2021, 2, 16),
                CutOffStart = new DateTime(2021, 1, 1),
                CutOffEnd = new DateTime(2021, 1, 31),
                PeriodStart = new DateTime(2021, 2, 1),
                PeriodEnd = new DateTime(2021, 2, 28)
            });
            #endregion
        }
    }
}