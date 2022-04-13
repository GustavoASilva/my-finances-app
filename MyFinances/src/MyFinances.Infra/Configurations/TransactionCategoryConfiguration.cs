using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyFinances.Core.SyncedAggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinances.Infra.Configurations
{
    public class TransactionCategoryConfiguration : IEntityTypeConfiguration<TransactionCategory>
    {
        public void Configure(EntityTypeBuilder<TransactionCategory> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasData(TransactionCategory.List());
        }
    }
}
