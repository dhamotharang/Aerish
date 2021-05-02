using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

using Aerish.Interfaces;
using Aerish.Domain.Entities;
using Aerish.Domain.Entities.Parameters;
using Aerish.Domain.Entities.Common;
using Aerish.Domain.Entities.CalcData;
using Aerish.Domain.Entities.Staging;
using Aerish.Application.Common.Entities.Staging;

/*
Do not modify this file! This is auto generated!
Any changes to this file will be gone when template gets generated again.
*/

namespace Aerish.Infrastructure.Persistence
{
	public partial class AerishDbContext : DbContext, IAerishDbContext
	{
		public Guid UID { get; } = Guid.NewGuid();
		public bool HasSeedData { get; set; }

		#region Entities
		private DbSet<MasterEmployee> db_MasterEmployees { get; set; }
		public IQueryable<MasterEmployee> MasterEmployees 
		{ 
			get { return db_MasterEmployees; }
			private set { db_MasterEmployees = (DbSet<MasterEmployee>)value; }
		}
		private DbSet<MasterEmployeeDeduction> db_MasterEmployeeDeductions { get; set; }
		public IQueryable<MasterEmployeeDeduction> MasterEmployeeDeductions 
		{ 
			get { return db_MasterEmployeeDeductions; }
			private set { db_MasterEmployeeDeductions = (DbSet<MasterEmployeeDeduction>)value; }
		}
		private DbSet<MasterEmployeeEarning> db_MasterEmployeeEarnings { get; set; }
		public IQueryable<MasterEmployeeEarning> MasterEmployeeEarnings 
		{ 
			get { return db_MasterEmployeeEarnings; }
			private set { db_MasterEmployeeEarnings = (DbSet<MasterEmployeeEarning>)value; }
		}
		private DbSet<MasterEmployeeLoan> db_MasterEmployeeLoans { get; set; }
		public IQueryable<MasterEmployeeLoan> MasterEmployeeLoans 
		{ 
			get { return db_MasterEmployeeLoans; }
			private set { db_MasterEmployeeLoans = (DbSet<MasterEmployeeLoan>)value; }
		}
		private DbSet<SpecialGroup> db_SpecialGroups { get; set; }
		public IQueryable<SpecialGroup> SpecialGroups 
		{ 
			get { return db_SpecialGroups; }
			private set { db_SpecialGroups = (DbSet<SpecialGroup>)value; }
		}
		private DbSet<SpecialGroupMember> db_SpecialGroupMembers { get; set; }
		public IQueryable<SpecialGroupMember> SpecialGroupMembers 
		{ 
			get { return db_SpecialGroupMembers; }
			private set { db_SpecialGroupMembers = (DbSet<SpecialGroupMember>)value; }
		}
		private DbSet<Bank> db_Banks { get; set; }
		public IQueryable<Bank> Banks 
		{ 
			get { return db_Banks; }
			private set { db_Banks = (DbSet<Bank>)value; }
		}
		private DbSet<Batch> db_Batches { get; set; }
		public IQueryable<Batch> Batches 
		{ 
			get { return db_Batches; }
			private set { db_Batches = (DbSet<Batch>)value; }
		}
		private DbSet<BatchFile> db_BatchFiles { get; set; }
		public IQueryable<BatchFile> BatchFiles 
		{ 
			get { return db_BatchFiles; }
			private set { db_BatchFiles = (DbSet<BatchFile>)value; }
		}
		private DbSet<Deduction> db_Deductions { get; set; }
		public IQueryable<Deduction> Deductions 
		{ 
			get { return db_Deductions; }
			private set { db_Deductions = (DbSet<Deduction>)value; }
		}
		private DbSet<DeductionType> db_DeductionTypes { get; set; }
		public IQueryable<DeductionType> DeductionTypes 
		{ 
			get { return db_DeductionTypes; }
			private set { db_DeductionTypes = (DbSet<DeductionType>)value; }
		}
		private DbSet<Earning> db_Earnings { get; set; }
		public IQueryable<Earning> Earnings 
		{ 
			get { return db_Earnings; }
			private set { db_Earnings = (DbSet<Earning>)value; }
		}
		private DbSet<EarningType> db_EarningTypes { get; set; }
		public IQueryable<EarningType> EarningTypes 
		{ 
			get { return db_EarningTypes; }
			private set { db_EarningTypes = (DbSet<EarningType>)value; }
		}
		private DbSet<Employee> db_Employees { get; set; }
		public IQueryable<Employee> Employees 
		{ 
			get { return db_Employees; }
			private set { db_Employees = (DbSet<Employee>)value; }
		}
		private DbSet<Loan> db_Loans { get; set; }
		public IQueryable<Loan> Loans 
		{ 
			get { return db_Loans; }
			private set { db_Loans = (DbSet<Loan>)value; }
		}
		private DbSet<LoanType> db_LoanTypes { get; set; }
		public IQueryable<LoanType> LoanTypes 
		{ 
			get { return db_LoanTypes; }
			private set { db_LoanTypes = (DbSet<LoanType>)value; }
		}
		private DbSet<Lookup> db_Lookups { get; set; }
		public IQueryable<Lookup> Lookups 
		{ 
			get { return db_Lookups; }
			private set { db_Lookups = (DbSet<Lookup>)value; }
		}
		private DbSet<OTRate> db_OTRates { get; set; }
		public IQueryable<OTRate> OTRates 
		{ 
			get { return db_OTRates; }
			private set { db_OTRates = (DbSet<OTRate>)value; }
		}
		private DbSet<OTRateType> db_OTRateTypes { get; set; }
		public IQueryable<OTRateType> OTRateTypes 
		{ 
			get { return db_OTRateTypes; }
			private set { db_OTRateTypes = (DbSet<OTRateType>)value; }
		}
		private DbSet<ProcessInstance> db_ProcessInstances { get; set; }
		public IQueryable<ProcessInstance> ProcessInstances 
		{ 
			get { return db_ProcessInstances; }
			private set { db_ProcessInstances = (DbSet<ProcessInstance>)value; }
		}
		private DbSet<ProcessInstanceError> db_ProcessInstanceErrors { get; set; }
		public IQueryable<ProcessInstanceError> ProcessInstanceErrors 
		{ 
			get { return db_ProcessInstanceErrors; }
			private set { db_ProcessInstanceErrors = (DbSet<ProcessInstanceError>)value; }
		}
		private DbSet<ProcessInstanceMessage> db_ProcessInstanceMessages { get; set; }
		public IQueryable<ProcessInstanceMessage> ProcessInstanceMessages 
		{ 
			get { return db_ProcessInstanceMessages; }
			private set { db_ProcessInstanceMessages = (DbSet<ProcessInstanceMessage>)value; }
		}
		private DbSet<ProcessInstanceParameter> db_ProcessInstanceParameters { get; set; }
		public IQueryable<ProcessInstanceParameter> ProcessInstanceParameters 
		{ 
			get { return db_ProcessInstanceParameters; }
			private set { db_ProcessInstanceParameters = (DbSet<ProcessInstanceParameter>)value; }
		}
		private DbSet<TaskHandlerProvider> db_TaskHandlerProviders { get; set; }
		public IQueryable<TaskHandlerProvider> TaskHandlerProviders 
		{ 
			get { return db_TaskHandlerProviders; }
			private set { db_TaskHandlerProviders = (DbSet<TaskHandlerProvider>)value; }
		}
		private DbSet<Client> db_Clients { get; set; }
		public IQueryable<Client> Clients 
		{ 
			get { return db_Clients; }
			private set { db_Clients = (DbSet<Client>)value; }
		}
		private DbSet<Job> db_Jobs { get; set; }
		public IQueryable<Job> Jobs 
		{ 
			get { return db_Jobs; }
			private set { db_Jobs = (DbSet<Job>)value; }
		}
		private DbSet<JobParameter> db_JobParameters { get; set; }
		public IQueryable<JobParameter> JobParameters 
		{ 
			get { return db_JobParameters; }
			private set { db_JobParameters = (DbSet<JobParameter>)value; }
		}
		private DbSet<Person> db_Persons { get; set; }
		public IQueryable<Person> Persons 
		{ 
			get { return db_Persons; }
			private set { db_Persons = (DbSet<Person>)value; }
		}
		private DbSet<BasicPay> db_BasicPays { get; set; }
		public IQueryable<BasicPay> BasicPays 
		{ 
			get { return db_BasicPays; }
			private set { db_BasicPays = (DbSet<BasicPay>)value; }
		}
		private DbSet<EmployeeDeduction> db_EmployeeDeductions { get; set; }
		public IQueryable<EmployeeDeduction> EmployeeDeductions 
		{ 
			get { return db_EmployeeDeductions; }
			private set { db_EmployeeDeductions = (DbSet<EmployeeDeduction>)value; }
		}
		private DbSet<EmployeeDeductionRef> db_EmployeeDeductionRefs { get; set; }
		public IQueryable<EmployeeDeductionRef> EmployeeDeductionRefs 
		{ 
			get { return db_EmployeeDeductionRefs; }
			private set { db_EmployeeDeductionRefs = (DbSet<EmployeeDeductionRef>)value; }
		}
		private DbSet<EmployeeEarning> db_EmployeeEarnings { get; set; }
		public IQueryable<EmployeeEarning> EmployeeEarnings 
		{ 
			get { return db_EmployeeEarnings; }
			private set { db_EmployeeEarnings = (DbSet<EmployeeEarning>)value; }
		}
		private DbSet<EmployeeEarningRef> db_EmployeeEarningRefs { get; set; }
		public IQueryable<EmployeeEarningRef> EmployeeEarningRefs 
		{ 
			get { return db_EmployeeEarningRefs; }
			private set { db_EmployeeEarningRefs = (DbSet<EmployeeEarningRef>)value; }
		}
		private DbSet<EmployeeLoan> db_EmployeeLoans { get; set; }
		public IQueryable<EmployeeLoan> EmployeeLoans 
		{ 
			get { return db_EmployeeLoans; }
			private set { db_EmployeeLoans = (DbSet<EmployeeLoan>)value; }
		}
		private DbSet<EmployeeLoanRef> db_EmployeeLoanRefs { get; set; }
		public IQueryable<EmployeeLoanRef> EmployeeLoanRefs 
		{ 
			get { return db_EmployeeLoanRefs; }
			private set { db_EmployeeLoanRefs = (DbSet<EmployeeLoanRef>)value; }
		}
		private DbSet<EmployeeOvertime> db_EmployeeOvertimes { get; set; }
		public IQueryable<EmployeeOvertime> EmployeeOvertimes 
		{ 
			get { return db_EmployeeOvertimes; }
			private set { db_EmployeeOvertimes = (DbSet<EmployeeOvertime>)value; }
		}
		private DbSet<Event> db_Events { get; set; }
		public IQueryable<Event> Events 
		{ 
			get { return db_Events; }
			private set { db_Events = (DbSet<Event>)value; }
		}
		private DbSet<PaymentMode> db_PaymentModes { get; set; }
		public IQueryable<PaymentMode> PaymentModes 
		{ 
			get { return db_PaymentModes; }
			private set { db_PaymentModes = (DbSet<PaymentMode>)value; }
		}
		private DbSet<PayRun> db_PayRuns { get; set; }
		public IQueryable<PayRun> PayRuns 
		{ 
			get { return db_PayRuns; }
			private set { db_PayRuns = (DbSet<PayRun>)value; }
		}
		private DbSet<Period> db_Periods { get; set; }
		public IQueryable<Period> Periods 
		{ 
			get { return db_Periods; }
			private set { db_Periods = (DbSet<Period>)value; }
		}
		private DbSet<PlanYear> db_PlanYears { get; set; }
		public IQueryable<PlanYear> PlanYears 
		{ 
			get { return db_PlanYears; }
			private set { db_PlanYears = (DbSet<PlanYear>)value; }
		}
		private DbSet<Table> db_Tables { get; set; }
		public IQueryable<Table> Tables 
		{ 
			get { return db_Tables; }
			private set { db_Tables = (DbSet<Table>)value; }
		}
		private DbSet<TableRange> db_TableRanges { get; set; }
		public IQueryable<TableRange> TableRanges 
		{ 
			get { return db_TableRanges; }
			private set { db_TableRanges = (DbSet<TableRange>)value; }
		}
		private DbSet<StagingBasicPay> db_StagingBasicPays { get; set; }
		public IQueryable<StagingBasicPay> StagingBasicPays 
		{ 
			get { return db_StagingBasicPays; }
			private set { db_StagingBasicPays = (DbSet<StagingBasicPay>)value; }
		}
		private DbSet<StagingPerson> db_StagingPersons { get; set; }
		public IQueryable<StagingPerson> StagingPersons 
		{ 
			get { return db_StagingPersons; }
			private set { db_StagingPersons = (DbSet<StagingPerson>)value; }
		}
		private DbSet<ValidationFailure> db_ValidationFailures { get; set; }
		public IQueryable<ValidationFailure> ValidationFailures 
		{ 
			get { return db_ValidationFailures; }
			private set { db_ValidationFailures = (DbSet<ValidationFailure>)value; }
		}
        #endregion

