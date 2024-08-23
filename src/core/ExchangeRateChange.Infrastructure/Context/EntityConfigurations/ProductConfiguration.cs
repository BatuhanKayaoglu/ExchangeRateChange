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
    public class ProductConfiguration : BaseEntityConfiguration<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            base.Configure(builder);

            builder.ToTable("Product", ExchangeRateChangeContext.DEFAULT_SCHEMA);

            builder.Property(e => e.Price)
                   .IsRequired();

            builder.Property(e => e.Name)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(e => e.SerialNumber)
                   .HasMaxLength(100)
                   .IsRequired();

            //builder.Property(e => e.NewPrice)
            //       .HasColumnType("decimal(18, 4)");

            //builder.Property(e => e.ExchangeSellRate)
            //       .HasColumnType("decimal(18, 4)");
        }
    }

}
