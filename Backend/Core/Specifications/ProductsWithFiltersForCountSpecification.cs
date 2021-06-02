using Core.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class ProductsWithFiltersForCountSpecification : BaseSpecification<Product>
    {
        public ProductsWithFiltersForCountSpecification(ProductSpecParams productParams) : base(x =>
          (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search)) &&
          (!productParams.BrandId.HasValue || x.ProductBrandId == productParams.BrandId) &&
          (!productParams.TypeId.HasValue || x.ProductTypeId == productParams.TypeId)) // This long logic goes into the Criteria, which is a Where statement (check SpecificationEvaluator)
        {
        }
    }
}