		public AerishDbContext(DbContextOptions<AerishDbContext> dbContextOpt) 
			: base(dbContextOpt) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
			=> modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
	}
}

namespace Aerish.Infrastructure.Persistence.Configurations
{
	#region Configurations
	public partial class MasterEmployee_Configuration : BaseConfiguration<MasterEmployee> { }
	public partial class MasterEmployeeDeduction_Configuration : BaseConfiguration<MasterEmployeeDeduction> { }
	public partial class MasterEmployeeEarning_Configuration : BaseConfiguration<MasterEmployeeEarning> { }
	public partial class MasterEmployeeLoan_Configuration : BaseConfiguration<MasterEmployeeLoan> { }
	public partial class SpecialGroup_Configuration : BaseConfiguration<SpecialGroup> { }
	public partial class SpecialGroupMember_Configuration : BaseConfiguration<SpecialGroupMember> { }
	public partial class Bank_Configuration : BaseConfiguration<Bank> { }
	public partial class Batch_Configuration : BaseConfiguration<Batch> { }
	public partial class BatchFile_Configuration : BaseConfiguration<BatchFile> { }
	public partial class Deduction_Configuration : BaseConfiguration<Deduction> { }
	public partial class DeductionType_Configuration : BaseConfiguration<DeductionType> { }
	public partial class Earning_Configuration : BaseConfiguration<Earning> { }
	public partial class EarningType_Configuration : BaseConfiguration<EarningType> { }
	public partial class Employee_Configuration : BaseConfiguration<Employee> { }
	public partial class Loan_Configuration : BaseConfiguration<Loan> { }
	public partial class LoanType_Configuration : BaseConfiguration<LoanType> { }
	public partial class Lookup_Configuration : BaseConfiguration<Lookup> { }
	public partial class OTRate_Configuration : BaseConfiguration<OTRate> { }
	public partial class OTRateType_Configuration : BaseConfiguration<OTRateType> { }
	public partial class ProcessInstance_Configuration : BaseConfiguration<ProcessInstance> { }
	public partial class ProcessInstanceError_Configuration : BaseConfiguration<ProcessInstanceError> { }
	public partial class ProcessInstanceMessage_Configuration : BaseConfiguration<ProcessInstanceMessage> { }
	public partial class ProcessInstanceParameter_Configuration : BaseConfiguration<ProcessInstanceParameter> { }
	public partial class TaskHandlerProvider_Configuration : BaseConfiguration<TaskHandlerProvider> { }
	public partial class Client_Configuration : BaseConfiguration<Client> { }
	public partial class Job_Configuration : BaseConfiguration<Job> { }
	public partial class JobParameter_Configuration : BaseConfiguration<JobParameter> { }
	public partial class Person_Configuration : BaseConfiguration<Person> { }
	public partial class BasicPay_Configuration : BaseConfiguration<BasicPay> { }
	public partial class EmployeeDeduction_Configuration : BaseConfiguration<EmployeeDeduction> { }
	public partial class EmployeeDeductionRef_Configuration : BaseConfiguration<EmployeeDeductionRef> { }
	public partial class EmployeeEarning_Configuration : BaseConfiguration<EmployeeEarning> { }
	public partial class EmployeeEarningRef_Configuration : BaseConfiguration<EmployeeEarningRef> { }
	public partial class EmployeeLoan_Configuration : BaseConfiguration<EmployeeLoan> { }
	public partial class EmployeeLoanRef_Configuration : BaseConfiguration<EmployeeLoanRef> { }
	public partial class EmployeeOvertime_Configuration : BaseConfiguration<EmployeeOvertime> { }
	public partial class Event_Configuration : BaseConfiguration<Event> { }
	public partial class PaymentMode_Configuration : BaseConfiguration<PaymentMode> { }
	public partial class PayRun_Configuration : BaseConfiguration<PayRun> { }
	public partial class Period_Configuration : BaseConfiguration<Period> { }
	public partial class PlanYear_Configuration : BaseConfiguration<PlanYear> { }
	public partial class Table_Configuration : BaseConfiguration<Table> { }
	public partial class TableRange_Configuration : BaseConfiguration<TableRange> { }
	public partial class StagingBasicPay_Configuration : BaseConfiguration<StagingBasicPay> { }
	public partial class StagingPerson_Configuration : BaseConfiguration<StagingPerson> { }
	public partial class ValidationFailure_Configuration : BaseConfiguration<ValidationFailure> { }
    #endregion
}
