using System.Collections.Generic;

namespace PlService
{
    public class ProductList
    {
        public string Search { get; set; }
        public List<ProductListItem> Items { get; set; }
    }

    public class ProductListItem
    {
        public string Name { get; set; }
    }
}