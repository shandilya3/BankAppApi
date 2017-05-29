using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BankAPI.Models;
using MySql.Data.MySqlClient;
using MySQL.Data.Entity.Extensions;

namespace BankAPI.Dal
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = Environment.GetEnvironmentVariable("BankAppCoonectionString");
              var connBuilder = new MySqlConnectionStringBuilder(connectionString) { AllowUserVariables = true, ConnectionReset = true };
           optionsBuilder.UseMySQL(connBuilder.GetConnectionString(true));
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Customer> Customers { get; set; }
    }
}
