using Lab01.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab01.Controllers
{
    public class DepartmentsController : Controller
    {
        List<Department> departments;

        public DepartmentsController()
        {
            departments = new List<Department>()
            {
                new Department(){Id=1,Name="HR",Location="Mansoura"},
                new Department(){Id=2,Name="Tech",Location="Cairo"},
                new Department(){Id=3,Name="Finance",Location="Alex"},
            };
        }


        public IActionResult Index()
        {
            return View(departments);
        }


        public IActionResult Details(int id)
        {
            Department department = departments.FirstOrDefault(x => x.Id == id);

            return View(department);
        }

    }
}
