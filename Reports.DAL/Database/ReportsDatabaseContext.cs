using System;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Reports.DAL.Entities;

namespace Reports.DAL.Database
{
    public class ReportsDatabaseContext : DbContext
    {
        public ReportsDatabaseContext(DbContextOptions<ReportsDatabaseContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Problem> Problems { get; set; }
        public DbSet<Report> Reports { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = new SqliteConnectionStringBuilder {DataSource = "MyServer.db"}.ToString();
        
            optionsBuilder.UseSqlite(connectionString);
        }
    }
}