using Aerish.Constants;
using Aerish.Domain.Entities.Parameters;
using Aerish.Infrastructure.Constants;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerish.Infrastructure.Persistence.Configurations
{
    public partial class TableRange_Configuration
    {
        protected override string Schema => SchemaConstant.Parameter;

        protected override void KeyBuilder(BaseKeyBuilder<TableRange> builder)
        {
            builder.HasKey(a => new
            {
                a.TableRangeID,
                a.TableID,
                a.Code
            });
        }

        protected override void ConfigureProperty(BasePropertyBuilder<TableRange> builder)
        {
            builder.Property(p => p.Code)
               .IsRequired()
               .HasMaxLength(StringLengthConstant.ShortDesc);

            builder.Property(a => a.AmountBasis)
                .HasConversion<string>()
                .IsRequired()
                .HasMaxLength(StringLengthConstant.Enums);

            builder.Property(a => a.EmployeeFormula)
                .HasMaxLength(255);

            builder.Property(a => a.EmployerFormula)
                .HasMaxLength(255);
        }

        protected override void ConfigureRelationship(BaseRelationshipBuilder<TableRange> builder)
        {
            builder.HasOne<Table>()
                .WithMany(a => a.N_Ranges)
                .HasForeignKey(a => new
                {
                    a.TableID,
                    a.Code
                });
        }

        protected override void SeedData(BaseSeeder<TableRange> builder)
        {
            #region TaxTable
            #region Daily
            builder.HasData(new TableRange
            {

                TableID = 1,
                Code = TableCodeConstants.TaxTable,
                TableRangeID = 1,
                AmountBasis = AmountBasis.Daily,
                Min = 0.0000001m,
                Max = 685,
                Rate = 0,
                Fixed = 0
            });

            builder.HasData(new TableRange
            {
                TableID = 1,
                Code = TableCodeConstants.TaxTable,
                TableRangeID = 2,
                AmountBasis = AmountBasis.Daily,
                Min = 685.000001m,
                Max = 1095,
                Rate = 0.2m,
                Fixed = 0
            });

            builder.HasData(new TableRange
            {

                TableID = 1,
                Code = TableCodeConstants.TaxTable,
                TableRangeID = 3,
                AmountBasis = AmountBasis.Daily,
                Min = 685.000001m,
                Max = 1095,
                Rate = 0.2m,
                Fixed = 0
            });

            builder.HasData(new TableRange
            {

                TableID = 1,
                Code = TableCodeConstants.TaxTable,
                TableRangeID = 4,
                AmountBasis = AmountBasis.Daily,
                Min = 685.000001m,
                Max = 1095,
                Rate = 0.2m,
                Fixed = 0
            });

            builder.HasData(new TableRange
            {

                TableID = 1,
                Code = TableCodeConstants.TaxTable,
                TableRangeID = 5,
                AmountBasis = AmountBasis.Daily,
                Min = 685.000001m,
                Max = 1095,
                Rate = 0.2m,
                Fixed = 0
            });

            builder.HasData(new TableRange
            {

                TableID = 1,
                Code = TableCodeConstants.TaxTable,
                TableRangeID = 6,
                AmountBasis = AmountBasis.Daily,
                Min = 685.000001m,
                Max = 1095,
                Rate = 0.2m,
                Fixed = 0
            });
            #endregion

            #region Weekly
            builder.HasData(new TableRange
            {

                TableID = 1,
                Code = TableCodeConstants.TaxTable,
                TableRangeID = 7,
                AmountBasis = AmountBasis.Weekly,
                Min = 0.0000001m,
                Max = 685,
                Rate = 0,
                Fixed = 0
            });

            builder.HasData(new TableRange
            {

                TableID = 1,
                Code = TableCodeConstants.TaxTable,
                TableRangeID = 8,
                AmountBasis = AmountBasis.Weekly,
                Min = 685.000001m,
                Max = 1095,
                Rate = 0.2m,
                Fixed = 0
            });

            builder.HasData(new TableRange
            {

                TableID = 1,
                Code = TableCodeConstants.TaxTable,
                TableRangeID = 9,
                AmountBasis = AmountBasis.Weekly,
                Min = 685.000001m,
                Max = 1095,
                Rate = 0.2m,
                Fixed = 0
            });

            builder.HasData(new TableRange
            {

                TableID = 1,
                Code = TableCodeConstants.TaxTable,
                TableRangeID = 10,
                AmountBasis = AmountBasis.Weekly,
                Min = 685.000001m,
                Max = 1095,
                Rate = 0.2m,
                Fixed = 0
            });

            builder.HasData(new TableRange
            {

                TableID = 1,
                Code = TableCodeConstants.TaxTable,
                TableRangeID = 11,
                AmountBasis = AmountBasis.Weekly,
                Min = 685.000001m,
                Max = 1095,
                Rate = 0.2m,
                Fixed = 0
            });

            builder.HasData(new TableRange
            {

                TableID = 1,
                Code = TableCodeConstants.TaxTable,
                TableRangeID = 12,
                AmountBasis = AmountBasis.Weekly,
                Min = 685.000001m,
                Max = 1095,
                Rate = 0.2m,
                Fixed = 0
            });
            #endregion

            #region Semi-Monthly
            builder.HasData(new TableRange
            {

                TableID = 1,
                Code = TableCodeConstants.TaxTable,
                TableRangeID = 13,
                AmountBasis = AmountBasis.SemiMontly,
                Min = 0.0000001m,
                Max = 685,
                Rate = 0,
                Fixed = 0
            });

            builder.HasData(new TableRange
            {

                TableID = 1,
                Code = TableCodeConstants.TaxTable,
                TableRangeID = 14,
                AmountBasis = AmountBasis.SemiMontly,
                Min = 685.000001m,
                Max = 1095,
                Rate = 0.2m,
                Fixed = 0
            });

            builder.HasData(new TableRange
            {

                TableID = 1,
                Code = TableCodeConstants.TaxTable,
                TableRangeID = 15,
                AmountBasis = AmountBasis.SemiMontly,
                Min = 685.000001m,
                Max = 1095,
                Rate = 0.2m,
                Fixed = 0
            });

            builder.HasData(new TableRange
            {

                TableID = 1,
                Code = TableCodeConstants.TaxTable,
                TableRangeID = 16,
                AmountBasis = AmountBasis.SemiMontly,
                Min = 685.000001m,
                Max = 1095,
                Rate = 0.2m,
                Fixed = 0
            });

            builder.HasData(new TableRange
            {

                TableID = 1,
                Code = TableCodeConstants.TaxTable,
                TableRangeID = 17,
                AmountBasis = AmountBasis.SemiMontly,
                Min = 685.000001m,
                Max = 1095,
                Rate = 0.2m,
                Fixed = 0
            });

            builder.HasData(new TableRange
            {

                TableID = 1,
                Code = TableCodeConstants.TaxTable,
                TableRangeID = 18,
                AmountBasis = AmountBasis.SemiMontly,
                Min = 685.000001m,
                Max = 1095,
                Rate = 0.2m,
                Fixed = 0
            });
            #endregion

            #region Monthly
            builder.HasData(new TableRange
            {

                TableID = 1,
                Code = TableCodeConstants.TaxTable,
                TableRangeID = 19,
                AmountBasis = AmountBasis.Monthly,
                Min = 0.0000001m,
                Max = 20833,
                Rate = 0,
                Fixed = 0
            });

            builder.HasData(new TableRange
            {

                TableID = 1,
                Code = TableCodeConstants.TaxTable,
                TableRangeID = 20,
                AmountBasis = AmountBasis.Monthly,
                Min = 20833.000001m,
                Max = 33332,
                Rate = 0.2m,
                Fixed = 0
            });

            builder.HasData(new TableRange
            {

                TableID = 1,
                Code = TableCodeConstants.TaxTable,
                TableRangeID = 21,
                AmountBasis = AmountBasis.Monthly,
                Min = 33332.000001m,
                Max = 66666,
                Rate = 0.2m,
                Fixed = 2500
            });

            builder.HasData(new TableRange
            {

                TableID = 1,
                Code = TableCodeConstants.TaxTable,
                TableRangeID = 22,
                AmountBasis = AmountBasis.Monthly,
                Min = 66667,
                Max = 166666.9999999m,
                Rate = 0.3m,
                Fixed = 10833.33m
            });

            builder.HasData(new TableRange
            {

                TableID = 1,
                Code = TableCodeConstants.TaxTable,
                TableRangeID = 23,
                AmountBasis = AmountBasis.Monthly,
                Min = 166666m,
                Max = 666666.999999m,
                Rate = 0.32m,
                Fixed = 40833.33m
            });

            builder.HasData(new TableRange
            {

                TableID = 1,
                Code = TableCodeConstants.TaxTable,
                TableRangeID = 24,
                AmountBasis = AmountBasis.Monthly,
                Min = 666667m,
                Max = 999999999,
                Rate = 0.35m,
                Fixed = 200833.33m
            });
            #endregion
            #endregion

            #region PHIC 2020
            builder.HasData(new TableRange
            {

                TableID = 2,
                Code = TableCodeConstants.PhilHealth,
                TableRangeID = 25,
                AmountBasis = AmountBasis.Monthly,
                Min = 0.0001m,
                Max = 10000,
                Fixed = 275,
                EmployeeFormula = "{Fixed} / 2",
                EmployerFormula = "{Fixed} / 2"
            });

            builder.HasData(new TableRange
            {

                TableID = 2,
                Code = TableCodeConstants.PhilHealth,
                TableRangeID = 26,
                AmountBasis = AmountBasis.Monthly,
                Min = 10000.01m,
                Max = 59999.99m,
                Rate = 0.03m,
                EmployeeFormula = "({MonthlyBasicPay} * {Rate}) / 2",
                EmployerFormula = "({MonthlyBasicPay} * {Rate}) / 2"
            });

            builder.HasData(new TableRange
            {

                TableID = 2,
                Code = TableCodeConstants.PhilHealth,
                TableRangeID = 27,
                AmountBasis = AmountBasis.Monthly,
                Min = 60000,
                Max = 99999999.99m,
                Fixed = 1800,
                EmployeeFormula = "{Fixed} / 2",
                EmployerFormula = "{Fixed} / 2"
            });
            #endregion

            #region PHIC 2021
            builder.HasData(new TableRange
            {

                TableID = 3,
                Code = TableCodeConstants.PhilHealth,
                TableRangeID = 28,
                AmountBasis = AmountBasis.Monthly,
                Min = 0.0001m,
                Max = 10000,
                Fixed = 350,
                EmployeeFormula = "{Fixed} / 2",
                EmployerFormula = "{Fixed} / 2"
            });

            builder.HasData(new TableRange
            {

                TableID = 3,
                Code = TableCodeConstants.PhilHealth,
                TableRangeID = 29,
                AmountBasis = AmountBasis.Monthly,
                Min = 10000.01m,
                Max = 69999.99m,
                Rate = 0.035m,
                EmployeeFormula = "({MonthlyBasicPay} * {Rate}) / 2",
                EmployerFormula = "({MonthlyBasicPay} * {Rate}) / 2"
            });

            builder.HasData(new TableRange
            {

                TableID = 3,
                Code = TableCodeConstants.PhilHealth,
                TableRangeID = 30,
                AmountBasis = AmountBasis.Monthly,
                Min = 70000,
                Max = 99999999.99m,
                Fixed = 2450,
                EmployeeFormula = "{Fixed} / 2",
                EmployerFormula = "{Fixed} / 2"
            });
            #endregion

            #region SSS 2021
            builder.HasData(new TableRange
            {

                TableID = 4,
                Code = TableCodeConstants.SSS,
                TableRangeID = 31,
                AmountBasis = AmountBasis.Monthly,
                Min = 0.0001m,
                Max = 3250,
                Fixed = 3000,
                EmployeeFormula = "135.00",
                EmployerFormula = "255.00"
            });
            builder.HasData(new TableRange
            {

                TableID = 4,
                Code = TableCodeConstants.SSS,
                TableRangeID = 32,
                AmountBasis = AmountBasis.Monthly,
                Min = 24750m,
                Max = 9999999999m,
                Fixed = 20000,
                EmployeeFormula = "1700.00",
                EmployerFormula = "900.00"
            });
            #endregion
        }
    }
}