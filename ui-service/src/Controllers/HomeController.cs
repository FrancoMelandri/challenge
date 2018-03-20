using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Fabric;

namespace UiService.Controllers 
{ 
    public class HomeController : Controller 
    {    
        private readonly StatelessServiceContext serviceContext;

        public HomeController(StatelessServiceContext serviceContext) 
        {
            this.serviceContext = serviceContext;
        }

        public IActionResult Index() 
        {
            System.Console.WriteLine("HomeController/Index at {0}", Directory.GetCurrentDirectory());
            return View();
        }
    }
}
