using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Lab02.Repos;

public interface IDepartmentRepo
{
    IEnumerable<Department> GetAllDepartments();
    
    Department GetDepartmentById(int id);

    void AddDepartment(Department dept);

    void UpdateDepartment(Department dept);

    void DeleteDepartment(int id);

    void RemoveCourses(List<int> crsIds, int deptId);
    IEnumerable<Course> GetDepartmentCourses(int id);

    void AddCourses(List<int> CrsIds, int deptId);
    IEnumerable<Course> GetDepartmentNewCourses(int id);

}
