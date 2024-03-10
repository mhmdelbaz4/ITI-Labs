using BusinessLogicLayer;
using System.Text.RegularExpressions;

Console.WriteLine("***************Welcome*******************");
Console.WriteLine("***********Department Management**************");
Console.WriteLine("1. Get All Departments");
Console.WriteLine("2. Get Department By Dept Number");
Console.WriteLine("3. Add new department");
Console.WriteLine("4. Update existing department");
Console.WriteLine("5. Delete existing department");

Console.Write("Enter Option Number: ");
int optionNo;

string input = Console.ReadLine();
while (! int.TryParse(input,out optionNo)  || !Regex.IsMatch(input ,"^[1-6]{1}$"))
{
    Console.WriteLine("Enter Valid Option Number!");
    Console.Write("Enter Option Number Again: ");
    input = Console.ReadLine();
}


switch (optionNo)
{
    case 1:
        DepartmentList deptList = DepartmentManager.GetAllDepartments();
        if(deptList == null ||deptList.Count ==0)
        {
            Console.WriteLine("No Departments!");
        }
        else
        {
            foreach (Department item in deptList)
            {
                Console.WriteLine(item);
            }
        }
        break;
    
    case 2:
        string deptNo = string.Empty;
        do {
            Console.Write("Enter Department Number :");
            deptNo = Console.ReadLine()!;
        } while (String.IsNullOrWhiteSpace(deptNo));

        Department? dept = DepartmentManager.GetDepartmentByNumber(deptNo);
        while(dept is null)
        {
            Console.WriteLine($"No Department with No = {deptNo}");
            Console.Write("Enter Valid Department Number :");
            deptNo = Console.ReadLine()!;
            dept = DepartmentManager.GetDepartmentByNumber(deptNo);
        }

        Console.WriteLine(dept);
        break;
    case 3:
        Department newDept = new Department();

        Console.Write("Enter Department Number :");
        newDept.Number = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(newDept.Number) || DepartmentManager.GetDepartmentByNumber(newDept.Number) != null)
        {
            if(string.IsNullOrEmpty(newDept.Number))
                Console.WriteLine("Invalid Dept Number!!!!");
            else
                Console.WriteLine("Dept No is already existing");

            Console.Write("Enter Department Number Again:");
            newDept.Number = Console.ReadLine();
        }

        Console.Write("Enter Department Name :");
        newDept.Name = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(newDept.Name) || int.TryParse(newDept.Name ,out int tempName))
        {
            Console.WriteLine("Invalid Dept Name!!!!");
            newDept.Name = Console.ReadLine();
        }

        Console.Write("Enter Department Location :");
        newDept.Location = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(newDept.Location) || int.TryParse(newDept.Location ,out int tempLocation))
        {
            Console.WriteLine("Invalid Dept Location!!!!");

            newDept.Location = Console.ReadLine();
        }
        if(DepartmentManager.TryAddDepartment(newDept))
            Console.WriteLine("Added Successfully");
        else
            Console.WriteLine("sorry ,can't be added to DB");
        
        break;

    case 4:
        Department? updatedDept = new Department();

        Console.Write("Enter Department Number :");
        string? deptNo_updated = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(deptNo_updated) || DepartmentManager.GetDepartmentByNumber(deptNo_updated) == null)
        {
            if (string.IsNullOrEmpty(deptNo_updated))
                Console.WriteLine("Invalid Dept Number!!!!");
            else
                Console.WriteLine("Dept No doesn't match existing department!");

            Console.Write("Enter Department Number Again:");
            deptNo_updated = Console.ReadLine();
        }

        updatedDept = DepartmentManager.GetDepartmentByNumber(deptNo_updated);
        Console.WriteLine($"Department with No ={deptNo_updated}");
        Console.WriteLine(updatedDept);


        Console.Write("Enter New Department Name :");
        updatedDept.Name = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(updatedDept.Name) || int.TryParse(updatedDept.Name, out int tempName))
        {
            Console.WriteLine("Invalid Dept Name!!!!");
            Console.Write("Enter Department Name Again:");
            updatedDept.Name = Console.ReadLine();
        }

        Console.Write("Enter New Department Location :");
        updatedDept.Location = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(updatedDept.Location) || int.TryParse(updatedDept.Location, out int tempLocation))
        {
            Console.WriteLine("Invalid Dept location!!!!");

            updatedDept.Location = Console.ReadLine();
        }
        if (DepartmentManager.TryUpdateDepartment(updatedDept.Number,updatedDept))
            Console.WriteLine("Updated Successfully");
        else
            Console.WriteLine("sorry ,can't be updated in DB");

        break;
    case 5:

        Console.Write("Enter Department Number :");
        string? deptNo_deleted = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(deptNo_deleted) || DepartmentManager.GetDepartmentByNumber(deptNo_deleted) == null)
        {
            if (string.IsNullOrEmpty(deptNo_deleted))
                Console.WriteLine("Invalid Dept Number!!!!");
            else
                Console.WriteLine("Dept No doesn't match existing department!");

            Console.Write("Enter Department Number Again:");
            deptNo_updated = Console.ReadLine();
        }

        if(DepartmentManager.TryDeleteDepartment(deptNo_deleted))
            Console.WriteLine("Deleted Successfully");
        else
            Console.WriteLine("sorry, department can't be deleted!");
        break;
}

Console.ReadKey();


