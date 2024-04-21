namespace Lab02.Models;
public class Student
{
    [Key]
    [Range(1,int.MaxValue)]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }

    [Required]
    [StringLength(50,MinimumLength =3)]
    public string Name { get; set; }

    [Range(18,25)]
    public int Age { get; set; }

    [StringLength(50,MinimumLength =3)]
    public string Address { get; set; }

    public string Img { get; set; }

    [ForeignKey(nameof(Department))]
    public int DeptId { get; set; }
    public Department Department { get; set; }

    public ICollection<StudentCourse> StudentCourses { get; set; } = new HashSet<StudentCourse>();

}
