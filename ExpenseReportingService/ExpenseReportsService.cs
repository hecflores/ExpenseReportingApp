using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ExpenseReportingService.Models;
using System.Data.SqlClient;
using System.Data;

namespace ExpenseReportingService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class ExpenseReportsService : IExpenseReportsService
    {
        public String SqlConStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ExpenseReporter;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public string GetData(int value)
        {
            throw new NotImplementedException();
        }

        public void Initilize()
        {
            
            using (ExpenseContext db = new ExpenseContext())
            {
                db.Database.Connection.ConnectionString = "Data Source=mainstorage.database.windows.net;Initial Catalog=ExpenseReportingDatabase;Integrated Security=False;User ID=HECFLORES1993;Password=Armandorocha1-;Connect Timeout=15;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                db.ExpenseReports.Create();
                
                
            }
        }

        public IList<ExpenseReport> QueryExpenseReports()
        {
            using (ExpenseContext db = new ExpenseContext())
            {
                db.Database.Connection.ConnectionString = "Data Source=mainstorage.database.windows.net;Initial Catalog=ExpenseReportingDatabase;Integrated Security=False;User ID=HECFLORES1993;Password=Armandorocha1-;Connect Timeout=15;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                return db.ExpenseReports.ToList();
            }
        }

        public void AddExpenseReport(ExpenseReport report)
        {
            using (ExpenseContext db = new ExpenseContext())
            {
                db.Database.Connection.ConnectionString = "Data Source=mainstorage.database.windows.net;Initial Catalog=ExpenseReportingDatabase;Integrated Security=False;User ID=HECFLORES1993;Password=Armandorocha1-;Connect Timeout=15;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                db.ExpenseReports.Add(report);
                db.SaveChanges();
            }
        }

        public void DeleteExpenseReport(ExpenseReport report)
        {
            using (ExpenseContext db = new ExpenseContext())
            {
                db.Database.Connection.ConnectionString = "Data Source=mainstorage.database.windows.net;Initial Catalog=ExpenseReportingDatabase;Integrated Security=False;User ID=HECFLORES1993;Password=Armandorocha1-;Connect Timeout=15;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                ExpenseReport foundItem = db.ExpenseReports.Find(report.ExpenseReportId);
                if (foundItem != null)
                {
                    db.ExpenseReports.Remove(foundItem);
                }
                db.SaveChanges();
            }
        }
    }
}
