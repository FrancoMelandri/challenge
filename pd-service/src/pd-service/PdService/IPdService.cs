using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Remoting;

namespace PdService
{
    public interface IPdService : IService
    {
        Task<ProductDetail> GetDetail(string code);
    }
}