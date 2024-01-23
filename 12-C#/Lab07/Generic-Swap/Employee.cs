namespace Generic_Swap;

internal struct Employee
{
    public int ID { get; set; }

    public string Name { get; set; }

    public int Salary { get; set; }


    public Employee(int _id,string _name,int _salary)
    {
        ID = _id;
        Name = _name;
        Salary = _salary;
    }

    public override string ToString()
    {
        return $"Employee--> ID={ID}, Name={Name}, Salary={Salary}";
    }
}
