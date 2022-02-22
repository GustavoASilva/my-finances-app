using MediatR;
using Microsoft.EntityFrameworkCore;
using MyFinances.Core;
using MyFinances.Core.SyncedAggregates;
using MyFinances.Core.TransactionAggregate;
using System.Reflection;

namespace MyFinances.Infra
{
    public class AppDbContext : DbContext
    {
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Origin> Origins { get; set; }
        public DbSet<Recurrence> Recurrences { get; set; }

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

            // ignore events if no dispatcher provided
            if (_mediator == null) return result;

            var entitiesWithEvents = ChangeTracker
                .Entries()
                .Select(e => e.Entity as BaseEntity<Guid>)
                .Where(e => e?.DomainEvents != null && e.DomainEvents.Any())
                .ToArray();

            foreach (var entity in entitiesWithEvents)
            {
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