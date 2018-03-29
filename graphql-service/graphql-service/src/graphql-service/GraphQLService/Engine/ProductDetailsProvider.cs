using PdService;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace GraphQLService
{
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