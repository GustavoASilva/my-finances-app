using Microsoft.EntityFrameworkCore;
using MyFinances.Core.Aggregates;

namespace MyFinances.Infra
{
    public class AppDbContext : DbContext
    {
        public DbSet<Transaction> Schedules { get; set; }
        public DbSet<TransactionCategory> Categories { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}