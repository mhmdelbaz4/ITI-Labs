
namespace Lab02.Repos;
public class StudentRepo : IStudentRepo
{
    private readonly ITIMansContext _context;
    public StudentRepo(ITIMansContext context)
    {
        _context = context;
    }


    public void AddStudent(Student std)
    {
        try
        {
            _context.Students.Add(std);
            _context.SaveChanges();
        }
        catch
        {
            throw new Exception("faield to add new student");
        }
    }

    public void DeleteStudent(int id)
    {
        try
        {
            Student std = GetStudentById(id);
            _context.Students.Remove(std);
            _context.SaveChanges();
        }catch(NullReferenceException ex)
        {
            throw new Exception("id can't be null");
        }

    }

    public IEnumerable<Student> GetAll()
    {
        try
        {
            IEnumerable<Student> stds = _context.Students.Include(std => std.Department)
                                                        .Include(std => std.StudentCourses);

            return stds;

        }
        catch
        {
            throw new Exception("failed to load all students");
        }
    }

    public Student GetStudentById(int id)
    {
        try
        {
            Student student = _context.Students
                                        .Include(std => std.Department)
                                        .Include(std => std.StudentCourses)
                                        .FirstOrDefault(std => std.Id == id);
            return student;
        }
        catch
        {
            throw new Exception($"failed to load student with id={id}");
        }

    }

    public void UpdateStudent(Student student)
    {
        try
        {
            Student oldStd = GetStudentById(student.Id);
            oldStd.Name = student.Name;
            oldStd.Address = student.Address;
            oldStd.Age = student.Age;
            oldStd.DeptId = student.DeptId;
            _context.Update(oldStd);
            _context.SaveChanges();
        }catch
        {
            throw new Exception("failed to update student");
        }
    }
}
