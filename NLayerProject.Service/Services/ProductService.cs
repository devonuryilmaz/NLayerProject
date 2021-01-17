using NLayerProject.Core.Entities;
using NLayerProject.Core.Repositories;
using NLayerProject.Core.Services;
using NLayerProject.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NLayerProject.Service.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        public ProductService(IUnitOfWork unitOfWork, IRepository<Product> repository) : base(unitOfWork, repository)
        {
        }
        public async Task<Product> GetWithCategoryByIdAsync(int id)
        {
            return await _unitOfWork.Products.GetWithCategoryByIdAsync(id);
        }

    }
}
