using ExpenseReportingApp.Helpers;
using ExpenseReportingApp.Libraries;
using ExpenseReportingApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net;
using SQLiteNetExtensions.Extensions;
namespace ExpenseReportingApp.ViewModels
{
    public class ExpensesViewModel : ViewModelBase
    {
        private ExpenseReport _Report = null;
        public ExpenseReport Report { get => _Report; set => Set<ExpenseReport>(ref _Report, value); }

        private Expense _SelectedExpense = null;
        public Expense SelectedExpense { get => _SelectedExpense; set => Set<Expense>(ref _SelectedExpense, value); }

        private bool _IsEditing = false;
        public bool IsEditing { get => _IsEditing; set => Set<bool>(ref _IsEditing, value); }

        private String _AddingStatus = "Ready";
        public String AddingStatus
        {
            get => _AddingStatus;
            set => Set<String>(ref _AddingStatus, value);
        }

        private String _NameOfAddingExpense = "";
        public string NameOfAddingExpense
        {
            get => _NameOfAddingExpense;
            set => Set<String>(ref _NameOfAddingExpense, value);
        }
        private int _AmountOfAddingExpense = 0;
        public int AmountOfAddingExpense
        {
            get => _AmountOfAddingExpense;
            set => Set<int>(ref _AmountOfAddingExpense, value);
        }

        //private ObservableCollection<Expense> _Expenses = new ObservableCollection<Expense>();
        //public ObservableCollection<Expense> Expenses
        //{
        //    get => _Expenses;
        //    set => Set<ObservableCollection<Expense>>(ref _Expenses, value);
        //}

        private DelegateCommand _AddExpense;

        public DelegateCommand AddExpense
            => _AddExpense ?? (_AddExpense = new DelegateCommand(async () =>
            {
                AddingStatus = "Adding...";

                /***********************************************************/
                /* Add the Expense to the Local Objects List of Expenses   */
                /***********************************************************/
                Expense expense = new Expense(NameOfAddingExpense, AmountOfAddingExpense);
                ExpenseReport ReportToUpdate = await DatabaseHelperClass.AddExpenseToReport(Report, expense);

                /***********************************************************/
                /* Load the new Expenses for this report                   */
                /***********************************************************/
                AddingStatus = "Ready";

                /***********************************************************/
                /* Update the Expense Reports.(I dont like this part)      */
                /***********************************************************/
                //int index = _ExpenseReportViewModel.ExpenseReports.IndexOf(ExpenseReportViewModel.SelectedExpenseReport);
                //_ExpenseReportViewModel.ExpenseReports[index] = ReportToUpdate; // Update Report
                //ExpenseReportViewModel.SelectedExpenseReport = ReportToUpdate;  // Reselect the Report

            }, () => true));

        

        private DelegateCommand _Delete;
        public DelegateCommand Delete
            => _Delete ?? (_Delete = new DelegateCommand(async () =>
            {
                AddingStatus = "Deleting...";

                /***********************************************************/
                /* Removing the Expense to the Local Objects List of Expens*/
                /***********************************************************/
                ExpenseReport ReportToUpdate = await DatabaseHelperClass.RemoveExpenseToReport(Report, SelectedExpense);
                
                /***********************************************************/
                /* Update the Expense Reports.(I dont like this part)      */
                /***********************************************************/
                //int index =_ExpenseReportViewModel.ExpenseReports.IndexOf(ExpenseReportViewModel.SelectedExpenseReport);
                //_ExpenseReportViewModel.ExpenseReports[index] = ReportToUpdate;
                //ExpenseReportViewModel.SelectedExpenseReport = ReportToUpdate;

                AddingStatus = "Ready";
            }, () => true));

        public ExpensesViewModel()
        {

        }
       
    }
}
