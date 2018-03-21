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
    public class ProductListController : Controller 
    {    
        private readonly StatelessServiceContext serviceContext;
        private readonly IProductListFinder productListFinder;

        public ProductListController(StatelessServiceContext serviceContext,
                                     IProductListFinder productListFinder) 
        {
            this.serviceContext = serviceContext;
            this.productListFinder = productListFinder;
        }

        public async Task<IActionResult> Index(string search) 
        {
            System.Console.WriteLine("ProductListController/Index with search: {0}", search);
            var model = await this.productListFinder.Search(search);
            return View(model);
        }
    }
}
