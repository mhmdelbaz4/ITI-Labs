using Lab02.Repos;

namespace Lab02.Repos;

public class DepartmentRepo : IDepartmentRepo
{
    private readonly ITIMansContext _context;

    public DepartmentRepo(ITIMansContext context)
    {
        _context = context;
    }

    public IEnumerable<Department> GetAllDepartments()
    {
        IEnumerable<Department> depts;
        try
        {
            depts = _context.Departments.Include(dept => dept.Courses)
                                                        .Include(dept => dept.Stundents);
        }
        catch
        {
            throw new Exception("failed to load all departments");
        }

        return depts;
    }

    public void AddDepartment(Department dept)
    {
        if (dept is null)
            throw new ArgumentNullException("department can't be null");
        
        try
        {
            _context.Departments.Add(dept);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            throw new Exception("failed to add department");
        }
    }

    public void DeleteDepartment(int id)
    {
        Department department = GetDepartmentById(id);
        if (department is null)
            throw new Exception($"There's no deparetment with Id ={id}");

        try
        {
            _context.Departments.Remove(department);
            _context.SaveChanges();
        }
        catch
        {
            throw new Exception($"failed to remove department with id ={id}");
        }
    }

    public Department GetDepartmentById(int id)
    {
        Department department; 
        try
        {
            department = _context.Departments
                                .Include(dept => dept.Stundents)
                                .Include(dept => dept.Courses)
                                .FirstOrDefault(dept => dept.Id == id);    
        }
        catch
        {
            throw new Exception($"failed to load department with id ={id}");
        }
        return department;
    }

    public void UpdateDepartment(Department dept)
    {
        Department oldDept = GetDepartmentById(dept.Id);

        try
        {
            oldDept.Name = dept.Name;
            oldDept.Location = dept.Location;
            oldDept.Capacity = dept.Capacity;            
        }catch
        {
            throw new Exception("failed to update deptartment");
        }

    }

    public IEnumerable<Course> GetDepartmentCourses(int id)
    {
        try
        {
            IEnumerable<Course> Courses = _context.Departments
                                                .Include(d => d.Courses)
                                                .FirstOrDefault(d => d.Id == id)
                                                .Courses;
            return Courses;
        }
        catch
        {
            throw new Exception("failed to load department courses");
        }
    }

    public IEnumerable<Course> GetDepartmentNewCourses(int id)
    {
        try
        {
            IEnumerable<Course> allCourses = _context.Courses;
            IEnumerable<Course> deptCourses = GetDepartmentCourses(id);

            IEnumerable<Course> deptNewCourses = allCourses.Except(deptCourses);


            return deptNewCourses;
        }
        catch(Exception ex)
        {
            throw new Exception("failed to load new courses for the department");
        }
 
    }

    public void RemoveCourses(List<int> crsIds, int deptId)
    {
        try
        {
            Department dept = _context.Departments
                                    .Include(dept => dept.Courses)
                                    .FirstOrDefault(d => d.Id == deptId);

            Course tempCourse;
            foreach (int Id in crsIds)
            {
                tempCourse = dept.Courses.FirstOrDefault(crs => crs.Id == Id);
                if (tempCourse != null)
                    dept.Courses.Remove(tempCourse);
            }

            _context.SaveChanges();
        }
        catch
        {
            throw new Exception("failed to remove courses from this department");
        }
    }

    public void AddCourses(List<int> CrsIds, int deptId)
    {
        try
        {
            Department dept = _context.Departments
                                    .Find(deptId);
            Course tempCourse;
            foreach (int Id in CrsIds)
            {
                tempCourse = dept.Courses.FirstOrDefault(crs => crs.Id == Id);
                if (tempCourse == null)
                {
                    tempCourse = _context.Courses.Find(Id);
                    if (tempCourse != null)
                    {
                        dept.Courses.Add(tempCourse);
                        _context.SaveChanges();
                    }
                }
            }
        }
        catch
        {
            throw new Exception("failed to add new courses for this department");
        }
    }
}
