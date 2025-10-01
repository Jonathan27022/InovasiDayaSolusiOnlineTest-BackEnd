using System.Linq;
using Microsoft.EntityFrameworkCore;
using OnlineTestPTInovasiDayaSolusi.Models;

namespace OnlineTestPTInovasiDayaSolusi.Data
{
    public class DataSeed
    {
        public static void Seed(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<DbApi>();
                if (context == null)
                {
                    return;
                }

                context.Database.EnsureCreated();

                if (!context.Statuses.Any())
                {
                    var statuses = new List<Status>() {
                        new Status() {id = 0, name = "Success"},
                        new Status() {id = 1, name = "Failed"}
                        };
                    context.Statuses.AddRange(statuses);
                    context.SaveChanges();
                }
                if(!context.Transactions.Any())
                {
                    var transactions = new List<Transaction>() {
                        new Transaction {productID = "10001", productName = "Test 1", amount = 1000, customerName = "abc", status = 0, transactionDate = DateTime.Parse("2022-07-10 11:14:52"), createBy = "abc", createOn = DateTime.Parse("2022-07-10 11:14:52") },
                        new Transaction {productID = "10002", productName = "Test 2", amount = 2000, customerName = "abc", status = 0, transactionDate = DateTime.Parse("2022-07-11 13:14:52"), createBy = "abc", createOn = DateTime.Parse("2022-07-10 13:14:52") }
                    };
                    context.Transactions.AddRange(transactions);
                    context.SaveChanges();
                }
            }
        }
    }
}
