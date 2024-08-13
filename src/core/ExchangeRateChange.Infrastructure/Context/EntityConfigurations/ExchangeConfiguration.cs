using ExchangeRateChange.Entity.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus.DataSets;

namespace ExchangeRateChange.Infrastructure.Context.EntityConfigurations
{
    public class ExchangeConfiguration : BaseEntityConfiguration<Exchange>
    {
        public override void Configure(EntityTypeBuilder<Exchange> builder)
        {
            base.Configure(builder);

            builder.ToTable("Exchange", ExchangeRateChangeContext.DEFAULT_SCHEMA);

            builder.Property(e => e.Price)
                   .IsRequired();

            builder.Property(e => e.Name)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(e => e.ExchageType)
                   .IsRequired();

            builder.Property(e => e.ExchangeName)
                   .HasMaxLength(100)
                   .IsRequired();

        }
    }

}
