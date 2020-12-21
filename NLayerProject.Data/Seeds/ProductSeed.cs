using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayerProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLayerProject.Data.Seeds
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        private readonly int[] _ids;
        public ProductSeed(int[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product
                {
                    Id = 1,
                    Name = "Kurşun Kalem",
                    Price = 12.50m,
                    Stock = 100,
                    CategoryId = _ids[0]
                },
                new Product
                {
                    Id = 2,
                    Name = "Pilot Kalem",
                    Price = 25.50m,
                    Stock = 50,
                    CategoryId = _ids[0]
                }, 
                new Product
                {
                    Id = 3,
                    Name = "Tükenmez Kalem",
                    Price = 50m,
                    Stock = 20,
                    CategoryId = _ids[0]
                }, 
                new Product
                {
                    Id = 4,
                    Name = "Küçük Defter",
                    Price = 12.50m,
                    Stock = 100,
                    CategoryId = _ids[1]
                },
                new Product
                {
                    Id = 5,
                    Name = "OrtaDefter",
                    Price = 17.50m,
                    Stock = 100,
                    CategoryId = _ids[1]
                },
                new Product
                {
                    Id = 6,
                    Name = "Büyük Defter",
                    Price = 20m,
                    Stock = 100,
                    CategoryId = _ids[1]
                });
        }
    }
}
