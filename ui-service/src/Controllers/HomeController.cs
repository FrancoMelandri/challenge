using Microsoft.AspNetCore.Mvc;
using System.IO;
using System;
using System.Fabric;
using PlService;
using PdService;
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
            var code = HttpContext.Request.Query["code"].ToString();

            System.Console.WriteLine("HomeController/Index with search: {0} and code {1}", search, code);

            var servicePl = Microsoft.ServiceFabric.Services.Remoting.Client.ServiceProxy.Create<IPlService>(new Uri("fabric:/pl-service/PlService"));
            var servicePd = Microsoft.ServiceFabric.Services.Remoting.Client.ServiceProxy.Create<IPdService>(new Uri("fabric:/pd-service/PdService"));
            
            var model = new UiService.Models.HomeModel ();
            try {
                var responseList = await servicePl.GeProducts(search);
                model.Message = string.Format("{0}[{1}]",
                                                responseList.Search,
                                                responseList.Items.Count);
                                                

                var responsePd = await servicePd.GetDetail(code);
                model.Code = responsePd.Code;

            } catch (Exception ex) {
                System.Console.WriteLine("Exception {0}", ex.Message);
            }
            return View(model);
        }
    }
}
