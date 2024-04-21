namespace Lab02.Models;
public class Department
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Range(1, int.MaxValue)]

    public int Id { get; set; }

    [Required]
    [StringLength(50,MinimumLength =2)]
    public string Name { get; set; }


    [Required]
    [StringLength(50,MinimumLength =2)]
    public string Location { get; set; }

    [Range(20,100)]
    public int Capacity { get; set; }

    public ICollection<Student> Stundents { get; set; } = new HashSet<Student>();

    public ICollection<Course> Courses { get; set; } = new HashSet<Course>();

}
