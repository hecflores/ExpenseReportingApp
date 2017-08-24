using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseReportingApp.Models
{
    public class ExpenseTag
    {
        [SQLite.Net.Attributes.PrimaryKey]
        public String TagName { get; set; }

        public DateTime DateAdded { get; set; }

        

    }
}
