using G3L.Examples.NTier.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace G3L.Examples.NTier.DAL.Database
{
    public class NTierDbContext : DbContext
    {
        public NTierDbContext()
        {
            
        }
        
        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Visitor> Visitors { get; set; }
        public DbSet<Visit> Visits { get; set; }
    }
}