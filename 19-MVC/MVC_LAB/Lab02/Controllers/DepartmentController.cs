
namespace Lab02.Controllers;

public class DepartmentController : Controller
{
    private readonly IDepartmentRepo _departmentRepo;
    public DepartmentController(IDepartmentRepo departmentRepo)
    {
        _departmentRepo = departmentRepo;
    }

    public IActionResult Index()
    {
        IEnumerable<Department> departments = _departmentRepo.GetAllDepartments();   
        
        return View(departments);
    }
    
    public IActionResult Details(int id)
    {
        try
        {
            Department dept = _departmentRepo.GetDepartmentById(id);
            return View(dept);
        }
        catch
        {
            return BadRequest();
        }

    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Department dept)
    {
        if(ModelState.IsValid)
        {
            try
            {
                _departmentRepo.AddDepartment(dept);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return BadRequest();
            }
        }
        else
        {
            return View();
        }   
    }

    public IActionResult Edit(int id)
    {
        EditDepartmentVM viewModel = new EditDepartmentVM()
        {
            Department = _departmentRepo.GetDepartmentById(id),
            NewCourses = _departmentRepo.GetDepartmentNewCourses(id)
        };
        
        if(viewModel.Department is null)
            return BadRequest();

        return View(viewModel);
    }

    [HttpPost]
    public IActionResult Edit(Department dept)
    {
        if(ModelState.IsValid)
        {
            try
            {
                _departmentRepo.UpdateDepartment(dept);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return BadRequest();
            }
        }
        else
        {
            return RedirectToAction(nameof(Edit) , new {id=dept.Id});
        }
    }

    public IActionResult Delete(int id)
    {
        try
        {
            Department dept = _departmentRepo.GetDepartmentById(id);
            _departmentRepo.DeleteDepartment(id);

            return RedirectToAction(nameof(Index));

        }
        catch
        {
            return BadRequest();
        }
           
    }

    public IActionResult ChangeCourses(List<int> crsIdsRemoved, List<int> crsIdsAdded, int deptId)
    {
        try
        {
            _departmentRepo.RemoveCourses(crsIdsRemoved, deptId);
            _departmentRepo.AddCourses(crsIdsAdded, deptId);

            return RedirectToAction(nameof(Edit), new { id = deptId });
        }catch{
            return BadRequest();
        }
        
    }

    //public IActionResult ShowCourseGrades(int deptId, int crsId)
    //{
    //    IEnumerable<Student> students = _departmentRepo.GetDepartmentById(deptId).Stundents;
    //    students.Select(std => std.StudentCourses)
    //            .Where(sc => sc.crsId == crsId);
    //    return View(students);
    //}

}
