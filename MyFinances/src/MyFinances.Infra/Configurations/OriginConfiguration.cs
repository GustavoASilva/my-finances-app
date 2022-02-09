using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyFinances.Core.SyncedAggregates;

namespace MyFinances.Infra.Configurations
{

    public class OriginConfiguration : IEntityTypeConfiguration<Origin>
    {
        public void Configure(EntityTypeBuilder<Origin> builder)
        {
            builder.HasKey(t => t.Id);
        }
    }
}
