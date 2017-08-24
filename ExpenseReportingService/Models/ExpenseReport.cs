using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseReportingService.Models
{
    public class ExpenseReport 
    {
        public int ExpenseReportId { get; set; }

        public DateTime Added { get; set; }

        public String Name { get; set; }

        //[System.ComponentModel.DataAnnotations.Schema.InverseProperty("ReportID")]
        //public ObservableCollection<Expense> Expenses { get; set; }

        

        
    }
}
