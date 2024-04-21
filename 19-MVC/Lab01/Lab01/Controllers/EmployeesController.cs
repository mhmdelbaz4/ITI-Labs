using Lab01.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab01.Controllers
{
    public class EmployeesController : Controller
    {

        List<Employee> emps;

        public EmployeesController()
        {
            emps = new List<Employee>()
            {
                new Employee(){Id=1,Name="Mohamed",Salary=5000,DeptId=1},
                new Employee(){Id=2,Name="Fouad",Salary=7000,DeptId=3},
                new Employee(){Id=3,Name="Khalid",Salary=6000,DeptId=1},
                new Employee(){Id=4,Name="Ibrahim",Salary=15000,DeptId=2},
                new Employee(){Id=5,Name="Osama",Salary=20000,DeptId=2},
                new Employee(){Id=6,Name="Ali",Salary=6000,DeptId=3}
            };
        }
        public IActionResult Index()
        {
            return View(emps);
        }

        public IActionResult Details(int id)
        {
            Employee emp = emps.FirstOrDefault(e => e.Id == id);

            return View(emp);   
        }
    }
}
