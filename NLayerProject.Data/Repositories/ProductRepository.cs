﻿using Microsoft.EntityFrameworkCore;
using NLayerProject.Core.Entities;
using NLayerProject.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }
        public ProductRepository(AppDbContext context) : base (context)
        {

        }
        public async Task<Product> GetWithCategoryByIdAsync(int id)
        {
            var product = await _appDbContext.Products.Include(x => x.Category).FirstOrDefaultAsync(
                d => d.Id == id);

            return product;
        }
    }
}
