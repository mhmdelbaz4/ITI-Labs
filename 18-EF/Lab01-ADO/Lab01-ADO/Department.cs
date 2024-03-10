
namespace Lab01_ADO;

internal class Department
{
    public string? Id { get; set; }

    public string? Name { get; set; }

    public string? Location { get; set; }



    public override string ToString()
    {
        return $"Id : {Id}, Name : {Name} ,Location : {Location}";
    }
}
