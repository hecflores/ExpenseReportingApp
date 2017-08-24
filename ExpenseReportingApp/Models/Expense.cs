using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseReportingApp.Models
{
    public class Expense
    {
        [SQLite.Net.Attributes.PrimaryKey, SQLite.Net.Attributes.AutoIncrement]
        public int Id { get; set; }
        public DateTime Added { get; set; }
        public String Name { get; set; }
        public int Amount { get; set; }

        [SQLiteNetExtensions.Attributes.ForeignKey(typeof(ExpenseReport))]
        public int ReportID { get; set; }

        [SQLiteNetExtensions.Attributes.ManyToOne(CascadeOperations =SQLiteNetExtensions.Attributes.CascadeOperation.All)]
        public ExpenseReport Report { get; set; }


        public Expense()
        {
            Added = DateTime.Now;
        }

        public Expense(String name, int Amount)
        {
            this.Name = name;
            this.Amount = Amount;
            this.Added = DateTime.Now;
        }

    }
}
