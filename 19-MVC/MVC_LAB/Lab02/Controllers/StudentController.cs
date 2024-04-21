namespace Lab02.Controllers;
using Microsoft.AspNetCore.Mvc;


public class StudentController : Controller
{
    private readonly IStudentRepo _studentRepo;
    private readonly IDepartmentRepo _departmentRepo;

    public StudentController(IStudentRepo studentRepo ,IDepartmentRepo departmentRepo)
    {
        _studentRepo = studentRepo;
        _departmentRepo = departmentRepo;
    }

    public IActionResult Index()
    {
        try
        {
            IEnumerable<Student> students = _studentRepo.GetAll();
            return View(students);
        }
        catch
        {
            return BadRequest();
        } 
    }

    public IActionResult Details(int id)
    {
        try
        {
        
            Student std = _studentRepo.GetStudentById(id);
            return View(std);
            
        }
        catch
        {
            return BadRequest();
        }
    }

    public IActionResult Create()
    {
        try
        {
            IEnumerable<Department> departments = _departmentRepo.GetAllDepartments();
            SelectList selectListItems = new SelectList(departments, nameof(Department.Id), nameof(Department.Name));

            ViewBag.SelectList = selectListItems;
            return View();
        }
        catch
        {
            return BadRequest();
        }
    }

    [HttpPost]
    public IActionResult Create(Student std)
    {
        if(ModelState.IsValid)
        {
            try
            {
                _studentRepo.AddStudent(std);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return BadRequest();
            }
        }
        else
        {
            IEnumerable<Department> departments = _departmentRepo.GetAllDepartments();
            SelectList selectListItems = new SelectList(departments, nameof(Department.Id), nameof(Department.Name));

            ViewBag.SelectList = selectListItems;
            return View();
        }
       
    }

    public IActionResult Edit(int id)
    {
        try
        {
            Student std = _studentRepo.GetStudentById(id);

            IEnumerable<Department> departments = _departmentRepo.GetAllDepartments();
            SelectList selectListItems = new SelectList(departments, nameof(Department.Id), nameof(Department.Name), std.Id);

            ViewBag.SelectList = selectListItems;

            return View(std);
        }
        catch
        {
            return BadRequest();
        }
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Student std ,IFormFile img)
    {
        if(ModelState.IsValid)
        {
            try
            {
                

                _studentRepo.UpdateStudent(std);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return BadRequest();
            }
        }
        else
        {
            return RedirectToAction(nameof(Edit), new {id= std.Id}); 
        }
    }

    public IActionResult Delete(int id)
    {
        try
        {
            _studentRepo.DeleteStudent(id);
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return BadRequest();
        }
    }
}
