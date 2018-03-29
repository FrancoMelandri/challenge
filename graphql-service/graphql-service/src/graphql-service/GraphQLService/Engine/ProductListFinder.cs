using System.Threading.Tasks;
using System.Linq;
using PlService;

namespace GraphQLService
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
                    Search = search,
                    Items = result
                                .Items
                                .Select (item => item.To())
                                .ToArray()
                };
        }
    }
}

namespace GraphQLService 
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