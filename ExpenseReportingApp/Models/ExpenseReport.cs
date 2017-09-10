using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseReportingApp.Models
{
    public class ExpenseReport : INotifyPropertyChanged
    {
        // This method is called by the Set accessor of each property.
        // The CallerMemberName attribute that is applied to the optional propertyName
        // parameter causes the property name of the caller to be substituted as an argument.
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [SQLite.Net.Attributes.PrimaryKey, SQLite.Net.Attributes.AutoIncrement]
        public int Id { get; set; }
        public DateTime Added { get; set; }
        public String Name { get; set; }

        private ObservableCollection<Expense> _Expenses = null;
        [SQLiteNetExtensions.Attributes.OneToMany(CascadeOperations = SQLiteNetExtensions.Attributes.CascadeOperation.All)]
        public ObservableCollection<Expense> Expenses
        {
            get => _Expenses;
            set
            {
                if (_Expenses != null)
                {
                    _Expenses.CollectionChanged -= CollectionChangedEvent;
                }
                _Expenses = value == null ? new ObservableCollection<Expense>() : value;
                if (_Expenses != null)
                {
                    _Expenses.CollectionChanged += CollectionChangedEvent;
                    OnExpensesChanged();
                }
                NotifyPropertyChanged();


            }
        }
        private double _Amount = 0;
        public double Amount
        { get => _Amount;
            set {
                _Amount = value;
                NotifyPropertyChanged();
            }
        }

        private event System.Collections.Specialized.NotifyCollectionChangedEventHandler CollectionChangedEvent;
        public ExpenseReport() : this("Unkown") { }
        public ExpenseReport(String name)
        {
            this.Name = name;
            Added = DateTime.Now;

            /***************************************************************/
            CollectionChangedEvent += (sender, arg) => {
                OnExpensesChanged();
            };

            Expenses = new ObservableCollection<Expense>();

        }
        private void OnExpensesChanged()
        {
            Amount = Expenses.Sum(b => b.Amount);
            NotifyPropertyChanged("Expenses");
        }
    }
}
