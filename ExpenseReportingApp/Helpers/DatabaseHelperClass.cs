using ExpenseReportingApp.Models;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLiteNetExtensions.Extensions;
namespace ExpenseReportingApp.Helpers
{
    public class DatabaseHelperClass
    {
        public static void CreateDatabase(String _DatabasePath)
        {
            
            if (!CheckFileExists(_DatabasePath).Result)
            {
                
                using (SQLite.Net.SQLiteConnection conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), _DatabasePath))
                {
                    conn.CreateTable<ExpenseReport>();
                    conn.CreateTable<Expense>();
                }
            }
        }
        private static async Task<bool> CheckFileExists(string fileName)
        {
            try
            {
                var store = await Windows.Storage.ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static void Insert(Object _Obj)
        {
            using (SQLite.Net.SQLiteConnection conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), App.DB_PATH))
            {
                conn.RunInTransaction(() =>
                {
                    conn.Insert(_Obj);
                });
            }
        }

        public static async Task InsertAsync(Object _Obj)
        {
            await Task.Run(() =>
            {
                using (SQLite.Net.SQLiteConnection conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), App.DB_PATH))
                {
                    conn.RunInTransaction(() =>
                    {
                        conn.Insert(_Obj);
                    });
                }
            });

        }
        public static void UpdateObject(Object _obj)
        {
            SQLiteConnection db;
            
            using (SQLite.Net.SQLiteConnection conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), App.DB_PATH))
            {
                conn.RunInTransaction(() =>
                {
                });
            }
        }
        public static async Task StartTransaction(Action<SQLiteConnection> Callback)
        {
            
            await Task.Run(() =>
            {
                using (SQLite.Net.SQLiteConnection conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), App.DB_PATH))
                {
                    Callback(conn);
                }
            });
        }
        public static async Task<ObservableCollection<ExpenseReport>> AllExpenseReportsAsync()
        {
            ObservableCollection<ExpenseReport> Reports = null;
            await Task<ObservableCollection<ExpenseReport>>.Run(() =>
            {
                using (SQLite.Net.SQLiteConnection conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), App.DB_PATH))
                {
                    Reports = new ObservableCollection<ExpenseReport>(SQLiteNetExtensions.Extensions.ReadOperations.GetAllWithChildren<ExpenseReport>(conn).ToList());
                }
            });
            return Reports;

        }
        public static void DeleteExpenseReport(ExpenseReport report)
        {
            List<ExpenseReport> Results;
            using (SQLite.Net.SQLiteConnection conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), App.DB_PATH))
            {
                conn.Delete<ExpenseReport>(report.Id);
            }
        }
        public static ObservableCollection<Expense> AllExpensesForReport(ExpenseReport report)
        {
            List<Expense> Results;
            using (SQLite.Net.SQLiteConnection conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), App.DB_PATH))
            {
                Results = conn.Query<Expense>("SELECT * FROM Expense WHERE ReportID="+report.Id).ToList();
                ObservableCollection<Expense> FinalReport = new ObservableCollection<Expense>(Results);
                return FinalReport;
            }
        }
        public static async Task<ExpenseReport> AddExpenseToReport(ExpenseReport report, Expense expense)
        {
            ExpenseReport ReportToUpdate=null;
            report.Expenses.Add(expense);
            await DatabaseHelperClass.StartTransaction((conn) =>
            {
                conn.Insert(expense);
                conn.UpdateWithChildren(report);
                ReportToUpdate = conn.FindWithChildren<ExpenseReport>(report.Id);

            });

            return ReportToUpdate;
        }
        public static async Task<ExpenseReport> RemoveExpenseToReport(ExpenseReport report, Expense expense)
        {
            report.Expenses.Remove(expense);
            ExpenseReport ReportToUpdate = null;
            await DatabaseHelperClass.StartTransaction((conn) =>
            {
                conn.UpdateWithChildren(report);
                ReportToUpdate = conn.FindWithChildren<ExpenseReport>(report.Id);
            });
            

            return ReportToUpdate;
        }
        public static void DeleteExpense(Expense expense)
        {
            List<ExpenseReport> Results;
            using (SQLite.Net.SQLiteConnection conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), App.DB_PATH))
            {
                conn.Delete<Expense>(expense.Id);
            }
        }
    }
}
