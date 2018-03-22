using System.Collections.Generic;
using System.Linq;
using System;
using data;
using Utils;

namespace PdService
{
    public interface IProductDetailProvider
    {
        ProductDetail Get(string code);
    }

    public class ProductDetailProvider : IProductDetailProvider
    {
        public ProductDetail Get(string code)
        {
            return data
                        .Catalog
                        .Items
                        .FirstOrDefault(item => item.Code.Equals(code))
                        .ToOption()
                        .Match<ProductDetail>(item => item.To(),
                                              () =>  ProductDetail.Empty() );
        }        
    }
}

namespace PdService
{
    public static class ItemExtension
    {
        public static ProductDetail To(this Item item)
        {
            return new ProductDetail
            {
                Code = item.Code,
                Name = item.Name,
                Description = item.Description,
                Brand = item.Brand
            };
        }
    }
}
