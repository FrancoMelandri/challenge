using PlService;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace UiService.Engine 
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
}