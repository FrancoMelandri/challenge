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
        private readonly IProductDetailsProvider productDetailsProvider;

        public HomeController(StatelessServiceContext serviceContext,
                              IProductListFinder productListFinder,
                              IProductDetailsProvider productDetailsProvider) 
        {
            this.serviceContext = serviceContext;
            this.productListFinder = productListFinder;
            this.productDetailsProvider = productDetailsProvider;
        }

        public IActionResult Index() 
        {
            return View();
        }

        [HttpPost]
        [HttpGet]
        public async Task<IActionResult> List(string search) 
        {
            System.Console.WriteLine("HomeController/List with search: {0}", search);
            var model = await this.productListFinder.Search(search);
            System.Console.WriteLine("Items: {0}", model.Items.Length);
            return View("list", model);
        }

        [HttpPost]
        [HttpGet]
        public async Task<IActionResult> Details(string code) 
        {
            System.Console.WriteLine("HomeController/Details with search: {0}", code);
            var model = await this.productDetailsProvider.GetDetail(code);
            return View("details", model);
        }   
    }
}
