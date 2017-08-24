using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseReportingService.Models
{
    public class Expense
    {
        [Key]
        public int Id { get; set; }

        public DateTime Added { get; set; }

        public String Name { get; set; }

        public int Amount { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("ReportID")]
        public int ReportID { get; set; }

        
        public ExpenseReport Report { get; set; }

    }
}
