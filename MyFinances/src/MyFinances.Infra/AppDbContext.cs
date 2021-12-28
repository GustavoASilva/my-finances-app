using Microsoft.EntityFrameworkCore;
using MyFinances.Core.Aggregates;
using MyFinances.Core.Aggregates.HouseholdAggregate;
using System.Reflection;

namespace MyFinances.Infra
{
    public class AppDbContext : DbContext
    {
        public DbSet<Household> Households { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}