using Company_Employee;

Employee[] employees = new Employee[3];

Console.WriteLine("*************Enter Employees Data***********");

for (int i = 0; i < employees.Length; i++)
{
    int tempID, tempAge, tempSalary, tempHiringDay, tempHiringMonth, tempHiringYear;
    string tempName, tempGender;
    Console.WriteLine($"Employee {i + 1} :\n");

    Console.Write("Enter ID(from 0 to 100) :");
    while (!int.TryParse(Console.ReadLine(), out tempID) || tempID < 0 || tempID > 100)
    {
        Console.WriteLine("Wrong ID!!");
        Console.WriteLine("Enter ID Again(from 0 to 100) :");
    }

    Console.Write("Enter Name(more than 2 characters) :");
    tempName = Console.ReadLine();
    while (String.IsNullOrEmpty(tempName) || tempName.Length < 3 || int.TryParse(tempName,out int result))
    {
        Console.WriteLine("Name is Wrong(more than 2 characters)!!");
        Console.WriteLine("Enter Name Again :");
        tempName = Console.ReadLine();
    }

    Console.Write("Enter Age (from 20 to 60):");
    while (!int.TryParse(Console.ReadLine(), out tempAge) || tempAge < 20 || tempAge >= 60)
    {
        Console.WriteLine("Wrong Age!!");
        Console.WriteLine("Enter Age Again(from 20 to 60)");
    }

    Console.Write("Enter Salary (from 3000 to 50000):");
    while (!int.TryParse(Console.ReadLine(), out tempSalary) || tempSalary < 3000 || tempSalary >= 50000)
    {
        Console.WriteLine("Wrong Salary!!");
        Console.WriteLine("Enter Salary Again(from 3000 to 50000):");
    }

    Console.Write("Enter Hiring Day (from 1 to 31):");
    while (!int.TryParse(Console.ReadLine(), out tempHiringDay) || tempHiringDay < 1 || tempHiringDay > 31)
    {
        Console.WriteLine("Wrong Hiring Day!!");
        Console.WriteLine("Enter  Hiring Day Again(from 1 to 31):");
    }

    Console.Write("Enter Hiring Month (from 1 to 12):");
    while (!int.TryParse(Console.ReadLine(), out tempHiringMonth) || tempHiringMonth < 1 || tempHiringMonth > 12)
    {
        Console.WriteLine("Wrong Hiring Month!!");
        Console.WriteLine("Enter  Hiring Month Again(from 1 to 12):");
    }

    Console.Write("Enter Hiring Year (from 1980 to This year):");
    while (!int.TryParse(Console.ReadLine(), out tempHiringYear) || tempHiringYear < 1980 || tempHiringYear > DateTime.Now.Year)
    {
        Console.WriteLine("Wrong Hiring Year!!");
        Console.WriteLine("Enter   Hiring Year Again(from 1980 to This year):");
    }

    Console.Write("Enter Gender(M or F) :");
    tempGender = Console.ReadLine();
    while (String.IsNullOrEmpty(tempGender) || (tempGender.ToUpper() != "M" && tempGender.ToUpper() != "F"))
    {
        Console.WriteLine("Wrong Gender!!");
        Console.WriteLine("Enter Gender Again(M or F)");
        tempGender = Console.ReadLine();
    }

    GenderType genderType = (GenderType)Enum.Parse(typeof(GenderType), tempGender.ToUpper());


    employees[i] = new Employee(tempID, tempName, tempSalary, tempAge, genderType,
                                new HiringDate(tempHiringDay, tempHiringMonth, tempHiringYear));

}



employees[0].SecurityLevel = SecurityLevel.Guest;
employees[1].SecurityLevel = SecurityLevel.DBA;
employees[2].SecurityLevel = SecurityLevel.Guest ^ SecurityLevel.DBA ^ SecurityLevel.Secretary;


for (int i = 0; i < employees.Length; i++)
{
    Console.WriteLine(employees[i]);
}
