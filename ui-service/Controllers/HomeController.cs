using Microsoft.AspNetCore.Mvc;
 
namespace UiService.Controllers 
{ 
    public class HomeController : Controller 
    {    
        public IActionResult Index() 
        {
            System.Console.WriteLine("HomeController/Index");
            return View();
        }
    }
}