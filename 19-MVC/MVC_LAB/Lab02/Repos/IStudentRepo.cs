namespace Lab02.Repos;

public interface IStudentRepo
{
    IEnumerable<Student> GetAll();

    Student GetStudentById(int id);

    void AddStudent(Student std);

    void UpdateStudent(Student student);

    void DeleteStudent(int id);

}
