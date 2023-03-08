using Case_Management_Submission_Task.MVVM.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Case_Management_Submission_Task.Contexts
{
    internal class DataContext : DbContext
    {
        private readonly string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\VisualStudioProjects\Submission_Tasks\00_Submission_Task_Case_Management\Case_Management_Submission_Task\Contexts\sql_db_case_management.mdf;Integrated Security=True;Connect Timeout=30";

        public DataContext()
        {
        }
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(_connectionString);
        }

        public DbSet<AddressEntity> Addresses { get; set; } = null!;
        public DbSet<CustomerEntity> Customers { get; set; } = null!;
        public DbSet<DeviceEntity> Devices { get; set; } = null!;
        public DbSet<CaseEntity> Cases { get; set; } = null!;
    }
}
