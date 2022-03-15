using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyFinances.Core.SyncedAggregates;
using MyFinances.Core.TransactionAggregate;

namespace MyFinances.Infra.Configurations
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(t => t.Id);
            builder.HasOne<Origin>()
                .WithMany()
                .HasForeignKey(p => p.OriginId);
        }
    }
}