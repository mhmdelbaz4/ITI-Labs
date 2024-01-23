namespace Library;

public class Employee:IComparable,ICloneable
{
    int id;
    string? name;
    float salary;


    public int ID
    {
        get => id;
        set
        {
            if(value > 0 && value <1000)
                id = value;
            else
                throw new ArgumentOutOfRangeException("ID should be between 0 and 1000");
        }
    }

    public string? Name 
    { 
        get=> name;
        set 
        {
            if(String.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException("name can't be null or white spaces");
            else
                name = value;
        } 
    }

    public float Salary
    {
        get=>salary;
        set
        {
            if (value > 3000 && value < 100_000)
                salary = value;
            else
                throw new ArgumentOutOfRangeException("salary should be between 3000 and 100_000");
        }
    }

    public Employee(int _id, string? _name)
    {
        ID = _id;
        Name = _name;
    }

    public Employee(int _id, string? _name,float _salary) :this(_id,_name)
    {
        Salary= _salary;
    }


    // new ctor 
    public Employee(Employee oldEmp)
    {
        this.ID= oldEmp.ID;
        this.Name = oldEmp.Name;
        this.Salary = oldEmp.Salary;
    }

    public override string ToString()
    {
        return $"Employee --> ID={ID}, Name={Name}, Salary={Salary}";
    }

    public override bool Equals(object? obj)
    {
        Employee? other = obj as Employee;
        
        if(other == null)return false;

        if(other.GetType() != typeof(Employee)) return false;

        if(ReferenceEquals(this,other)) return true;


        bool isValid = (this.ID == other.ID)
                        && (this.Name == other.Name)
                        && (this.Salary == other.Salary);

        return isValid  ;
    }

    public int CompareTo(object? obj)
    {
        Employee? other = obj as Employee;
        if (other is null) return 1;
        
        if (other.Name is null) return 1;
        if (this.Name is null)
            return -1;


        if (this.Name == other.Name)
            return this.ID.CompareTo(other.ID);
        else
            return this.Name.CompareTo(other.Name);
    }

    public object Clone()
    {
        return new Employee(this.ID,this.name,this.Salary);
    }

    public override int GetHashCode()
    {
        throw new NotImplementedException();
    }
}
