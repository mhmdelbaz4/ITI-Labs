using Microsoft.AspNetCore.Mvc;

namespace Lab02.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Upload(IFormFile img ,string name)
        {
            string imgName =name + img.FileName.Split(".").Last();

            using (FileStream fs = new FileStream($"images/{imgName}", FileMode.Create))
            {
                await img.CopyToAsync(fs);
                return Content("Uploaded");
            }
        }

    }
}
