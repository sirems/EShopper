using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Entities;
using Ardalis.Specification;

namespace ApplicationCore.Specifications
{
    public class ProductsFilterSpecification : BaseSpecification<Product>
    {
        public ProductsFilterSpecification(int? categoryId, int? brandId)
        {
            AddCriteria(x => (!categoryId.HasValue || x.CategoryId == categoryId)
                           && (!brandId.HasValue || x.BrandId == brandId));
        }
    }
}
