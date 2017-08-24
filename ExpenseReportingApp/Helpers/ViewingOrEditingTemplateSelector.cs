using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ExpenseReportingApp.Helpers
{
    public class ViewingOrEditingTemplateSelector : DataTemplateSelector
    {
        private bool _IsEditing = false;
        public bool IsEditing { get=>_IsEditing; set => _IsEditing = value; }
        public DataTemplate Viewing { get; set; }
        public DataTemplate Editing { get; set; }

        protected override DataTemplate SelectTemplateCore(object item)
        {
            if (IsEditing)
            {
                return Editing;
            }
            return Viewing;
        }
        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            if (IsEditing)
            {
                return Editing;
            }
            return Viewing;
        }
    }
}
