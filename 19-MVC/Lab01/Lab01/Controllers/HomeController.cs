using Lab01.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lab01.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add(int num1, int num2)
        {
            return View( (num1,num2,num1+num2));
        }

        public IActionResult Actions(int id)
        {
            if (id == 0)
                return View();
            else if (id == 1)
                return Content("Hello World!", "text/plain");
            else if (id == 2)
                return Content("<h1>Hello World!</h1>", "text/html");
            else if (id == 3)
                return File("SOLID.pdf", "application/pdf");
            else if (id == 4)
                return Redirect("https://www.google.com");
            else 
                return NotFound();
        }

      
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
