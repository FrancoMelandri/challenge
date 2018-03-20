using Microsoft.AspNetCore.Mvc;
using System.IO;
using System;
using System.Fabric;
using PlService;
using System.Threading.Tasks;

namespace UiService.Controllers 
{ 
    public class HomeController : Controller 
    {    
        private readonly StatelessServiceContext serviceContext;

        public HomeController(StatelessServiceContext serviceContext) 
        {
            this.serviceContext = serviceContext;
        }

        public async Task<IActionResult> Index() 
        {
            System.Console.WriteLine("HomeController/Index");      
            IPlService service = Microsoft.ServiceFabric.Services.Remoting.Client.ServiceProxy.Create<IPlService>(new Uri("fabric:/pl-service/PlService"));
            var model = new UiService.Models.HomeModel 
            {
                Message = "waiting..."
            };
            try {
                model.Message = await service.GeProductsAsync();
            } catch (Exception ex) {
                System.Console.WriteLine("Exception {0}", ex.Message);
            }
            return View(model);
        }
    }
}
