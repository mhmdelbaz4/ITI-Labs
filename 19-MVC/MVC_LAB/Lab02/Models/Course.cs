namespace Lab02.Models;
public class Course
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Range(1, int.MaxValue)]

    public int Id { get; set; }

    [Required]
    [StringLength(50,MinimumLength =2)]
    public string Name { get; set; }

    [Range(2,15)]
    public int Duration { get; set; }

    public ICollection<Department> Departments { get; set; } = new HashSet<Department>();

    public ICollection<StudentCourse> StudentCourses { get; set; } = new HashSet<StudentCourse>();

}
