namespace Lab02.ViewModels;

public class EditDepartmentVM
{
    public Department Department { get; set; }

    public IEnumerable<Course> NewCourses { get; set; }
}
