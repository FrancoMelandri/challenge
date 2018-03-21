using PlService;
using System.Threading.Tasks;
using System;

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

        public Task<ProductList> GeProducts(string search)
        {
            return this.productListService.GeProducts(search);
        }
    }
}