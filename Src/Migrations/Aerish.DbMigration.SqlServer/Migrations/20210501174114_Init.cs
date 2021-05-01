using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aerish.DbMigration.SqlServer.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.EnsureSchema(
                name: "pr");

            migrationBuilder.EnsureSchema(
                name: "cdm");

            migrationBuilder.EnsureSchema(
                name: "cd");

            migrationBuilder.EnsureSchema(
                name: "stg");

            migrationBuilder.CreateTable(
                name: "tbl_Bank",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Bank", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_BatchFile",
                schema: "dbo",
                columns: table => new
                {
                    FileID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_BatchFile", x => x.FileID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Client",
                schema: "cdm",
                columns: table => new
                {
                    ClientID = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Client", x => x.ClientID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_DeductionType",
                schema: "dbo",
                columns: table => new
                {
                    DeductionTypeID = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShortDesc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LongDesc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AltDesc = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_DeductionType", x => x.DeductionTypeID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_EarningType",
                schema: "dbo",
                columns: table => new
                {
                    EarningTypeID = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShortDesc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LongDesc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AltDesc = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_EarningType", x => x.EarningTypeID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Event",
                schema: "pr",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventCode = table.Column<short>(type: "smallint", nullable: false),
                    ShortDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LongDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AltDesc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Event", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_LoanType",
                schema: "dbo",
                columns: table => new
                {
                    LoanTypeID = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShortDesc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LongDesc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AltDesc = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_LoanType", x => x.LoanTypeID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Lookup",
                schema: "dbo",
                columns: table => new
                {
                    Type = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ShortDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LongDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AltDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Lookup", x => new { x.Type, x.Code });
                });

            migrationBuilder.CreateTable(
                name: "tbl_OTRateType",
                schema: "pr",
                columns: table => new
                {
                    OTRateTypeID = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShortDesc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LongDesc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AltDesc = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_OTRateType", x => x.OTRateTypeID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_PaymentMode",
                schema: "pr",
                columns: table => new
                {
                    PaymentModeID = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShortDesc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LongDesc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AltDesc = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_PaymentMode", x => x.PaymentModeID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Person",
                schema: "cdm",
                columns: table => new
                {
                    PersonID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeSysID = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TaxIdNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Person", x => x.PersonID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_PlanYear",
                schema: "pr",
                columns: table => new
                {
                    Year = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EffectivityStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EffectivityEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_PlanYear", x => x.Year);
                });

            migrationBuilder.CreateTable(
                name: "tbl_SpecialGroup",
                schema: "cd",
                columns: table => new
                {
                    GroupID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_SpecialGroup", x => x.GroupID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Table",
                schema: "pr",
                columns: table => new
                {
                    TableID = table.Column<short>(type: "smallint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ShortDesc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LongDesc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AltDesc = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Reference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EffectiveStartOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EffectiveEndOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Table", x => new { x.TableID, x.Code });
                });

            migrationBuilder.CreateTable(
                name: "tbl_TaskHandlerProvider",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    TaskAssembly = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    TaskClass = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    HandlerAssembly = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    HandlerClass = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_TaskHandlerProvider", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_ValidationFailure",
                schema: "stg",
                columns: table => new
                {
                    ValidationFailureID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RowIndex = table.Column<long>(type: "bigint", nullable: false),
                    ProcessInstanceID = table.Column<int>(type: "int", nullable: false),
                    PropertyName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ErrorMessage = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_ValidationFailure", x => x.ValidationFailureID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Batch",
                schema: "dbo",
                columns: table => new
                {
                    BatchID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileID = table.Column<int>(type: "int", nullable: true),
                    N_FileFileID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Batch", x => x.BatchID);
                    table.ForeignKey(
                        name: "FK_tbl_Batch_tbl_BatchFile_N_FileFileID",
                        column: x => x.N_FileFileID,
                        principalSchema: "dbo",
                        principalTable: "tbl_BatchFile",
                        principalColumn: "FileID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_OTRate",
                schema: "pr",
                columns: table => new
                {
                    OTRateID = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OTRateTypeID = table.Column<short>(type: "smallint", nullable: false),
                    Rate = table.Column<decimal>(type: "DECIMAL(20,6)", nullable: false),
                    ComputedBy = table.Column<byte>(type: "tinyint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_OTRate", x => x.OTRateID);
                    table.ForeignKey(
                        name: "FK_tbl_OTRate_tbl_OTRateType_OTRateTypeID",
                        column: x => x.OTRateTypeID,
                        principalSchema: "pr",
                        principalTable: "tbl_OTRateType",
                        principalColumn: "OTRateTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Period",
                schema: "pr",
                columns: table => new
                {
                    PeriodID = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentModeID = table.Column<short>(type: "smallint", nullable: false),
                    ShortDesc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LongDesc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AltDesc = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Order = table.Column<short>(type: "smallint", nullable: false),
                    IsEveryPayroll = table.Column<bool>(type: "bit", nullable: false),
                    IsNeedPayoutPlace = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Period", x => x.PeriodID);
                    table.ForeignKey(
                        name: "FK_tbl_Period_tbl_PaymentMode_PaymentModeID",
                        column: x => x.PaymentModeID,
                        principalSchema: "pr",
                        principalTable: "tbl_PaymentMode",
                        principalColumn: "PaymentModeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Employee",
                schema: "dbo",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    ClientID = table.Column<short>(type: "smallint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Employee", x => new { x.EmployeeID, x.ClientID });
                    table.ForeignKey(
                        name: "FK_tbl_Employee_tbl_Client_ClientID",
                        column: x => x.ClientID,
                        principalSchema: "cdm",
                        principalTable: "tbl_Client",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_Employee_tbl_Person_EmployeeID",
                        column: x => x.EmployeeID,
                        principalSchema: "cdm",
                        principalTable: "tbl_Person",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_PayRun",
                schema: "pr",
                columns: table => new
                {
                    ClientID = table.Column<short>(type: "smallint", nullable: false),
                    PlanYear = table.Column<short>(type: "smallint", nullable: false),
                    PayRunID = table.Column<short>(type: "smallint", nullable: false),
                    PeriodStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PeriodEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CutOffStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CutOffEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PayoutDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_PayRun", x => new { x.ClientID, x.PayRunID, x.PlanYear });
                    table.ForeignKey(
                        name: "FK_tbl_PayRun_tbl_Client_ClientID",
                        column: x => x.ClientID,
                        principalSchema: "cdm",
                        principalTable: "tbl_Client",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_PayRun_tbl_PlanYear_PlanYear",
                        column: x => x.PlanYear,
                        principalSchema: "pr",
                        principalTable: "tbl_PlanYear",
                        principalColumn: "Year",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_SpecialGroupMember",
                schema: "cd",
                columns: table => new
                {
                    GroupID = table.Column<int>(type: "int", nullable: false),
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_SpecialGroupMember", x => new { x.GroupID, x.EmployeeID });
                    table.ForeignKey(
                        name: "FK_tbl_SpecialGroupMember_tbl_SpecialGroup_GroupID",
                        column: x => x.GroupID,
                        principalSchema: "cd",
                        principalTable: "tbl_SpecialGroup",
                        principalColumn: "GroupID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_TableRange",
                schema: "pr",
                columns: table => new
                {
                    TableID = table.Column<short>(type: "smallint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TableRangeID = table.Column<short>(type: "smallint", nullable: false),
                    AmountBasis = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Min = table.Column<decimal>(type: "DECIMAL(20,6)", nullable: false),
                    Max = table.Column<decimal>(type: "DECIMAL(20,6)", nullable: false),
                    Rate = table.Column<decimal>(type: "DECIMAL(20,6)", nullable: true),
                    Fixed = table.Column<decimal>(type: "DECIMAL(20,6)", nullable: true),
                    Custom1 = table.Column<decimal>(type: "DECIMAL(20,6)", nullable: true),
                    Custom2 = table.Column<decimal>(type: "DECIMAL(20,6)", nullable: true),
                    Custom3 = table.Column<decimal>(type: "DECIMAL(20,6)", nullable: true),
                    Custom4 = table.Column<decimal>(type: "DECIMAL(20,6)", nullable: true),
                    Custom5 = table.Column<decimal>(type: "DECIMAL(20,6)", nullable: true),
                    EmployeeFormula = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    EmployerFormula = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_TableRange", x => new { x.TableRangeID, x.TableID, x.Code });
                    table.ForeignKey(
                        name: "FK_tbl_TableRange_tbl_Table_TableID_Code",
                        columns: x => new { x.TableID, x.Code },
                        principalSchema: "pr",
                        principalTable: "tbl_Table",
                        principalColumns: new[] { "TableID", "Code" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Deduction",
                schema: "dbo",
                columns: table => new
                {
                    DeductionID = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientID = table.Column<short>(type: "smallint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ShortDesc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LongDesc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AltDesc = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DeductionTypeID = table.Column<short>(type: "smallint", nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    IsExcludedInTax = table.Column<bool>(type: "bit", nullable: false),
                    TaskHandlerProviderID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Deduction", x => x.DeductionID);
                    table.ForeignKey(
                        name: "FK_tbl_Deduction_tbl_DeductionType_DeductionTypeID",
                        column: x => x.DeductionTypeID,
                        principalSchema: "dbo",
                        principalTable: "tbl_DeductionType",
                        principalColumn: "DeductionTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_Deduction_tbl_TaskHandlerProvider_TaskHandlerProviderID",
                        column: x => x.TaskHandlerProviderID,
                        principalSchema: "dbo",
                        principalTable: "tbl_TaskHandlerProvider",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Earning",
                schema: "dbo",
                columns: table => new
                {
                    EarningID = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientID = table.Column<short>(type: "smallint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ShortDesc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LongDesc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AltDesc = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    EarningTypeID = table.Column<short>(type: "smallint", nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    IsComputed = table.Column<bool>(type: "bit", nullable: false),
                    IsTaxable = table.Column<bool>(type: "bit", nullable: false),
                    IsReceivable = table.Column<bool>(type: "bit", nullable: false),
                    IsPartOfBasicPay = table.Column<bool>(type: "bit", nullable: false),
                    IsDeMinimis = table.Column<bool>(type: "bit", nullable: false),
                    IsAdjustIfAbsent = table.Column<bool>(type: "bit", nullable: false),
                    IsNegativeComputation = table.Column<bool>(type: "bit", nullable: false),
                    ComputedBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    TaskHandlerProviderID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Earning", x => x.EarningID);
                    table.ForeignKey(
                        name: "FK_tbl_Earning_tbl_EarningType_EarningTypeID",
                        column: x => x.EarningTypeID,
                        principalSchema: "dbo",
                        principalTable: "tbl_EarningType",
                        principalColumn: "EarningTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_Earning_tbl_TaskHandlerProvider_TaskHandlerProviderID",
                        column: x => x.TaskHandlerProviderID,
                        principalSchema: "dbo",
                        principalTable: "tbl_TaskHandlerProvider",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Job",
                schema: "dbo",
                columns: table => new
                {
                    ClientID = table.Column<short>(type: "smallint", nullable: false),
                    JobID = table.Column<short>(type: "smallint", nullable: false),
                    ShortDesc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LongDesc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AltDesc = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    TaskHandlerProviderID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Job", x => new { x.ClientID, x.JobID });
                    table.ForeignKey(
                        name: "FK_tbl_Job_tbl_TaskHandlerProvider_TaskHandlerProviderID",
                        column: x => x.TaskHandlerProviderID,
                        principalSchema: "dbo",
                        principalTable: "tbl_TaskHandlerProvider",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Loan",
                schema: "dbo",
                columns: table => new
                {
                    LoanID = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientID = table.Column<short>(type: "smallint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ShortDesc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LongDesc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AltDesc = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LoanTypeID = table.Column<short>(type: "smallint", nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    TaskHandlerProviderID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Loan", x => x.LoanID);
                    table.ForeignKey(
                        name: "FK_tbl_Loan_tbl_LoanType_LoanTypeID",
                        column: x => x.LoanTypeID,
                        principalSchema: "dbo",
                        principalTable: "tbl_LoanType",
                        principalColumn: "LoanTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_Loan_tbl_TaskHandlerProvider_TaskHandlerProviderID",
                        column: x => x.TaskHandlerProviderID,
                        principalSchema: "dbo",
                        principalTable: "tbl_TaskHandlerProvider",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_BasicPay",
                schema: "pr",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    ClientID = table.Column<short>(type: "smallint", nullable: false),
                    BasicPayID = table.Column<int>(type: "int", nullable: false),
                    PeriodStartID = table.Column<short>(type: "smallint", nullable: false),
                    PeriodEndID = table.Column<short>(type: "smallint", nullable: true),
                    Amount = table.Column<decimal>(type: "DECIMAL(20,6)", nullable: false),
                    AmountBasis = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Effectivity = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_BasicPay", x => new { x.BasicPayID, x.EmployeeID, x.ClientID });
                    table.ForeignKey(
                        name: "FK_tbl_BasicPay_tbl_Employee_EmployeeID_ClientID",
                        columns: x => new { x.EmployeeID, x.ClientID },
                        principalSchema: "dbo",
                        principalTable: "tbl_Employee",
                        principalColumns: new[] { "EmployeeID", "ClientID" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_BasicPay_tbl_Period_PeriodEndID",
                        column: x => x.PeriodEndID,
                        principalSchema: "pr",
                        principalTable: "tbl_Period",
                        principalColumn: "PeriodID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_BasicPay_tbl_Period_PeriodStartID",
                        column: x => x.PeriodStartID,
                        principalSchema: "pr",
                        principalTable: "tbl_Period",
                        principalColumn: "PeriodID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_EmployeeOvertime",
                schema: "pr",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    PlanYear = table.Column<short>(type: "smallint", nullable: false),
                    EmployeeOvertimeID = table.Column<int>(type: "int", nullable: false),
                    OTRateID = table.Column<short>(type: "smallint", nullable: false),
                    Hours = table.Column<decimal>(type: "DECIMAL(20,6)", nullable: false),
                    ClientID = table.Column<short>(type: "smallint", nullable: false),
                    PayRunID = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_EmployeeOvertime", x => new { x.EmployeeOvertimeID, x.PlanYear, x.EmployeeID, x.OTRateID });
                    table.ForeignKey(
                        name: "FK_tbl_EmployeeOvertime_tbl_Employee_EmployeeID_ClientID",
                        columns: x => new { x.EmployeeID, x.ClientID },
                        principalSchema: "dbo",
                        principalTable: "tbl_Employee",
                        principalColumns: new[] { "EmployeeID", "ClientID" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_EmployeeOvertime_tbl_OTRate_OTRateID",
                        column: x => x.OTRateID,
                        principalSchema: "pr",
                        principalTable: "tbl_OTRate",
                        principalColumn: "OTRateID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_EmployeeOvertime_tbl_PayRun_ClientID_PayRunID_PlanYear",
                        columns: x => new { x.ClientID, x.PayRunID, x.PlanYear },
                        principalSchema: "pr",
                        principalTable: "tbl_PayRun",
                        principalColumns: new[] { "ClientID", "PayRunID", "PlanYear" });
                });

            migrationBuilder.CreateTable(
                name: "tbl_MasterEmployee",
                schema: "cd",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    ClientID = table.Column<short>(type: "smallint", nullable: false),
                    CalcID = table.Column<short>(type: "smallint", nullable: false),
                    PlanYear = table.Column<short>(type: "smallint", nullable: false),
                    PayRunID = table.Column<short>(type: "smallint", nullable: false),
                    RecordStatus = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DaysFactor = table.Column<decimal>(type: "DECIMAL(20,6)", nullable: true),
                    HourlyRate = table.Column<decimal>(type: "DECIMAL(20,6)", nullable: true),
                    DailyRate = table.Column<decimal>(type: "DECIMAL(20,6)", nullable: true),
                    MonthlyRate = table.Column<decimal>(type: "DECIMAL(20,6)", nullable: true),
                    BasicPayBasis = table.Column<byte>(type: "tinyint", nullable: true),
                    TotalTaxableIncome = table.Column<decimal>(type: "DECIMAL(20,6)", nullable: true),
                    TotalNonTaxableIncome = table.Column<decimal>(type: "DECIMAL(20,6)", nullable: true),
                    NetTaxableIncome = table.Column<decimal>(type: "DECIMAL(20,6)", nullable: true),
                    WitholdingTax = table.Column<decimal>(type: "DECIMAL(20,6)", nullable: true),
                    TotalDeduction = table.Column<decimal>(type: "DECIMAL(20,6)", nullable: true),
                    NetSalary = table.Column<decimal>(type: "DECIMAL(20,6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_MasterEmployee", x => new { x.EmployeeID, x.ClientID, x.CalcID, x.PlanYear, x.PayRunID });
                    table.ForeignKey(
                        name: "FK_tbl_MasterEmployee_tbl_Employee_EmployeeID_ClientID",
                        columns: x => new { x.EmployeeID, x.ClientID },
                        principalSchema: "dbo",
                        principalTable: "tbl_Employee",
                        principalColumns: new[] { "EmployeeID", "ClientID" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_MasterEmployee_tbl_PayRun_ClientID_PayRunID_PlanYear",
                        columns: x => new { x.ClientID, x.PayRunID, x.PlanYear },
                        principalSchema: "pr",
                        principalTable: "tbl_PayRun",
                        principalColumns: new[] { "ClientID", "PayRunID", "PlanYear" });
                });

            migrationBuilder.CreateTable(
                name: "tbl_EmployeeDeductionRef",
                schema: "pr",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    ClientID = table.Column<short>(type: "smallint", nullable: false),
                    EmployeeDeductionRefID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeductionID = table.Column<short>(type: "smallint", nullable: false),
                    OvrdShortDesc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OvrdLongDesc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    OvrdAltDesc = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_EmployeeDeductionRef", x => new { x.ClientID, x.EmployeeDeductionRefID, x.EmployeeID, x.DeductionID });
                    table.ForeignKey(
                        name: "FK_tbl_EmployeeDeductionRef_tbl_Deduction_DeductionID",
                        column: x => x.DeductionID,
                        principalSchema: "dbo",
                        principalTable: "tbl_Deduction",
                        principalColumn: "DeductionID");
                    table.ForeignKey(
                        name: "FK_tbl_EmployeeDeductionRef_tbl_Employee_EmployeeID_ClientID",
                        columns: x => new { x.EmployeeID, x.ClientID },
                        principalSchema: "dbo",
                        principalTable: "tbl_Employee",
                        principalColumns: new[] { "EmployeeID", "ClientID" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_EmployeeEarningRef",
                schema: "pr",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    ClientID = table.Column<short>(type: "smallint", nullable: false),
                    EmployeeEarningRefID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EarningID = table.Column<short>(type: "smallint", nullable: false),
                    OvrdShortDesc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OvrdLongDesc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    OvrdAltDesc = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_EmployeeEarningRef", x => new { x.ClientID, x.EmployeeEarningRefID, x.EmployeeID, x.EarningID });
                    table.ForeignKey(
                        name: "FK_tbl_EmployeeEarningRef_tbl_Earning_EarningID",
                        column: x => x.EarningID,
                        principalSchema: "dbo",
                        principalTable: "tbl_Earning",
                        principalColumn: "EarningID");
                    table.ForeignKey(
                        name: "FK_tbl_EmployeeEarningRef_tbl_Employee_EmployeeID_ClientID",
                        columns: x => new { x.EmployeeID, x.ClientID },
                        principalSchema: "dbo",
                        principalTable: "tbl_Employee",
                        principalColumns: new[] { "EmployeeID", "ClientID" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_JobParameter",
                schema: "dbo",
                columns: table => new
                {
                    ClientID = table.Column<short>(type: "smallint", nullable: false),
                    JobID = table.Column<short>(type: "smallint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Display = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    DefaultValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MaxLength = table.Column<int>(type: "int", nullable: true),
                    IsRequired = table.Column<bool>(type: "bit", nullable: false),
                    Order = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_JobParameter", x => new { x.ClientID, x.JobID, x.Name });
                    table.ForeignKey(
                        name: "FK_tbl_JobParameter_tbl_Job_ClientID_JobID",
                        columns: x => new { x.ClientID, x.JobID },
                        principalSchema: "dbo",
                        principalTable: "tbl_Job",
                        principalColumns: new[] { "ClientID", "JobID" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_ProcessInstance",
                schema: "dbo",
                columns: table => new
                {
                    ProcessInstanceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientID = table.Column<short>(type: "smallint", nullable: false),
                    JobID = table.Column<short>(type: "smallint", nullable: false),
                    JobStatus = table.Column<byte>(type: "tinyint", nullable: false),
                    StartedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_ProcessInstance", x => x.ProcessInstanceID);
                    table.ForeignKey(
                        name: "FK_tbl_ProcessInstance_tbl_Job_ClientID_JobID",
                        columns: x => new { x.ClientID, x.JobID },
                        principalSchema: "dbo",
                        principalTable: "tbl_Job",
                        principalColumns: new[] { "ClientID", "JobID" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_EmployeeLoanRef",
                schema: "pr",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    ClientID = table.Column<short>(type: "smallint", nullable: false),
                    EmployeeLoanRefID = table.Column<int>(type: "int", nullable: false),
                    LoanID = table.Column<short>(type: "smallint", nullable: false),
                    OvrdShortDesc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OvrdLongDesc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    OvrdAltDesc = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    GrantedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PrincipalAmount = table.Column<decimal>(type: "DECIMAL(20,6)", nullable: false),
                    Interest = table.Column<decimal>(type: "DECIMAL(20,6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_EmployeeLoanRef", x => new { x.EmployeeLoanRefID, x.EmployeeID, x.ClientID, x.LoanID });
                    table.ForeignKey(
                        name: "FK_tbl_EmployeeLoanRef_tbl_Employee_EmployeeID_ClientID",
                        columns: x => new { x.EmployeeID, x.ClientID },
                        principalSchema: "dbo",
                        principalTable: "tbl_Employee",
                        principalColumns: new[] { "EmployeeID", "ClientID" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_EmployeeLoanRef_tbl_Loan_LoanID",
                        column: x => x.LoanID,
                        principalSchema: "dbo",
                        principalTable: "tbl_Loan",
                        principalColumn: "LoanID");
                });

            migrationBuilder.CreateTable(
                name: "tbl_MasterEmployeeDeduction",
                schema: "cd",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    ClientID = table.Column<short>(type: "smallint", nullable: false),
                    CalcID = table.Column<short>(type: "smallint", nullable: false),
                    PlanYear = table.Column<short>(type: "smallint", nullable: false),
                    PayRunID = table.Column<short>(type: "smallint", nullable: false),
                    MasterEmployeeDeductionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeductionID = table.Column<short>(type: "smallint", nullable: false),
                    ShortDesc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LongDesc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AltDesc = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    EmployeeAmount = table.Column<decimal>(type: "DECIMAL(20,6)", nullable: false),
                    EmployerAmount = table.Column<decimal>(type: "DECIMAL(20,6)", nullable: false),
                    RecordStatus = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_MasterEmployeeDeduction", x => new { x.MasterEmployeeDeductionID, x.CalcID, x.PlanYear, x.PayRunID, x.EmployeeID, x.DeductionID, x.ClientID });
                    table.ForeignKey(
                        name: "FK_tbl_MasterEmployeeDeduction_tbl_Deduction_DeductionID",
                        column: x => x.DeductionID,
                        principalSchema: "dbo",
                        principalTable: "tbl_Deduction",
                        principalColumn: "DeductionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_MasterEmployeeDeduction_tbl_MasterEmployee_EmployeeID_ClientID_CalcID_PlanYear_PayRunID",
                        columns: x => new { x.EmployeeID, x.ClientID, x.CalcID, x.PlanYear, x.PayRunID },
                        principalSchema: "cd",
                        principalTable: "tbl_MasterEmployee",
                        principalColumns: new[] { "EmployeeID", "ClientID", "CalcID", "PlanYear", "PayRunID" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_MasterEmployeeDeduction_tbl_PayRun_ClientID_PayRunID_PlanYear",
                        columns: x => new { x.ClientID, x.PayRunID, x.PlanYear },
                        principalSchema: "pr",
                        principalTable: "tbl_PayRun",
                        principalColumns: new[] { "ClientID", "PayRunID", "PlanYear" });
                });

            migrationBuilder.CreateTable(
                name: "tbl_MasterEmployeeEarning",
                schema: "cd",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    ClientID = table.Column<short>(type: "smallint", nullable: false),
                    CalcID = table.Column<short>(type: "smallint", nullable: false),
                    PlanYear = table.Column<short>(type: "smallint", nullable: false),
                    PayRunID = table.Column<short>(type: "smallint", nullable: false),
                    MasterEmployeeEarningID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EarningID = table.Column<short>(type: "smallint", nullable: false),
                    ShortDesc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LongDesc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AltDesc = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IsComputed = table.Column<bool>(type: "bit", nullable: false),
                    IsTaxable = table.Column<bool>(type: "bit", nullable: false),
                    IsReceivable = table.Column<bool>(type: "bit", nullable: false),
                    IsPartOfBasicPay = table.Column<bool>(type: "bit", nullable: false),
                    IsDeMinimis = table.Column<bool>(type: "bit", nullable: false),
                    IsAdjustIfAbsent = table.Column<bool>(type: "bit", nullable: false),
                    IsNegativeComputation = table.Column<bool>(type: "bit", nullable: false),
                    AmountBasis = table.Column<byte>(type: "tinyint", nullable: false),
                    ComputedBy = table.Column<byte>(type: "tinyint", nullable: true),
                    ComputedByValue = table.Column<decimal>(type: "DECIMAL(20,6)", nullable: true),
                    Amount = table.Column<decimal>(type: "DECIMAL(20,6)", nullable: false),
                    RecordStatus = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_MasterEmployeeEarning", x => new { x.MasterEmployeeEarningID, x.CalcID, x.PlanYear, x.PayRunID, x.EmployeeID, x.EarningID, x.ClientID });
                    table.ForeignKey(
                        name: "FK_tbl_MasterEmployeeEarning_tbl_Earning_EarningID",
                        column: x => x.EarningID,
                        principalSchema: "dbo",
                        principalTable: "tbl_Earning",
                        principalColumn: "EarningID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_MasterEmployeeEarning_tbl_MasterEmployee_EmployeeID_ClientID_CalcID_PlanYear_PayRunID",
                        columns: x => new { x.EmployeeID, x.ClientID, x.CalcID, x.PlanYear, x.PayRunID },
                        principalSchema: "cd",
                        principalTable: "tbl_MasterEmployee",
                        principalColumns: new[] { "EmployeeID", "ClientID", "CalcID", "PlanYear", "PayRunID" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_MasterEmployeeEarning_tbl_PayRun_ClientID_PayRunID_PlanYear",
                        columns: x => new { x.ClientID, x.PayRunID, x.PlanYear },
                        principalSchema: "pr",
                        principalTable: "tbl_PayRun",
                        principalColumns: new[] { "ClientID", "PayRunID", "PlanYear" });
                });

            migrationBuilder.CreateTable(
                name: "tbl_MasterEmployeeLoan",
                schema: "cd",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    ClientID = table.Column<short>(type: "smallint", nullable: false),
                    CalcID = table.Column<short>(type: "smallint", nullable: false),
                    PlanYear = table.Column<short>(type: "smallint", nullable: false),
                    PayRunID = table.Column<short>(type: "smallint", nullable: false),
                    MasterEmployeeLoanID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoanID = table.Column<short>(type: "smallint", nullable: false),
                    ShortDesc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LongDesc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AltDesc = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Amount = table.Column<decimal>(type: "DECIMAL(20,6)", nullable: false),
                    RecordStatus = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_MasterEmployeeLoan", x => new { x.MasterEmployeeLoanID, x.CalcID, x.PlanYear, x.PayRunID, x.EmployeeID, x.LoanID, x.ClientID });
                    table.ForeignKey(
                        name: "FK_tbl_MasterEmployeeLoan_tbl_Loan_LoanID",
                        column: x => x.LoanID,
                        principalSchema: "dbo",
                        principalTable: "tbl_Loan",
                        principalColumn: "LoanID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_MasterEmployeeLoan_tbl_MasterEmployee_EmployeeID_ClientID_CalcID_PlanYear_PayRunID",
                        columns: x => new { x.EmployeeID, x.ClientID, x.CalcID, x.PlanYear, x.PayRunID },
                        principalSchema: "cd",
                        principalTable: "tbl_MasterEmployee",
                        principalColumns: new[] { "EmployeeID", "ClientID", "CalcID", "PlanYear", "PayRunID" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_MasterEmployeeLoan_tbl_PayRun_ClientID_PayRunID_PlanYear",
                        columns: x => new { x.ClientID, x.PayRunID, x.PlanYear },
                        principalSchema: "pr",
                        principalTable: "tbl_PayRun",
                        principalColumns: new[] { "ClientID", "PayRunID", "PlanYear" });
                });

            migrationBuilder.CreateTable(
                name: "tbl_EmployeeDeduction",
                schema: "pr",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    ClientID = table.Column<short>(type: "smallint", nullable: false),
                    EmployeeDeductionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeDeductionRefID = table.Column<int>(type: "int", nullable: false),
                    DeductionID = table.Column<short>(type: "smallint", nullable: false),
                    Amount = table.Column<decimal>(type: "DECIMAL(20,6)", nullable: false),
                    PlanYear = table.Column<short>(type: "smallint", nullable: false),
                    PayRunID = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_EmployeeDeduction", x => new { x.ClientID, x.EmployeeDeductionID, x.EmployeeID });
                    table.ForeignKey(
                        name: "FK_tbl_EmployeeDeduction_tbl_Deduction_DeductionID",
                        column: x => x.DeductionID,
                        principalSchema: "dbo",
                        principalTable: "tbl_Deduction",
                        principalColumn: "DeductionID");
                    table.ForeignKey(
                        name: "FK_tbl_EmployeeDeduction_tbl_EmployeeDeductionRef_ClientID_EmployeeDeductionRefID_EmployeeID_DeductionID",
                        columns: x => new { x.ClientID, x.EmployeeDeductionRefID, x.EmployeeID, x.DeductionID },
                        principalSchema: "pr",
                        principalTable: "tbl_EmployeeDeductionRef",
                        principalColumns: new[] { "ClientID", "EmployeeDeductionRefID", "EmployeeID", "DeductionID" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_EmployeeDeduction_tbl_PayRun_ClientID_PayRunID_PlanYear",
                        columns: x => new { x.ClientID, x.PayRunID, x.PlanYear },
                        principalSchema: "pr",
                        principalTable: "tbl_PayRun",
                        principalColumns: new[] { "ClientID", "PayRunID", "PlanYear" });
                });

            migrationBuilder.CreateTable(
                name: "tbl_EmployeeEarning",
                schema: "pr",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    ClientID = table.Column<short>(type: "smallint", nullable: false),
                    EmployeeEarningID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EarningID = table.Column<short>(type: "smallint", nullable: false),
                    EmployeeEarningRefID = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "DECIMAL(20,6)", nullable: false),
                    PlanYear = table.Column<short>(type: "smallint", nullable: false),
                    PayRunID = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_EmployeeEarning", x => new { x.ClientID, x.EmployeeEarningID, x.EmployeeID });
                    table.ForeignKey(
                        name: "FK_tbl_EmployeeEarning_tbl_Earning_EarningID",
                        column: x => x.EarningID,
                        principalSchema: "dbo",
                        principalTable: "tbl_Earning",
                        principalColumn: "EarningID");
                    table.ForeignKey(
                        name: "FK_tbl_EmployeeEarning_tbl_EmployeeEarningRef_ClientID_EmployeeEarningRefID_EmployeeID_EarningID",
                        columns: x => new { x.ClientID, x.EmployeeEarningRefID, x.EmployeeID, x.EarningID },
                        principalSchema: "pr",
                        principalTable: "tbl_EmployeeEarningRef",
                        principalColumns: new[] { "ClientID", "EmployeeEarningRefID", "EmployeeID", "EarningID" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_EmployeeEarning_tbl_PayRun_ClientID_PayRunID_PlanYear",
                        columns: x => new { x.ClientID, x.PayRunID, x.PlanYear },
                        principalSchema: "pr",
                        principalTable: "tbl_PayRun",
                        principalColumns: new[] { "ClientID", "PayRunID", "PlanYear" });
                });

            migrationBuilder.CreateTable(
                name: "tbl_ProcessInstanceError",
                schema: "dbo",
                columns: table => new
                {
                    JobErrorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProcessInstanceID = table.Column<int>(type: "int", nullable: false),
                    ErrorType = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StackTrace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_ProcessInstanceError", x => x.JobErrorID);
                    table.ForeignKey(
                        name: "FK_tbl_ProcessInstanceError_tbl_ProcessInstance_ProcessInstanceID",
                        column: x => x.ProcessInstanceID,
                        principalSchema: "dbo",
                        principalTable: "tbl_ProcessInstance",
                        principalColumn: "ProcessInstanceID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_ProcessInstanceMessage",
                schema: "dbo",
                columns: table => new
                {
                    JobMessageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProcessInstanceID = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_ProcessInstanceMessage", x => x.JobMessageID);
                    table.ForeignKey(
                        name: "FK_tbl_ProcessInstanceMessage_tbl_ProcessInstance_ProcessInstanceID",
                        column: x => x.ProcessInstanceID,
                        principalSchema: "dbo",
                        principalTable: "tbl_ProcessInstance",
                        principalColumn: "ProcessInstanceID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_ProcessInstanceParameter",
                schema: "dbo",
                columns: table => new
                {
                    ProcessInstanceParameterID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProcessInstanceID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_ProcessInstanceParameter", x => x.ProcessInstanceParameterID);
                    table.ForeignKey(
                        name: "FK_tbl_ProcessInstanceParameter_tbl_ProcessInstance_ProcessInstanceID",
                        column: x => x.ProcessInstanceID,
                        principalSchema: "dbo",
                        principalTable: "tbl_ProcessInstance",
                        principalColumn: "ProcessInstanceID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_StagingPerson",
                schema: "stg",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeSysID = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TaxIdNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Gender = table.Column<byte>(type: "tinyint", nullable: true),
                    LoadStatus = table.Column<byte>(type: "tinyint", nullable: false),
                    RowIndex = table.Column<int>(type: "int", nullable: false),
                    ImportIsValid = table.Column<bool>(type: "bit", nullable: false),
                    Err_ColumnIndex = table.Column<int>(type: "int", nullable: true),
                    Err_Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Err_UnmappedRow = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValidationIsValid = table.Column<bool>(type: "bit", nullable: false),
                    ProcessInstanceID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_StagingPerson", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tbl_StagingPerson_tbl_ProcessInstance_ProcessInstanceID",
                        column: x => x.ProcessInstanceID,
                        principalSchema: "dbo",
                        principalTable: "tbl_ProcessInstance",
                        principalColumn: "ProcessInstanceID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_EmployeeLoan",
                schema: "pr",
                columns: table => new
                {
                    EmployeeLoanID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoanID = table.Column<short>(type: "smallint", nullable: false),
                    EmployeeLoanRefID = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "DECIMAL(20,6)", nullable: false),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    ClientID = table.Column<short>(type: "smallint", nullable: false),
                    PlanYear = table.Column<short>(type: "smallint", nullable: false),
                    PayRunID = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_EmployeeLoan", x => x.EmployeeLoanID);
                    table.ForeignKey(
                        name: "FK_tbl_EmployeeLoan_tbl_EmployeeLoanRef_EmployeeLoanRefID_EmployeeID_ClientID_LoanID",
                        columns: x => new { x.EmployeeLoanRefID, x.EmployeeID, x.ClientID, x.LoanID },
                        principalSchema: "pr",
                        principalTable: "tbl_EmployeeLoanRef",
                        principalColumns: new[] { "EmployeeLoanRefID", "EmployeeID", "ClientID", "LoanID" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_EmployeeLoan_tbl_Loan_LoanID",
                        column: x => x.LoanID,
                        principalSchema: "dbo",
                        principalTable: "tbl_Loan",
                        principalColumn: "LoanID");
                    table.ForeignKey(
                        name: "FK_tbl_EmployeeLoan_tbl_PayRun_ClientID_PayRunID_PlanYear",
                        columns: x => new { x.ClientID, x.PayRunID, x.PlanYear },
                        principalSchema: "pr",
                        principalTable: "tbl_PayRun",
                        principalColumns: new[] { "ClientID", "PayRunID", "PlanYear" });
                });

            migrationBuilder.InsertData(
                schema: "cdm",
                table: "tbl_Client",
                columns: new[] { "ClientID", "Name" },
                values: new object[] { (short)1, "Aerish Inc." });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "tbl_DeductionType",
                columns: new[] { "DeductionTypeID", "AltDesc", "LongDesc", "ShortDesc" },
                values: new object[,]
                {
                    { (short)1, null, "Normal", "Normal" },
                    { (short)2, null, "Contribution", "Contribution" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "tbl_EarningType",
                columns: new[] { "EarningTypeID", "AltDesc", "LongDesc", "ShortDesc" },
                values: new object[,]
                {
                    { (short)1, null, "Basic Pay", "Basic Pay" },
                    { (short)2, null, "Allowance", "Allowance" },
                    { (short)3, null, "Absence", "Absence" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "tbl_LoanType",
                columns: new[] { "LoanTypeID", "AltDesc", "LongDesc", "ShortDesc" },
                values: new object[] { (short)1, null, "Company Loan", "Company Loan" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "tbl_TaskHandlerProvider",
                columns: new[] { "ID", "HandlerAssembly", "HandlerClass", "TaskAssembly", "TaskClass" },
                values: new object[,]
                {
                    { 401, null, null, "Aerish, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Aerish.Commands.LoanCmds.CompanyLoans.HMOPremiumPayableLoanCmd" },
                    { 2000, null, null, "Aerish, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Aerish.Imports.Commands.ImportPersonCmd" },
                    { 1001, null, null, "Aerish, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Aerish.Commands.RollbackEmployeeCmd" },
                    { 302, "Aerish.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Aerish.Application.Commands.DeductionCmds.Contributions.PhilHealthContributionDeductionCmdHandler", "Aerish, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Aerish.Commands.DeductionCmds.Contributions.ContributionDeductionCmd" },
                    { 301, "Aerish.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Aerish.Application.Commands.DeductionCmds.Contributions.PagIBIGContributionDeductionCmdHandler", "Aerish, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Aerish.Commands.DeductionCmds.Contributions.ContributionDeductionCmd" },
                    { 1000, null, null, "Aerish, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Aerish.Commands.CalcCmds.MainCalcCmd" },
                    { 202, null, null, "Aerish, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Aerish.Commands.DeductionCmds.Deductions.OtherDeductionCmd" },
                    { 201, null, null, "Aerish, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Aerish.Commands.DeductionCmds.Deductions.CashAdvanceDeductionCmd" },
                    { 101, null, null, "Aerish, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Aerish.Commands.EarningCmds.Earnings.CalcEmployeeEarningCmd" },
                    { 100, null, null, "Aerish, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Aerish.Commands.CalcCmds.CalcBasicPayCmd" },
                    { 300, "Aerish.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Aerish.Application.Commands.DeductionCmds.Contributions.SSSContributionDeductionCmdHandler", "Aerish, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Aerish.Commands.DeductionCmds.Contributions.ContributionDeductionCmd" }
                });

            migrationBuilder.InsertData(
                schema: "pr",
                table: "tbl_OTRateType",
                columns: new[] { "OTRateTypeID", "AltDesc", "LongDesc", "ShortDesc" },
                values: new object[] { (short)1, null, "Night Differential", "Night Differential" });

            migrationBuilder.InsertData(
                schema: "pr",
                table: "tbl_PaymentMode",
                columns: new[] { "PaymentModeID", "AltDesc", "LongDesc", "ShortDesc" },
                values: new object[,]
                {
                    { (short)6, null, "Annually", "Annually" },
                    { (short)5, null, "Daily", "Daily" },
                    { (short)4, null, "Monthly", "Monthly" },
                    { (short)3, null, "Semi-Monthly", "Semi-Monthly" },
                    { (short)1, null, "Weekly", "Weekly" },
                    { (short)2, null, "Bi-weekly", "Bi-weekly" }
                });

            migrationBuilder.InsertData(
                schema: "pr",
                table: "tbl_PlanYear",
                columns: new[] { "Year", "EffectivityEnd", "EffectivityStart", "IsActive" },
                values: new object[,]
                {
                    { (short)2020, new DateTime(2020, 12, 31, 23, 59, 59, 0, DateTimeKind.Utc), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true },
                    { (short)2021, new DateTime(2021, 12, 31, 23, 59, 59, 0, DateTimeKind.Utc), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false }
                });

            migrationBuilder.InsertData(
                schema: "pr",
                table: "tbl_Table",
                columns: new[] { "Code", "TableID", "AltDesc", "EffectiveEndOn", "EffectiveStartOn", "LongDesc", "Reference", "ShortDesc" },
                values: new object[,]
                {
                    { "PhilHealth", (short)3, null, new DateTime(2021, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PhilHealth", "https://www.philhealth.gov.ph/circulars/2020/circ2020-0005.pdf", "PhilHealth" },
                    { "TaxTable", (short)1, null, new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "REVISED WITHHOLDING TAX TABLE", null, "REVISED WITHHOLDING TAX TABLE" },
                    { "PhilHealth", (short)2, null, new DateTime(2020, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PhilHealth", "https://www.philhealth.gov.ph/circulars/2019/circ2019-0009.pdf", "PhilHealth" },
                    { "SSS", (short)4, null, new DateTime(2021, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PhilHSSSealth", "https://www.sss.gov.ph/sss/DownloadContent?fileName=2021-CONTRIBUTION-SCHEDULE.pdf", "SSS" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "tbl_Deduction",
                columns: new[] { "DeductionID", "AltDesc", "ClientID", "Code", "DeductionTypeID", "IsEnabled", "IsExcludedInTax", "LongDesc", "ShortDesc", "TaskHandlerProviderID" },
                values: new object[,]
                {
                    { (short)1, null, (short)1, "CA", (short)1, false, false, "Cash Advance", "Cash Advance", 201 },
                    { (short)9, null, (short)1, "Others", (short)1, true, true, "Others", "Others", 202 },
                    { (short)2, null, (short)1, "SSS", (short)2, true, true, "SSS Contribution", "SSS Contribution", 300 },
                    { (short)3, null, (short)1, "PagIBIG", (short)2, true, true, "Pag-IBIG Contribution", "Pag-IBIG Contribution", 301 },
                    { (short)4, null, (short)1, "PhilHealth", (short)2, true, true, "PhilHealth Contribution", "PhilHealth Contribution", 302 }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "tbl_Earning",
                columns: new[] { "EarningID", "AltDesc", "ClientID", "Code", "ComputedBy", "EarningTypeID", "IsAdjustIfAbsent", "IsComputed", "IsDeMinimis", "IsEnabled", "IsNegativeComputation", "IsPartOfBasicPay", "IsReceivable", "IsTaxable", "LongDesc", "ShortDesc", "TaskHandlerProviderID" },
                values: new object[,]
                {
                    { (short)2, null, (short)1, "Absent", "Hour", (short)3, true, true, false, false, true, true, false, true, "Absent", "Absent", null },
                    { (short)1, null, (short)1, "BasicPay", null, (short)1, false, false, false, true, false, false, true, true, "Basic Pay", "Basic Pay", 100 },
                    { (short)3, null, (short)1, "InternetAllowance", null, (short)2, false, false, true, true, false, false, true, true, "Internet Allowance", "Internet Allowance", 101 },
                    { (short)4, null, (short)1, "ShiftAllowance", null, (short)2, false, false, true, true, false, false, true, true, "Shift Allowance", "Shift Allowance", 101 },
                    { (short)5, null, (short)1, "RiceAllowance", null, (short)2, false, false, false, true, false, false, true, false, "Rice Allowance", "Rice Allowance", 101 },
                    { (short)6, null, (short)1, "ClothingAllowance", null, (short)2, false, false, false, true, false, false, true, false, "Clothing Allowance", "Clothing Allowance", 101 }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "tbl_Job",
                columns: new[] { "ClientID", "JobID", "AltDesc", "IsEnabled", "LongDesc", "ShortDesc", "TaskHandlerProviderID" },
                values: new object[,]
                {
                    { (short)1, (short)100, null, true, "Main Calc", "Main Calc", 1000 },
                    { (short)1, (short)404, null, true, "Rollback Employee", "Rollback Employee", 1001 },
                    { (short)1, (short)700, null, true, "Import Person Data", "Import Person Data", 2000 }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "tbl_Loan",
                columns: new[] { "LoanID", "AltDesc", "ClientID", "Code", "IsEnabled", "LoanTypeID", "LongDesc", "ShortDesc", "TaskHandlerProviderID" },
                values: new object[] { (short)1, null, (short)1, "HMOPremiumPayable", true, (short)1, "HMO Premium Payable", "HMO Premium Payable", 401 });

            migrationBuilder.InsertData(
                schema: "pr",
                table: "tbl_PayRun",
                columns: new[] { "ClientID", "PayRunID", "PlanYear", "CutOffEnd", "CutOffStart", "PayoutDate", "PeriodEnd", "PeriodStart" },
                values: new object[,]
                {
                    { (short)1, (short)2, (short)2021, new DateTime(2021, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { (short)1, (short)1, (short)2021, new DateTime(2020, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                schema: "pr",
                table: "tbl_Period",
                columns: new[] { "PeriodID", "AltDesc", "IsEveryPayroll", "IsNeedPayoutPlace", "LongDesc", "Order", "PaymentModeID", "ShortDesc" },
                values: new object[,]
                {
                    { (short)27, null, false, true, "December", (short)0, (short)6, "December" },
                    { (short)26, null, false, true, "November", (short)0, (short)6, "November" },
                    { (short)25, null, false, true, "October", (short)0, (short)6, "October" },
                    { (short)24, null, false, true, "September", (short)0, (short)6, "September" },
                    { (short)22, null, false, true, "July", (short)0, (short)6, "July" },
                    { (short)21, null, false, true, "June", (short)0, (short)6, "June" },
                    { (short)20, null, false, true, "May", (short)0, (short)6, "May" },
                    { (short)19, null, false, true, "April", (short)0, (short)6, "April" },
                    { (short)18, null, false, true, "March", (short)0, (short)6, "March" },
                    { (short)17, null, false, true, "February", (short)0, (short)6, "February" },
                    { (short)16, null, false, true, "January", (short)0, (short)6, "January" },
                    { (short)5, null, true, false, "Every Payroll", (short)1, (short)5, "Every Payroll" },
                    { (short)23, null, false, true, "August", (short)0, (short)6, "August" },
                    { (short)9, null, false, false, "Second Half", (short)2, (short)3, "Second Half" },
                    { (short)6, null, true, false, "Every Payroll", (short)1, (short)4, "Every Payroll" },
                    { (short)10, null, false, false, "Fourth Week", (short)4, (short)1, "Fourth Week" },
                    { (short)11, null, false, false, "Fifth Week", (short)5, (short)1, "Fifth Week" },
                    { (short)12, null, false, false, "Second Week", (short)2, (short)1, "Second Week" },
                    { (short)13, null, true, false, "Every Payroll", (short)6, (short)1, "Every Payroll" },
                    { (short)15, null, false, false, "First Week", (short)1, (short)1, "First Week" },
                    { (short)14, null, false, false, "Third Week", (short)3, (short)1, "Third Week" },
                    { (short)1, null, false, false, "First Payroll", (short)1, (short)2, "First Payroll" },
                    { (short)2, null, false, false, "Third Payroll", (short)3, (short)2, "Third Payroll" },
                    { (short)3, null, true, false, "Every Payroll", (short)4, (short)2, "Every Payroll" },
                    { (short)4, null, false, false, "Second Payroll", (short)2, (short)2, "Second Payroll" }
                });

            migrationBuilder.InsertData(
                schema: "pr",
                table: "tbl_Period",
                columns: new[] { "PeriodID", "AltDesc", "IsEveryPayroll", "IsNeedPayoutPlace", "LongDesc", "Order", "PaymentModeID", "ShortDesc" },
                values: new object[,]
                {
                    { (short)7, null, true, false, "Every Payroll", (short)3, (short)3, "Every Payroll" },
                    { (short)8, null, false, false, "First Half", (short)1, (short)3, "First Half" }
                });

            migrationBuilder.InsertData(
                schema: "pr",
                table: "tbl_TableRange",
                columns: new[] { "Code", "TableID", "TableRangeID", "AmountBasis", "Custom1", "Custom2", "Custom3", "Custom4", "Custom5", "EmployeeFormula", "EmployerFormula", "Fixed", "Max", "Min", "Rate" },
                values: new object[,]
                {
                    { "TaxTable", (short)1, (short)22, "Monthly", null, null, null, null, null, null, null, 10833.33m, 166666.9999999m, 66667m, 0.3m },
                    { "TaxTable", (short)1, (short)19, "Monthly", null, null, null, null, null, null, null, 0m, 20833m, 0.0000001m, 0m },
                    { "TaxTable", (short)1, (short)20, "Monthly", null, null, null, null, null, null, null, 0m, 33332m, 20833.000001m, 0.2m },
                    { "TaxTable", (short)1, (short)21, "Monthly", null, null, null, null, null, null, null, 2500m, 66666m, 33332.000001m, 0.2m },
                    { "TaxTable", (short)1, (short)18, "SemiMontly", null, null, null, null, null, null, null, 0m, 1095m, 685.000001m, 0.2m },
                    { "TaxTable", (short)1, (short)23, "Monthly", null, null, null, null, null, null, null, 40833.33m, 666666.999999m, 166666m, 0.32m },
                    { "PhilHealth", (short)3, (short)29, "Monthly", null, null, null, null, null, "({MonthlyBasicPay} * {Rate}) / 2", "({MonthlyBasicPay} * {Rate}) / 2", null, 69999.99m, 10000.01m, 0.035m },
                    { "PhilHealth", (short)2, (short)25, "Monthly", null, null, null, null, null, "{Fixed} / 2", "{Fixed} / 2", 275m, 10000m, 0.0001m, null },
                    { "PhilHealth", (short)2, (short)26, "Monthly", null, null, null, null, null, "({MonthlyBasicPay} * {Rate}) / 2", "({MonthlyBasicPay} * {Rate}) / 2", null, 59999.99m, 10000.01m, 0.03m },
                    { "PhilHealth", (short)2, (short)27, "Monthly", null, null, null, null, null, "{Fixed} / 2", "{Fixed} / 2", 1800m, 99999999.99m, 60000m, null },
                    { "PhilHealth", (short)3, (short)28, "Monthly", null, null, null, null, null, "{Fixed} / 2", "{Fixed} / 2", 350m, 10000m, 0.0001m, null },
                    { "TaxTable", (short)1, (short)17, "SemiMontly", null, null, null, null, null, null, null, 0m, 1095m, 685.000001m, 0.2m },
                    { "PhilHealth", (short)3, (short)30, "Monthly", null, null, null, null, null, "{Fixed} / 2", "{Fixed} / 2", 2450m, 99999999.99m, 70000m, null },
                    { "TaxTable", (short)1, (short)24, "Monthly", null, null, null, null, null, null, null, 200833.33m, 999999999m, 666667m, 0.35m },
                    { "TaxTable", (short)1, (short)16, "SemiMontly", null, null, null, null, null, null, null, 0m, 1095m, 685.000001m, 0.2m },
                    { "TaxTable", (short)1, (short)9, "Weekly", null, null, null, null, null, null, null, 0m, 1095m, 685.000001m, 0.2m },
                    { "TaxTable", (short)1, (short)14, "SemiMontly", null, null, null, null, null, null, null, 0m, 1095m, 685.000001m, 0.2m },
                    { "TaxTable", (short)1, (short)13, "SemiMontly", null, null, null, null, null, null, null, 0m, 685m, 0.0000001m, 0m },
                    { "TaxTable", (short)1, (short)12, "Weekly", null, null, null, null, null, null, null, 0m, 1095m, 685.000001m, 0.2m },
                    { "TaxTable", (short)1, (short)11, "Weekly", null, null, null, null, null, null, null, 0m, 1095m, 685.000001m, 0.2m },
                    { "TaxTable", (short)1, (short)10, "Weekly", null, null, null, null, null, null, null, 0m, 1095m, 685.000001m, 0.2m },
                    { "TaxTable", (short)1, (short)8, "Weekly", null, null, null, null, null, null, null, 0m, 1095m, 685.000001m, 0.2m },
                    { "TaxTable", (short)1, (short)7, "Weekly", null, null, null, null, null, null, null, 0m, 685m, 0.0000001m, 0m },
                    { "TaxTable", (short)1, (short)6, "Daily", null, null, null, null, null, null, null, 0m, 1095m, 685.000001m, 0.2m },
                    { "TaxTable", (short)1, (short)5, "Daily", null, null, null, null, null, null, null, 0m, 1095m, 685.000001m, 0.2m },
                    { "TaxTable", (short)1, (short)4, "Daily", null, null, null, null, null, null, null, 0m, 1095m, 685.000001m, 0.2m },
                    { "TaxTable", (short)1, (short)3, "Daily", null, null, null, null, null, null, null, 0m, 1095m, 685.000001m, 0.2m },
                    { "TaxTable", (short)1, (short)2, "Daily", null, null, null, null, null, null, null, 0m, 1095m, 685.000001m, 0.2m },
                    { "TaxTable", (short)1, (short)1, "Daily", null, null, null, null, null, null, null, 0m, 685m, 0.0000001m, 0m },
                    { "SSS", (short)4, (short)31, "Monthly", null, null, null, null, null, "135.00", "255.00", 3000m, 3250m, 0.0001m, null },
                    { "TaxTable", (short)1, (short)15, "SemiMontly", null, null, null, null, null, null, null, 0m, 1095m, 685.000001m, 0.2m },
                    { "SSS", (short)4, (short)32, "Monthly", null, null, null, null, null, "1700.00", "900.00", 20000m, 9999999999m, 24750m, null }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "tbl_JobParameter",
                columns: new[] { "ClientID", "JobID", "Name", "DataType", "DefaultValue", "Display", "IsRequired", "MaxLength", "Order" },
                values: new object[,]
                {
                    { (short)1, (short)100, "PlanYear", "short", "2020", "Plan Year", true, null, (short)1 },
                    { (short)1, (short)100, "PayRunID", "short", null, "Pay Run ID", true, null, (short)2 },
                    { (short)1, (short)100, "PersonID", "int", null, "Person ID", false, null, (short)3 },
                    { (short)1, (short)100, "SpecialGroupID", "int", null, "Special Group ID", false, null, (short)100 },
                    { (short)1, (short)404, "EmployeeID", "int", null, "Employee ID", true, null, (short)0 },
                    { (short)1, (short)700, "Path", "string", null, "File Path", true, null, (short)0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_BasicPay_EmployeeID_ClientID",
                schema: "pr",
                table: "tbl_BasicPay",
                columns: new[] { "EmployeeID", "ClientID" });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_BasicPay_PeriodEndID",
                schema: "pr",
                table: "tbl_BasicPay",
                column: "PeriodEndID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_BasicPay_PeriodStartID",
                schema: "pr",
                table: "tbl_BasicPay",
                column: "PeriodStartID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Batch_N_FileFileID",
                schema: "dbo",
                table: "tbl_Batch",
                column: "N_FileFileID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Deduction_Code_ClientID_IsEnabled",
                schema: "dbo",
                table: "tbl_Deduction",
                columns: new[] { "Code", "ClientID", "IsEnabled" });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Deduction_DeductionTypeID",
                schema: "dbo",
                table: "tbl_Deduction",
                column: "DeductionTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Deduction_TaskHandlerProviderID",
                schema: "dbo",
                table: "tbl_Deduction",
                column: "TaskHandlerProviderID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Earning_Code_ClientID_IsEnabled",
                schema: "dbo",
                table: "tbl_Earning",
                columns: new[] { "Code", "ClientID", "IsEnabled" });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Earning_EarningTypeID",
                schema: "dbo",
                table: "tbl_Earning",
                column: "EarningTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Earning_TaskHandlerProviderID",
                schema: "dbo",
                table: "tbl_Earning",
                column: "TaskHandlerProviderID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Employee_ClientID_Code_EmployeeID",
                schema: "dbo",
                table: "tbl_Employee",
                columns: new[] { "ClientID", "Code", "EmployeeID" },
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_EmployeeDeduction_ClientID_EmployeeDeductionRefID_EmployeeID_DeductionID",
                schema: "pr",
                table: "tbl_EmployeeDeduction",
                columns: new[] { "ClientID", "EmployeeDeductionRefID", "EmployeeID", "DeductionID" });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_EmployeeDeduction_ClientID_PayRunID_PlanYear",
                schema: "pr",
                table: "tbl_EmployeeDeduction",
                columns: new[] { "ClientID", "PayRunID", "PlanYear" });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_EmployeeDeduction_DeductionID",
                schema: "pr",
                table: "tbl_EmployeeDeduction",
                column: "DeductionID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_EmployeeDeductionRef_DeductionID",
                schema: "pr",
                table: "tbl_EmployeeDeductionRef",
                column: "DeductionID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_EmployeeDeductionRef_EmployeeID_ClientID",
                schema: "pr",
                table: "tbl_EmployeeDeductionRef",
                columns: new[] { "EmployeeID", "ClientID" });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_EmployeeEarning_ClientID_EmployeeEarningRefID_EmployeeID_EarningID",
                schema: "pr",
                table: "tbl_EmployeeEarning",
                columns: new[] { "ClientID", "EmployeeEarningRefID", "EmployeeID", "EarningID" });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_EmployeeEarning_ClientID_PayRunID_PlanYear",
                schema: "pr",
                table: "tbl_EmployeeEarning",
                columns: new[] { "ClientID", "PayRunID", "PlanYear" });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_EmployeeEarning_EarningID",
                schema: "pr",
                table: "tbl_EmployeeEarning",
                column: "EarningID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_EmployeeEarningRef_EarningID",
                schema: "pr",
                table: "tbl_EmployeeEarningRef",
                column: "EarningID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_EmployeeEarningRef_EmployeeID_ClientID",
                schema: "pr",
                table: "tbl_EmployeeEarningRef",
                columns: new[] { "EmployeeID", "ClientID" });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_EmployeeLoan_ClientID_PayRunID_PlanYear",
                schema: "pr",
                table: "tbl_EmployeeLoan",
                columns: new[] { "ClientID", "PayRunID", "PlanYear" });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_EmployeeLoan_EmployeeLoanRefID_EmployeeID_ClientID_LoanID",
                schema: "pr",
                table: "tbl_EmployeeLoan",
                columns: new[] { "EmployeeLoanRefID", "EmployeeID", "ClientID", "LoanID" });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_EmployeeLoan_LoanID",
                schema: "pr",
                table: "tbl_EmployeeLoan",
                column: "LoanID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_EmployeeLoanRef_EmployeeID_ClientID",
                schema: "pr",
                table: "tbl_EmployeeLoanRef",
                columns: new[] { "EmployeeID", "ClientID" });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_EmployeeLoanRef_LoanID",
                schema: "pr",
                table: "tbl_EmployeeLoanRef",
                column: "LoanID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_EmployeeOvertime_ClientID_PayRunID_PlanYear",
                schema: "pr",
                table: "tbl_EmployeeOvertime",
                columns: new[] { "ClientID", "PayRunID", "PlanYear" });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_EmployeeOvertime_EmployeeID_ClientID",
                schema: "pr",
                table: "tbl_EmployeeOvertime",
                columns: new[] { "EmployeeID", "ClientID" });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_EmployeeOvertime_OTRateID",
                schema: "pr",
                table: "tbl_EmployeeOvertime",
                column: "OTRateID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Job_TaskHandlerProviderID",
                schema: "dbo",
                table: "tbl_Job",
                column: "TaskHandlerProviderID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Loan_Code_ClientID_IsEnabled",
                schema: "dbo",
                table: "tbl_Loan",
                columns: new[] { "Code", "ClientID", "IsEnabled" });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Loan_LoanTypeID",
                schema: "dbo",
                table: "tbl_Loan",
                column: "LoanTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Loan_TaskHandlerProviderID",
                schema: "dbo",
                table: "tbl_Loan",
                column: "TaskHandlerProviderID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_MasterEmployee_ClientID_PayRunID_PlanYear",
                schema: "cd",
                table: "tbl_MasterEmployee",
                columns: new[] { "ClientID", "PayRunID", "PlanYear" });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_MasterEmployeeDeduction_ClientID_PayRunID_PlanYear",
                schema: "cd",
                table: "tbl_MasterEmployeeDeduction",
                columns: new[] { "ClientID", "PayRunID", "PlanYear" });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_MasterEmployeeDeduction_DeductionID",
                schema: "cd",
                table: "tbl_MasterEmployeeDeduction",
                column: "DeductionID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_MasterEmployeeDeduction_EmployeeID_ClientID_CalcID_PlanYear_PayRunID",
                schema: "cd",
                table: "tbl_MasterEmployeeDeduction",
                columns: new[] { "EmployeeID", "ClientID", "CalcID", "PlanYear", "PayRunID" });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_MasterEmployeeEarning_ClientID_PayRunID_PlanYear",
                schema: "cd",
                table: "tbl_MasterEmployeeEarning",
                columns: new[] { "ClientID", "PayRunID", "PlanYear" });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_MasterEmployeeEarning_EarningID",
                schema: "cd",
                table: "tbl_MasterEmployeeEarning",
                column: "EarningID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_MasterEmployeeEarning_EmployeeID_ClientID_CalcID_PlanYear_PayRunID",
                schema: "cd",
                table: "tbl_MasterEmployeeEarning",
                columns: new[] { "EmployeeID", "ClientID", "CalcID", "PlanYear", "PayRunID" });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_MasterEmployeeLoan_ClientID_PayRunID_PlanYear",
                schema: "cd",
                table: "tbl_MasterEmployeeLoan",
                columns: new[] { "ClientID", "PayRunID", "PlanYear" });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_MasterEmployeeLoan_EmployeeID_ClientID_CalcID_PlanYear_PayRunID",
                schema: "cd",
                table: "tbl_MasterEmployeeLoan",
                columns: new[] { "EmployeeID", "ClientID", "CalcID", "PlanYear", "PayRunID" });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_MasterEmployeeLoan_LoanID",
                schema: "cd",
                table: "tbl_MasterEmployeeLoan",
                column: "LoanID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_OTRate_OTRateTypeID",
                schema: "pr",
                table: "tbl_OTRate",
                column: "OTRateTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_PayRun_PlanYear",
                schema: "pr",
                table: "tbl_PayRun",
                column: "PlanYear");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Period_PaymentModeID",
                schema: "pr",
                table: "tbl_Period",
                column: "PaymentModeID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_ProcessInstance_ClientID_JobID",
                schema: "dbo",
                table: "tbl_ProcessInstance",
                columns: new[] { "ClientID", "JobID" });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_ProcessInstanceError_ProcessInstanceID",
                schema: "dbo",
                table: "tbl_ProcessInstanceError",
                column: "ProcessInstanceID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_ProcessInstanceMessage_ProcessInstanceID",
                schema: "dbo",
                table: "tbl_ProcessInstanceMessage",
                column: "ProcessInstanceID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_ProcessInstanceParameter_ProcessInstanceID",
                schema: "dbo",
                table: "tbl_ProcessInstanceParameter",
                column: "ProcessInstanceID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_StagingPerson_ProcessInstanceID",
                schema: "stg",
                table: "tbl_StagingPerson",
                column: "ProcessInstanceID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_TableRange_TableID_Code",
                schema: "pr",
                table: "tbl_TableRange",
                columns: new[] { "TableID", "Code" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_Bank",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_BasicPay",
                schema: "pr");

            migrationBuilder.DropTable(
                name: "tbl_Batch",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_EmployeeDeduction",
                schema: "pr");

            migrationBuilder.DropTable(
                name: "tbl_EmployeeEarning",
                schema: "pr");

            migrationBuilder.DropTable(
                name: "tbl_EmployeeLoan",
                schema: "pr");

            migrationBuilder.DropTable(
                name: "tbl_EmployeeOvertime",
                schema: "pr");

            migrationBuilder.DropTable(
                name: "tbl_Event",
                schema: "pr");

            migrationBuilder.DropTable(
                name: "tbl_JobParameter",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_Lookup",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_MasterEmployeeDeduction",
                schema: "cd");

            migrationBuilder.DropTable(
                name: "tbl_MasterEmployeeEarning",
                schema: "cd");

            migrationBuilder.DropTable(
                name: "tbl_MasterEmployeeLoan",
                schema: "cd");

            migrationBuilder.DropTable(
                name: "tbl_ProcessInstanceError",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_ProcessInstanceMessage",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_ProcessInstanceParameter",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_SpecialGroupMember",
                schema: "cd");

            migrationBuilder.DropTable(
                name: "tbl_StagingPerson",
                schema: "stg");

            migrationBuilder.DropTable(
                name: "tbl_TableRange",
                schema: "pr");

            migrationBuilder.DropTable(
                name: "tbl_ValidationFailure",
                schema: "stg");

            migrationBuilder.DropTable(
                name: "tbl_Period",
                schema: "pr");

            migrationBuilder.DropTable(
                name: "tbl_BatchFile",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_EmployeeDeductionRef",
                schema: "pr");

            migrationBuilder.DropTable(
                name: "tbl_EmployeeEarningRef",
                schema: "pr");

            migrationBuilder.DropTable(
                name: "tbl_EmployeeLoanRef",
                schema: "pr");

            migrationBuilder.DropTable(
                name: "tbl_OTRate",
                schema: "pr");

            migrationBuilder.DropTable(
                name: "tbl_MasterEmployee",
                schema: "cd");

            migrationBuilder.DropTable(
                name: "tbl_SpecialGroup",
                schema: "cd");

            migrationBuilder.DropTable(
                name: "tbl_ProcessInstance",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_Table",
                schema: "pr");

            migrationBuilder.DropTable(
                name: "tbl_PaymentMode",
                schema: "pr");

            migrationBuilder.DropTable(
                name: "tbl_Deduction",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_Earning",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_Loan",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_OTRateType",
                schema: "pr");

            migrationBuilder.DropTable(
                name: "tbl_Employee",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_PayRun",
                schema: "pr");

            migrationBuilder.DropTable(
                name: "tbl_Job",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_DeductionType",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_EarningType",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_LoanType",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_Person",
                schema: "cdm");

            migrationBuilder.DropTable(
                name: "tbl_Client",
                schema: "cdm");

            migrationBuilder.DropTable(
                name: "tbl_PlanYear",
                schema: "pr");

            migrationBuilder.DropTable(
                name: "tbl_TaskHandlerProvider",
                schema: "dbo");
        }
    }
}
