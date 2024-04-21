namespace Lab02.Repos;

public class CourseRepo : ICourseRepo
{
    private readonly ITIMansContext _context;

    public CourseRepo(ITIMansContext context)
    {
        _context = context;
    }

    public void AddCourse(Course crs)
    {
        if (crs is null)
            throw new ArgumentNullException("can't add null course to DB");

        try
        {
            _context.Add(crs);
            _context.SaveChanges();
        }catch
        {
            throw new Exception("failed to add new course to DB");
        }

    }

    public void DeleteCourse(int id)
    {
        Course crs;
        try
        {
            crs = GetCourseById(id);
        }
        catch
        {
            throw;
        }


        try
        {
            _context.Remove(crs);
            _context.SaveChanges();
        }
        catch
        {
            throw new Exception($"failed to delete course with id ={id}");
        }
    }

    public IEnumerable<Course> GetAllCourses()
    {
        IEnumerable<Course> courses = _context.Courses;

        return courses;
    }

    public Course GetCourseById(int id)
    {
        if(id < 0)
            throw new ArgumentOutOfRangeException("Id can't be negative");

        Course course = _context.Courses.FirstOrDefault(crs => crs.Id == id);
        if (course is null)
            throw new ArgumentException($"No course with id ={id}");

        return course;
    }

    public IEnumerable<StudentCourse> GetStudentCourses(int deptId, int crsId)
    {

        //_context.Departments.Include()


        throw new NotImplementedException();
    }

    public void UpdateCourse(Course crs)
    {
        Course oldCourse;

        try
        {
            oldCourse = GetCourseById(crs.Id);
        }
        catch
        {
            throw;
        }

        try
        {
            oldCourse.Id = crs.Id;
            oldCourse.Name = crs.Name;
            oldCourse.Duration = crs.Duration;
            _context.Courses.Update(oldCourse);
            _context.SaveChanges();

        }catch{
            throw new Exception("can't update course");
        }
    }
}
