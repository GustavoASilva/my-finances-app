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
    public class RecurrenceConfiguration : IEntityTypeConfiguration<Recurrence>
    {
        public void Configure(EntityTypeBuilder<Recurrence> builder)
        {
            builder.HasKey(t => t.Id);
        }
    }
}
