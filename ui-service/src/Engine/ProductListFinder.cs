
namespace UiService.Engine 
{
    public interface IProductListFinder
    {

    }

    public class ProductListFinder : IProductListFinder
    {
        private readonly IProductListService productListService;

        public ProductListFinder(IProductListService productListService)
        {
            this.productListService = productListService;
        }
    }
}