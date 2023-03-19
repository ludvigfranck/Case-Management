using Case_Management_Submission_Task.MVVM.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DeviceEntity>()
                .Ignore(d => d.IsReadOnly);

            modelBuilder.Entity<DeviceEntity>()
            .HasData(
                new DeviceEntity { Id = 1, ArticleNumber = Guid.NewGuid(), DeviceName = "IPhone 11", DeviceDescription = "Sturdy IPhone from Apple", Price = 5000 },
                new DeviceEntity { Id = 2, ArticleNumber = Guid.NewGuid(), DeviceName = "IPhone 12", DeviceDescription = "Sturdy IPhone from Apple", Price = 6000 },
                new DeviceEntity { Id = 3, ArticleNumber = Guid.NewGuid(), DeviceName = "IPhone 10", DeviceDescription = "Sturdy IPhone from Apple", Price = 4000 },
                new DeviceEntity { Id = 4, ArticleNumber = Guid.NewGuid(), DeviceName = "IPhone 11 Pro", DeviceDescription = "Sturdy IPhone from Apple", Price = 5500 },
                new DeviceEntity { Id = 5, ArticleNumber = Guid.NewGuid(), DeviceName = "IPhone 12 Pro", DeviceDescription = "Sturdy IPhone from Apple", Price = 6500 },
                new DeviceEntity { Id = 6, ArticleNumber = Guid.NewGuid(), DeviceName = "IPhone 10 Pro", DeviceDescription = "Sturdy IPhone from Apple", Price = 4500 }
                );

            modelBuilder.Entity<CustomerDeviceEntity>()
            .HasKey(cd => new { cd.CustomerId, cd.DeviceId });

            modelBuilder.Entity<CaseEntity>()
            .HasKey(c => new { c.CustomerId, c.DeviceId, c.CaseId });

            modelBuilder.Entity<CaseEntity>()
            .HasOne(c => c.CustomerDevice)
            .WithMany(cd => cd.Cases)
            .HasForeignKey(c => new { c.CustomerId, c.DeviceId });
        }

        public DbSet<AddressEntity> Addresses { get; set; } = null!;
        public DbSet<CustomerEntity> Customers { get; set; } = null!;
        public DbSet<DeviceEntity> Devices { get; set; } = null!;
        public DbSet<CaseEntity> Cases { get; set; } = null!;
        public DbSet<CustomerDeviceEntity> CustomersDevices { get; set; } = null!;
    }
}
