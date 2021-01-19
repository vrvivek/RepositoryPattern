using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryPattern.Models
{
    public partial class EmployeeDBContext : DbContext
    {
        public EmployeeDBContext()
        {
        }
        public EmployeeDBContext(DbContextOptions<EmployeeDBContext> options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot config = builder.Build();
            optionsBuilder.UseSqlServer(config.GetConnectionString("EmployeeDB"));
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EID);

                entity.ToTable("Employee");

                entity.Property(e => e.EID).HasColumnName("E_ID");

                entity.Property(e => e.EName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("E_Name");

                entity.Property(e => e.EGender)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("E_Gender");

                entity.Property(e => e.ESalary).HasColumnName("E_Salary");

                entity.Property(e => e.EDept)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("E_Dept") ;
            });

        }
    }
}
