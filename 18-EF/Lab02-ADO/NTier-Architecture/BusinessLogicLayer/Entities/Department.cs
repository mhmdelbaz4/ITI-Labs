namespace BusinessLogicLayer;

public class Department
{
    public string?  Number { get; set; }

    public string? Name { get; set; }

    public string? Location { get; set; }

    public override string ToString()
    {
        return $"DeptNo : {Number} ,Name : {Name} ,Location :{Location}";
    }
}
