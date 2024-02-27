using Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(100);
            builder.Property(x => x.Sku).HasMaxLength(255);

            // mapping value obeject in database
            builder.Property(x => x.Sku).HasConversion(sku => sku.Value, value => Sku.Create(value)!);

            // set Price_Currencey and Price_Amount in table
            builder.OwnsOne(x=>x.Price,
                priceBulider=>priceBulider.Property(p=>p.Currency).HasMaxLength(3));
        }
    }
}
