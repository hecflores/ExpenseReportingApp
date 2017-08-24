using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace ExpenseReportingApp.Converters
{
    public class IsSelectedConverter : IValueConverter
    {
        public bool Falsify { get; set; }
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
            {
                return Falsify;
            }
            return !Falsify;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
