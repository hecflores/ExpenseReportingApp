using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace ExpenseReportingService.Models
{
    public class ExpenseContext : DbContext
    {
        public DbSet<ExpenseReport> ExpenseReports { get; set; }
    }
}
