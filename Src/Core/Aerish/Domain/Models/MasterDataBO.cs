using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json;

using Aerish.Domain.Models;
using Aerish.ViewModels;


namespace Aerish.Common.Models
{
    public class MasterDataBO
    {
        public int EmployeeID { get; set; }
        public short ClientID { get; set; }

        public short CalcID { get; set; }

        public RecordStatus RecordStatus { get; set; }

        public virtual decimal? DaysFactor { get; set; }
        public virtual decimal? HourlyRate { get; set; }
        public virtual decimal? DailyRate { get; set; }

        public virtual decimal? TotalTaxableIncome { get; set; }
        public virtual decimal? TotalNonTaxableIncome { get; set; }
        public virtual decimal? NetSalary { get; set; }


        public virtual PayRunBO PayRun { get; set; }

        public EmployeeBO Employee { get; set; }

        private List<MasterEmployeeDeductionBO> masterEmployeeDeductions = new List<MasterEmployeeDeductionBO>();
        public virtual IEnumerable<MasterEmployeeDeductionBO> MasterEmployeeDeductions 
        {
            get => masterEmployeeDeductions;
            set => masterEmployeeDeductions = value?.ToList();
        }

        private List<MasterEmployeeEarningBO> masterEmployeeEarnings = new List<MasterEmployeeEarningBO>();
        public virtual IEnumerable<MasterEmployeeEarningBO> MasterEmployeeEarnings 
        { 
            get => masterEmployeeEarnings; 
            set => masterEmployeeEarnings = value?.ToList(); 
        }

        private List<MasterEmployeeLoanBO> masterEmployeeLoans = new List<MasterEmployeeLoanBO>();
        public virtual IEnumerable<MasterEmployeeLoanBO> MasterEmployeeLoans 
        {
            get => masterEmployeeLoans; 
            set => masterEmployeeLoans = value?.ToList(); 
        }

        private readonly List<ChangeTracker> changeTracker = new List<ChangeTracker>();

        private MasterDataBO originalData = null;

        private decimal? monthlyRate;
        public decimal? MonthlyRate
        {
            get => monthlyRate;
            set => TrackValueChange(ref monthlyRate, value);
        }

        private AmountBasis? basicPayBasis;
        public AmountBasis? BasicPayBasis
        {
            get => basicPayBasis;
            set => TrackValueChange(ref basicPayBasis, value);
        }

        private decimal? netTaxableIncome;
        public decimal? NetTaxableIncome
        {
            get => netTaxableIncome;
            set => TrackValueChange(ref netTaxableIncome, value);
        }

        private decimal? witholdingTax;
        public decimal? WitholdingTax
        {
            get => witholdingTax;
            set => TrackValueChange(ref witholdingTax, value);
        }

        private decimal? totalDeduction;
        public decimal? TotalDeduction
        {
            get => totalDeduction;
            set => TrackValueChange(ref totalDeduction, value);
        }

        private short payrunId;
        public short PayRunID
        {
            get => payrunId;
            set => TrackValueChange(ref payrunId, value);
        }

        private short planYear;
        public short PlanYear
        {
            get => planYear;
            set => TrackValueChange(ref planYear, value);
        }

        public void AddNewEmployeeEarning(MasterEmployeeEarningBO employeeEarning)
        {
            if (employeeEarning == null)
            {
                return;
            }

            var existingEarns = masterEmployeeEarnings.Where(a => a.EarningID == employeeEarning.EarningID);

            if (existingEarns.Count() > 1)
            {
                throw new AerishMultipleObjectFoundException<MasterEmployeeEarningBO>(employeeEarning.EarningID);
            }

            var existingEarn = existingEarns.SingleOrDefault();
            if (existingEarn != null)
            {
                existingEarn.RecordStatus = RecordStatus.Frozen;
            }

            employeeEarning.RecordStatus = RecordStatus.Active;

            masterEmployeeEarnings.Add(employeeEarning);

            changeTracker.Add(new ChangeTracker
            {
                Property = nameof(MasterEmployeeEarnings)
            });
        }

        public void AddNewEmployeeDeduction(MasterEmployeeDeductionBO employeeDeduction)
        {
            if (employeeDeduction == null)
            {
                return;
            }

            var existingDeds = masterEmployeeDeductions.Where(a => a.DeductionID == employeeDeduction.DeductionID);

            if (existingDeds.Count() > 1)
            {
                throw new AerishMultipleObjectFoundException<MasterEmployeeDeductionBO>(employeeDeduction.DeductionID);
            }

            var existingDed = existingDeds.SingleOrDefault();
            if (existingDed != null)
            {
                existingDed.RecordStatus = RecordStatus.Frozen;
            }

            employeeDeduction.RecordStatus = RecordStatus.Active;

            masterEmployeeDeductions.Add(employeeDeduction);

            changeTracker.Add(new ChangeTracker
            {
                Property = nameof(MasterEmployeeDeductions)
            });
        }

        public void AddNewEmployeeLoan(MasterEmployeeLoanBO employeeLoan)
        {
            if (employeeLoan == null)
            {
                return;
            }

            var existing = masterEmployeeLoans.Where(a => a.LoanID == employeeLoan.LoanID);

            if (existing.Count() > 1)
            {
                throw new AerishMultipleObjectFoundException<MasterEmployeeLoanBO>(employeeLoan.LoanID);
            }

            var existingDed = existing.SingleOrDefault();
            if (existingDed != null)
            {
                existingDed.RecordStatus = RecordStatus.Frozen;
            }

            employeeLoan.RecordStatus = RecordStatus.Active;

            masterEmployeeLoans.Add(employeeLoan);

            changeTracker.Add(new ChangeTracker
            {
                Property = nameof(MasterEmployeeLoans)
            });
        }

        public void TrackValueChange<TProp>(ref TProp backingStore, TProp value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<TProp>.Default.Equals(backingStore, value))
            {
                return;
            }

            changeTracker.Add(new ChangeTracker
            {
                Property = propertyName,
                OriginalValue = backingStore == null ? null : JsonSerializer.Serialize(backingStore),
                NewValue = value == null ? null : JsonSerializer.Serialize(value)
            });

            backingStore = value;
        }

        public void DropEmployeeEarning(short earningID)
        {
            var existingEarn = masterEmployeeEarnings.SingleOrDefault(a => a.EarningID == earningID);
            if (existingEarn != null)
            {
                existingEarn.RecordStatus = RecordStatus.Frozen;
            }

            changeTracker.Add(new ChangeTracker
            {
                Property = nameof(MasterEmployeeEarnings)
            });
        }



        public void ClearTracker() => changeTracker.Clear();
        public bool HasChanges() => changeTracker.Any();

        public void SetOriginalData(MasterDataBO data)
        {
            if (originalData != null)
            {
                return;
            }

            originalData = data;
        }
    }
}
