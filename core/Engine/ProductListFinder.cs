using System.Threading.Tasks;
using System.Linq;
using PlService;
using System;
using System.Collections.Generic;

namespace Core
{
    public interface IProductListService
    {
        Task<ProductList> GeProducts(string search);
    }

    public class ProductListService : IProductListService
    {
        private readonly IPlService productListService;
        
        public ProductListService ()
        {
            this.productListService = Microsoft.ServiceFabric.Services.Remoting.Client.ServiceProxy.Create<IPlService>(new Uri("fabric:/pl-service/PlService"));
        }

        public async Task<ProductList> GeProducts(string search)
        {
            var result = await this.productListService.GeProducts(search);
            if (result.Items == null)
                result.Items = new List<ProductListItem> ();
            return result;
        }
    }
    
    public interface IProductListFinder
    {
        Task<SearchViewModel> Search(string search);
    }

    public class ProductListFinder : IProductListFinder
    {
        private readonly IProductListService productListService;

        public ProductListFinder(IProductListService productListService)
        {
            this.productListService = productListService;
        }

        public async Task<SearchViewModel> Search(string search)
        {
            var result = await this.productListService.GeProducts(search);
            return new SearchViewModel 
                {
                    Search = search,
                    Items = result
                                .Items
                                .Select (item => item.To())
                                .ToArray()
                };
        }
    }
}

namespace Core 
{
    public static class ProductDetailExtension
    {
        public static SearchItemViewModel To(this ProductListItem item)
        {
            return new SearchItemViewModel
            {
                Code = item.Code,
                Name = item.Name
            };
        }
    }
}