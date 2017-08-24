using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseReportingApp.Models
{
    public class ExpenseReport 
    {
        [SQLite.Net.Attributes.PrimaryKey, SQLite.Net.Attributes.AutoIncrement]
        public int Id { get; set; }
        public DateTime Added { get; set; }
        public String Name { get; set; }

        [SQLiteNetExtensions.Attributes.OneToMany(CascadeOperations =SQLiteNetExtensions.Attributes.CascadeOperation.All)]
        public ObservableCollection<Expense> Expenses { get; set; }

        

        public ExpenseReport()
        {
            Added = DateTime.Now;
            Expenses = new ObservableCollection<Expense>();
        }
        public ExpenseReport(String name)
        {
            this.Name = name;
            Added = DateTime.Now;
            Expenses = new ObservableCollection<Expense>();
        }
    }
}
