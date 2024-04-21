namespace Lab02.Controllers;

public class CourseController : Controller
{
    private readonly ICourseRepo _courseRepo;

    public CourseController(ICourseRepo courseRepo)
    {
        _courseRepo = courseRepo;
    }

    public IActionResult Index()
    {
        List<Course> courses = _courseRepo.GetAllCourses().ToList();

        return View(courses);
    }

    public IActionResult Details(int id)
    {
        var course = _courseRepo.GetCourseById(id);
        if (course == null)
        {
            return BadRequest();
        }

        return View(course);
    }


    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Course course)
    {
      

        if(ModelState.IsValid)
        {
            _courseRepo.AddCourse(course);
            return RedirectToAction(nameof(Index));
        }
        else
        {
            return View();
        }
       
    }
    public IActionResult Edit(int id)
    {

        var course = _courseRepo.GetCourseById(id);
        if (course == null)
        {
            return BadRequest();
        }
        return View(course);
    }

    [HttpPost]
    public IActionResult Edit(Course course)
    {

        if (ModelState.IsValid)
        {
            _courseRepo.UpdateCourse(course);
            return RedirectToAction(nameof(Index));
        }
        else
        {
            return View();
        }

    }

    public IActionResult Delete(int id)
    {
        _courseRepo.DeleteCourse(id);
        return RedirectToAction(nameof(Index));
    }

  
}
