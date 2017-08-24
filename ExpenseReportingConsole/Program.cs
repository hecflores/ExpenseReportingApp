using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseReportingConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ExpenseReportsService.ExpenseReportsServiceClient client = new ExpenseReportsService.ExpenseReportsServiceClient();
            client.Open();
            
            Console.WriteLine("All Done");
            Console.WriteLine();
            Console.WriteLine("Adding Report...");
            client.AddExpenseReport(new ExpenseReportsService.ExpenseReport() { Name = "Hector", Added = DateTime.Now });

            Console.WriteLine();
            Console.WriteLine("Query Reports...");
            var items = client.QueryExpenseReports();
            foreach (ExpenseReportsService.ExpenseReport  report in items)
            {
                Console.WriteLine("Found: " + report.Name);
            }
            var DeleteThisItem = items.FirstOrDefault();
            if (DeleteThisItem == null)
            {
                Console.WriteLine("Something Failed... Expected atleast one item in the list");
                return;
            }
            Console.WriteLine();
            Console.WriteLine("Deleteing A Reports");

            client.DeleteExpenseReport(DeleteThisItem);

            Console.WriteLine();
            Console.WriteLine("Query Reports...");
            items = client.QueryExpenseReports();
            foreach (ExpenseReportsService.ExpenseReport report in items)
            {
                Console.WriteLine("Found: " + report.Name);
            }
            Console.WriteLine("Press Enter to exit");
            Console.ReadLine();
            client.Close();
        }
    }
}
