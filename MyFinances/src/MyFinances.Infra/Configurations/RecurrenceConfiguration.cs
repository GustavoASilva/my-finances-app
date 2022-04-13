using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyFinances.Core.SyncedAggregates;

namespace MyFinances.Infra.Configurations
{
    public class RecurrenceConfiguration : IEntityTypeConfiguration<Recurrence>
    {
        public void Configure(EntityTypeBuilder<Recurrence> builder)
        {
            builder.HasKey(t => t.Id);

            builder
            .Property<int>("_transactionCategoryId")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("TransactionCategoryId")
            .IsRequired();

            builder.HasOne(p => p.TransactionCategory)
                .WithMany()
                .HasForeignKey("_transactionCategoryId");
        }
    }
}
