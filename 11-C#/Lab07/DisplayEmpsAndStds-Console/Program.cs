using System.Collections.Generic;
using Library;

List<Employee> emps = new List<Employee>()
{
    new Employee(100,"ahmed",5000),
    new Employee(101,"omar",7000),
    new Employee(102,"ibrahim",10000),
    new Employee(103,"ali",9000),
    new Employee(104,"omar",15000)
};

Console.WriteLine("**********Employees*********");
Console.WriteLine("Before Sorting");
foreach (Employee emp in emps)
    Console.WriteLine(emp);

Console.WriteLine("After Sorting");
emps.Sort();
foreach (Employee emp in emps)
    Console.WriteLine(emp);

Console.WriteLine("==========================");
List<Student> stds = new List<Student>()
{
    new Student(100,"ahmed",20),
    new Student(101,"omar",19),
    new Student(102,"ibrahim",22),
    new Student(103,"ali",19),
    new Student(104,"khalid",23)
};

Console.WriteLine("**********Students*********");
Console.WriteLine("Before Sorting");
foreach (Student std in stds)
    Console.WriteLine(std);

Console.WriteLine("After Sorting");
stds.Sort();
foreach (Student std in stds)
    Console.WriteLine(std);
