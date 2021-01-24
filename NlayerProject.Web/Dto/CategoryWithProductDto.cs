using NLayerProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerProject.Web.Dto
{
    public class CategoryWithProductDto : CategoryDto
    {
        public ICollection<ProductDto> Products { get; set; }
    }
}
