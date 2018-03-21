using Microsoft.AspNetCore.Mvc;
using System.IO;
using System;
using System.Fabric;
using PlService;
using PdService;
using System.Threading.Tasks;
using UiService.Engine;

namespace UiService.Controllers 
{ 
    public class HomeController : Controller 
    {    
        private readonly StatelessServiceContext serviceContext;
        private readonly IProductListFinder productListFinder;

        public HomeController(StatelessServiceContext serviceContext,
                              IProductListFinder productListFinder) 
        {
            this.serviceContext = serviceContext;
            this.productListFinder = productListFinder;
        }

        public IActionResult Index() 
        {
            // var search = HttpContext.Request.Query["search"].ToString();

            // System.Console.WriteLine("HomeController/Index with search: {0}", search);

            // var servicePl = Microsoft.ServiceFabric.Services.Remoting.Client.ServiceProxy.Create<IPlService>(new Uri("fabric:/pl-service/PlService"));
            // var servicePd = Microsoft.ServiceFabric.Services.Remoting.Client.ServiceProxy.Create<IPdService>(new Uri("fabric:/pd-service/PdService"));
            
            // var model = new UiService.Models.HomeModel ();
            // try {
            //     var responseList = await servicePl.GeProducts(search);
            //     model.Message = string.Format("{0}[{1}]",
            //                                     responseList.Search,
            //                                     responseList.Items.Count);
                                                
            //     if (responseList.Items.Count > 0)
            //     {
            //         var responsePd = await servicePd.GetDetail(responseList.Items[0].Code);
            //         model.Code = string.Format("Details: {0}, {1}, {2}, {3} ",
            //                                     responsePd.Code,
            //                                     responsePd.Name,
            //                                     responsePd.Description,
            //                                     responsePd.Brand);
            //     }

            // } catch (Exception ex) {
            //     System.Console.WriteLine("Exception {0}", ex.Message);
            // }
            //return View(model);
            return View();
        }
    }
}
