using System.Threading.Tasks;
using UiService.Models;
using System.Linq;
using PlService;

namespace UiService.Engine 
{
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
                    Items = result
                                .Items
                                .Select (item => item.To())
                                .ToArray()
                };
        }
    }
}

namespace UiService.Engine 
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