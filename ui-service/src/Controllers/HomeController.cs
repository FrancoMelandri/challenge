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
            var search = HttpContext.Request.Query["search"].ToString();
            System.Console.WriteLine("HomeController/Index with search: {0}", search);      
            IPlService service = Microsoft.ServiceFabric.Services.Remoting.Client.ServiceProxy.Create<IPlService>(new Uri("fabric:/pl-service/PlService"));
            var model = new UiService.Models.HomeModel ();
            try {
                var response = await service.GeProducts(search);
                model.Message = response.Search;
            } catch (Exception ex) {
                System.Console.WriteLine("Exception {0}", ex.Message);
            }
            return View(model);
        }
    }
}
