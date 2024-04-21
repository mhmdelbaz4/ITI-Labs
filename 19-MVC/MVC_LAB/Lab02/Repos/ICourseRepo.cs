namespace Lab02.Repos;

public interface ICourseRepo
{
    Course GetCourseById(int id);

    IEnumerable<Course> GetAllCourses();

    void AddCourse(Course crs);

    void UpdateCourse(Course crs);

    void DeleteCourse(int id);

    IEnumerable<StudentCourse> GetStudentCourses(int deptId, int crsId);

}
