using System;
using System.Linq;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

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

namespace Aerish.Interfaces
{
	public interface IAerishDbContext
	{
		Guid UID { get; }
		bool HasSeedData { get; set; }

		#region Entities
		IQueryable<MasterEmployee> MasterEmployees { get; }
		IQueryable<MasterEmployeeDeduction> MasterEmployeeDeductions { get; }
		IQueryable<MasterEmployeeEarning> MasterEmployeeEarnings { get; }
		IQueryable<MasterEmployeeLoan> MasterEmployeeLoans { get; }
		IQueryable<SpecialGroup> SpecialGroups { get; }
		IQueryable<SpecialGroupMember> SpecialGroupMembers { get; }
		IQueryable<Bank> Banks { get; }
		IQueryable<Batch> Batches { get; }
		IQueryable<BatchFile> BatchFiles { get; }
		IQueryable<Deduction> Deductions { get; }
		IQueryable<DeductionType> DeductionTypes { get; }
		IQueryable<Earning> Earnings { get; }
		IQueryable<EarningType> EarningTypes { get; }
		IQueryable<Employee> Employees { get; }
		IQueryable<Loan> Loans { get; }
		IQueryable<LoanType> LoanTypes { get; }
		IQueryable<Lookup> Lookups { get; }
		IQueryable<OTRate> OTRates { get; }
		IQueryable<OTRateType> OTRateTypes { get; }
		IQueryable<ProcessInstance> ProcessInstances { get; }
		IQueryable<ProcessInstanceError> ProcessInstanceErrors { get; }
		IQueryable<ProcessInstanceMessage> ProcessInstanceMessages { get; }
		IQueryable<ProcessInstanceParameter> ProcessInstanceParameters { get; }
		IQueryable<TaskHandlerProvider> TaskHandlerProviders { get; }
		IQueryable<Client> Clients { get; }
		IQueryable<Job> Jobs { get; }
		IQueryable<JobParameter> JobParameters { get; }
		IQueryable<Person> Persons { get; }
		IQueryable<BasicPay> BasicPays { get; }
		IQueryable<EmployeeDeduction> EmployeeDeductions { get; }
		IQueryable<EmployeeDeductionRef> EmployeeDeductionRefs { get; }
		IQueryable<EmployeeEarning> EmployeeEarnings { get; }
		IQueryable<EmployeeEarningRef> EmployeeEarningRefs { get; }
		IQueryable<EmployeeLoan> EmployeeLoans { get; }
		IQueryable<EmployeeLoanRef> EmployeeLoanRefs { get; }
		IQueryable<EmployeeOvertime> EmployeeOvertimes { get; }
		IQueryable<Event> Events { get; }
		IQueryable<PaymentMode> PaymentModes { get; }
		IQueryable<PayRun> PayRuns { get; }
		IQueryable<Period> Periods { get; }
		IQueryable<PlanYear> PlanYears { get; }
		IQueryable<Table> Tables { get; }
		IQueryable<TableRange> TableRanges { get; }
		IQueryable<StagingBasicPay> StagingBasicPays { get; }
		IQueryable<StagingPerson> StagingPersons { get; }
		IQueryable<ValidationFailure> ValidationFailures { get; }
        #endregion

		int SaveChanges();
		Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
	}
}

