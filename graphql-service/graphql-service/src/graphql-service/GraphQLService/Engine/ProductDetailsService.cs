using PdService;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace GraphQLService
{
    public interface IProductDetailsService
    {
        Task<ProductDetail> GetDetail(string code);
    }

    public class ProductDetailsService : IProductDetailsService
    {
        private readonly IPdService productDetailsService;
        
        public ProductDetailsService ()
        {
            this.productDetailsService = Microsoft.ServiceFabric.Services.Remoting.Client.ServiceProxy.Create<IPdService>(new Uri("fabric:/pd-service/PdService"));
        }

        public async Task<ProductDetail> GetDetail(string code)
        {
            return await this.productDetailsService.GetDetail(code);
        }
    }
}