namespace Library;

public class Student : IComparable, ICloneable
{
    int id;
    string? name;
    int age;


    public int ID
    {
        get => id;
        set
        {
            if (value > 0 && value < 1000)
                id = value;
            else
                throw new ArgumentOutOfRangeException("ID should be between 0 and 1000");
        }
    }

    public string? Name
    {
        get => name;
        set
        {
            if (String.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException("name can't be null or white spaces");
            else
                name = value;
        }
    }

    public int Age
    {
        get => age;
        set
        {
            if (value > 15 && value < 30)
                age = value;
            else
                throw new ArgumentOutOfRangeException("student age should be between 15 and 30");
        }
    }

    public Student(int _id, string? _name)
    {
        ID = _id;
        Name = _name;
    }

    public Student(int _id, string? _name, int _age) : this(_id, _name)
    {
        Age = _age;
    }


    // new ctor 
    public Student(Student oldStd)
    {
        this.ID = oldStd.ID;
        this.Name = oldStd.Name;
        this.Age = oldStd.Age;
    }

    public override string ToString()
    {
        return $"Employee --> ID={ID}, Name={Name}, Age={Age}";
    }

    public override bool Equals(object? obj)
    {
        Student? other = obj as Student;

        if (other == null) return false;

        if (other.GetType() != typeof(Student)) return false;

        if (ReferenceEquals(this, other)) return true;


        bool isValid = (this.ID == other.ID)
                        && (this.Name == other.Name)
                        && (this.Age == other.Age);

        return isValid;
    }

    public int CompareTo(object? obj)
    {
        Student? other = obj as Student;
        if (other is null) return 1;

        if(this.Age != other.Age)
            return this.Age.CompareTo(other.Age);
        else
            return this.ID.CompareTo(other.ID);

    }

    public object Clone()
    {
        return new Student(this.ID, this.name, this.Age);
    }

    public override int GetHashCode()
    {
        throw new NotImplementedException();
    }
}
