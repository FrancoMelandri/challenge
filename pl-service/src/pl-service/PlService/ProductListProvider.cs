using System.Collections.Generic;
using System.Linq;
using data;

namespace PlService
{
    public interface IProductListProvider
    {
        ProductList Get(string search);
    }

    public class ProductListProvider : IProductListProvider
    {
        public ProductList Get(string search)
        {
            return new ProductList
            {
                Search = search,
                Items = data
                            .Catalog
                            .Items
                            .Where(filter => filter.Name.Contains(search))
                            .Select(item => item.To())
                            .ToList()
            }; 
        }        
    }
}

namespace PlService
{
    public static class ItemExtension
    {
        public static ProductListItem To(this Item item)
        {
            return new ProductListItem
            {
                Code = item.Code,
                Name = item.Name
            };
        }
    }
}