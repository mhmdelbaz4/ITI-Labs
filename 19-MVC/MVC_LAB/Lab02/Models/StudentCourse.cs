namespace Lab02.Models;

public class StudentCourse
{

    public int stdId { get; set; }

    public int CrsId { get; set; }

    [Range(0,100)]
    public int Grade { get; set; }

    [ForeignKey(nameof(stdId))]
    public Student Student { get; set; }

    [ForeignKey(nameof(CrsId))]
    public Course Course { get; set; }
}
