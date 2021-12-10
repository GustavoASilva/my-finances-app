using Microsoft.EntityFrameworkCore;
using MyFinances.Core.Aggregates;
using MyFinances.Core.Aggregates.ScheduleAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinances.Infra
{
    public class AppDbContext : DbContext
    {
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Category> Categories { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}