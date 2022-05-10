using MediatR;
using Microsoft.EntityFrameworkCore;
using MyFinances.Core;
using MyFinances.Core.Aggregates;
using MyFinances.Core.SyncedAggregates;
using MyFinances.Core.TransactionAggregate;
using System.Reflection;

namespace MyFinances.Infra
{
    public class AppDbContext : DbContext
    {
        public DbSet<Transaction> Transactions => Set<Transaction>();
        public DbSet<Origin> Origins => Set<Origin>();
        public DbSet<Recurrence> Recurrences => Set<Recurrence>();
        public DbSet<User> Users => Set<User>();

        private readonly IMediator _mediator;

        public AppDbContext(DbContextOptions options, IMediator mediator) : base(options)
        {
            _mediator = mediator;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            int result = 0;

            if (_mediator == null) return result;

            var entitiesWithEvents = ChangeTracker
                .Entries()
                .Select(e => e.Entity as BaseEntity<Guid>)
                .Where(e => e != null && e.DomainEvents != null && e.DomainEvents.Any())
                .ToArray();

            foreach (var entity in entitiesWithEvents)
            {
                if (entity == null)
                    continue;

                var events = entity.DomainEvents.ToArray();

                entity.DomainEvents.Clear();
                foreach (var domainEvent in events)
                {
                    await _mediator.Publish(domainEvent).ConfigureAwait(false);
                }
            }

            result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            return result;
        }
    }
}