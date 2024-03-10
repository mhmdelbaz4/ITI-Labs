namespace Lab01_ADO;

internal class Employee
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public int Salary { get; set; }

    public string? DeptId { get; set; }


    public override string ToString()
    {
        return $"Id : {Id}, Name = {FirstName} {LastName}, Salary ={Salary} ,DeptId = {DeptId}";
    }
}
