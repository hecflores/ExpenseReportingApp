using ExpenseReportingApp.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseReportingApp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ExpensesViewModel _ExpensesViewModel = new ExpensesViewModel();
        public ExpensesViewModel ExpensesViewModel
        {
            get => _ExpensesViewModel;
            set => Set<ExpensesViewModel>(ref _ExpensesViewModel, value);
        }

        private ExpenseReportViewModel _ExpenseReportViewModel = new ExpenseReportViewModel();
        public ExpenseReportViewModel ExpenseReportViewModel
        {
            get => _ExpenseReportViewModel;
            set => Set<ExpenseReportViewModel>(ref _ExpenseReportViewModel, value);
        }
        public MainViewModel()
        {
            ExpenseReportViewModel.PropertyChanged += (sender, arg) =>
            {
                if (arg.PropertyName == "SelectedExpenseReport")
                {
                    ExpensesViewModel.Report = ExpenseReportViewModel.SelectedExpenseReport;
                }
            };
        }

    }
}
