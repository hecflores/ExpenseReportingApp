using ExpenseReportingApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace ExpenseReportingApp.Converters
{
    class ExpensReportTotalAmount : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if(!(value is Collection<Expense>))
            {
                return "N/A";
            }
            return (value as Collection<Expense>).Sum(b => b.Amount) + "$";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
