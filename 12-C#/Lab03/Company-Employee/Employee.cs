using System;


namespace Company_Employee;
struct Employee
{
    int id;
    string name;
    int age;
    int salary;
    GenderType gender;

    public int ID
    {
        get => id;
        set
        {
            if(value>0 && value<1000)
            {
                id = value;
            }
            else
            {
                id = -1;
            }
        }
    }
    public string Name
    {
        get => name;
        set
        {
            if(! String.IsNullOrEmpty(value))
            {
                name= value;
            }
            else
            {
                name = "No Name";
            }
        }
    }
    public int Age
    {
        get => age;
        set
        {
            if (value > 20 && value < 60)
            {
                age = value;
            }
            else
            {
                age = 20;
            }
        }
    }
    public int Salary
    {
        get => salary;
        set
        {
            if (value > 3000 && value < 50000)
            {
                salary = value;
            }
            else
            {
                salary = 3000;
            }
        }
    }

    public GenderType Gender
    {
        get => gender;
        set => gender = value;
    }
    public SecurityLevel SecurityLevel;
    
    public HiringDate HiringDate;
  

    public Employee(int _id ,string _name, int _salary, int _age ,GenderType _gender ,
                    HiringDate _hiringDate)
    {
        ID=_id;
        Name=_name; 
        Salary=_salary;
        Age=_age;
        Gender =_gender;
        HiringDate = _hiringDate;    
    }

    public Employee(int _id, string _name, int _salary, int _age, GenderType _gender)
            :this(_id, _name, _salary, _age, _gender, new HiringDate(1, 1, DateTime.Now.Year))

    { }
    public Employee(int _id, string _name, int _salary)
        :this(_id, _name, _salary, 20, GenderType.M, new HiringDate(1, 1, DateTime.Now.Year))

    {}
    public Employee(int _id, string _name)
        : this(_id, _name, 3000, 20, GenderType.M, new HiringDate(1, 1, DateTime.Now.Year))
    { }

    public override string ToString()
    {
        return $"ID ={ID}, Name ={Name}, Salary={Salary} ,Age ={Age} , Gender ={Gender} ,Security Level ={SecurityLevel},Hiring Date {HiringDate}";
    }
}

enum GenderType
{
    M,F
}


[Flags]
enum SecurityLevel
{
    Guest=1 , Developer=2 , Secretary=4,DBA=8
}
struct HiringDate
{
    int day;
    int month;
    int year;


    public int Day
    {
        get => day;
        set
        {
            if(value >0 && value <= 31)
            {
                day = value;
            }
            else
            {
                day = 1;
            }
        }
    }
    public int Month
    {
        get => month;
        set
        {
            if (value > 0 && value <= 12)
            {
                month = value;
            }
            else
            {
                month = 1;
            }
        }
    }
    public int Year
    {
        get => year;

        set
        {
            if (value > 1980 && value <= DateTime.Now.Year)
            {
                year= value;
            }
            else
            {
                year = DateTime.Now.Year;
            }
        }
    }

    public HiringDate(int _day, int _month, int _year)
    {
        Day=_day;
        Month=_month;
        Year=_year;
    }

    public HiringDate(int _month ,int _year) :this(1,_month,_year)
    {}

    public override string ToString()
    {
        return $"{Day}/{Month}/{Year}";
    }
}