namespace BusinessLogicLayer;

public class Employee
{
    public int Id { get; set; }

    public string? FName { get; set; }

    public string? LName { get; set; }

    public string? DeptNo { get; set; }

    public int Salary { get; set; }

    public override string ToString()
    {
        return $"Student Id :{Id} ,FName :{FName} ,LName :{LName} ,DeptNo :{DeptNo} ,Salary :{Salary}";
    }
}
