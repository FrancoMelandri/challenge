using PdService;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace Core
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
    
    public interface IProductDetailsProvider
    {
        Task<ProductDetailsViewModel> GetDetail(string code);
    }

    public class ProductDetailsProvider : IProductDetailsProvider
    {
        private readonly IProductDetailsService productDetailsService;

        public ProductDetailsProvider (IProductDetailsService productDetailsService)
        {
            this.productDetailsService = productDetailsService;
        }
        
        public async Task<ProductDetailsViewModel> GetDetail(string code)
        {
            var itemDetail = await this.productDetailsService.GetDetail(code);
            return new ProductDetailsViewModel {
                Name = itemDetail.Name,
                Code = itemDetail.Code,
                Description = itemDetail.Description,
                Brand = itemDetail.Brand
            };
        }
    }
}