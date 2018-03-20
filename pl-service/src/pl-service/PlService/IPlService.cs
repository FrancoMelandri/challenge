using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Remoting;

namespace PlService
{
    public interface IPlService : IService
    {
        Task<ProductList> GeProducts(string search);
    }
}