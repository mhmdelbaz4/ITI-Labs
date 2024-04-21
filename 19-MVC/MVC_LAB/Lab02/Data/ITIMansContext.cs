using Lab02.Models;

namespace Lab02;

public class ITIMansContext :DbContext
{
    public ITIMansContext()
    {}

    public ITIMansContext(DbContextOptions options): base(options)
    {}
    
    public DbSet<Department> Departments { get; set; }

    public DbSet<Student> Students { get; set; }

    public DbSet<Course> Courses { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("server=.;database=ITIMans;integrated security=true; trust server certificate =true;");
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StudentCourse>()
                    .HasKey(sc =>  new { sc.stdId , sc.CrsId});

        base.OnModelCreating(modelBuilder);
    }
}
