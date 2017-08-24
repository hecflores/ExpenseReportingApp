using ExpenseReportingApp.Helpers;
using ExpenseReportingApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace ExpenseReportingApp.ViewModels
{
    public class ExpenseReportViewModel : Libraries.ViewModelBase
    {
        

        

        private ExpenseReport _SelectedExpenseReport = null;
        public ExpenseReport SelectedExpenseReport { get => _SelectedExpenseReport;
                                                     set
            {
                Set<ExpenseReport>(ref _SelectedExpenseReport, value);
                //if (SelectedExpenseReport == null)
                //{
                //    ExpensesViewModel = null;
                //    return;
                //}
                //ExpensesViewModel = new ExpensesViewModel(this); //  I hate this!
            }}

        private bool _IsEditing = false;
        public bool IsEditing { get => _IsEditing; set => Set<bool>(ref _IsEditing , value); }

        private String _AddingStatus = "Ready";
        public String AddingStatus { get => _AddingStatus;
                                     set => Set<String>(ref _AddingStatus, value); }

        private String _NameOfAddingReport = "";
        public string NameOfAddingReport { get => _NameOfAddingReport;
                                           set => Set<String>(ref _NameOfAddingReport , value); }
        

        private ObservableCollection<ExpenseReport> _ExpenseReports = new ObservableCollection<ExpenseReport>();
        public ObservableCollection<ExpenseReport> ExpenseReports{ get => _ExpenseReports;
                                                        set => Set<ObservableCollection<ExpenseReport>>(ref _ExpenseReports, value); }
       
        private DelegateCommand _AddExpenseReport;
        public DelegateCommand AddExpenseReport
            => _AddExpenseReport ?? (_AddExpenseReport = new DelegateCommand(async () =>
            {
                /***********************************************************/
                /* Insert the Expense Report                               */
                /***********************************************************/
                AddingStatus = "Adding...";
                await DatabaseHelperClass.InsertAsync(new ExpenseReport(_NameOfAddingReport));
                AddingStatus = "Ready";

                /***********************************************************/
                /* Update the Expense Reports                              */
                /***********************************************************/
                LoadReport.Execute();

            }, () => AddingStatus.Equals("Ready")));

        private DelegateCommand _LoadReport;
        public DelegateCommand LoadReport
            => _LoadReport ?? (_LoadReport = new DelegateCommand(async () =>
            {
                AddingStatus = "Loading...";
                this.ExpenseReports = await DatabaseHelperClass.AllExpenseReportsAsync();
                AddingStatus = "Ready";
                

            }, () => AddingStatus.Equals("Ready")));

        private DelegateCommand _Delete;
        public DelegateCommand Delete
            => _Delete ?? (_Delete = new DelegateCommand( () =>
            {
                ExpenseReport deletingExpense = this.SelectedExpenseReport;
                DatabaseHelperClass.DeleteExpenseReport(deletingExpense);
                this.LoadReport.Execute();

            }, () => true));

        
    }
    
}
