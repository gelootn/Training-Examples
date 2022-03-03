using MicroServices.CompanyService.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroServices.CompanyService.DAL.Database
{
    public class CompanyServiceDbContext : DbContext
    {
        public CompanyServiceDbContext(DbContextOptions<CompanyServiceDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>()
                .ToTable("Company", t => t.IsTemporal())
                .HasQueryFilter(x => !x.Deleted);

            modelBuilder.Entity<Employee>()
                .ToTable("Employee", t => t.IsTemporal())
                .HasQueryFilter(x => !x.Deleted);

        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
