using ExpenseReportingApp.Helpers;
using ExpenseReportingApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace ExpenseReportingApp.Views
{
    public sealed partial class ExpenseReportUserControl : UserControl
    {
        public ExpenseReportUserControl()
        {
            this.InitializeComponent();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ExpenseReport deletingExpense = (sender as Button).Tag as ExpenseReport;
            DatabaseHelperClass.DeleteExpenseReport(deletingExpense);
            this.Context.LoadReport.Execute();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
    
}
