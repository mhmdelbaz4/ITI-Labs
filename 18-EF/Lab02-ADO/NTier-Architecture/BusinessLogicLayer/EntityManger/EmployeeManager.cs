using DataAccessLayer;
using System.Data;

namespace BusinessLogicLayer.EntityManger;

public class EmployeeManager
{
    public static EmployeeList GetAllDepartments()
    {
        DataTable deptsTable = DatabaseManager.GetQueryResult("select * from HR.Employee");
        EmployeeList emps = new EmployeeList();

        foreach (DataRow emp in deptsTable.Rows)
        {
            emps.Add(new Employee()
            {
                Id = (emp[0] is null ? -1 : (int.Parse((string) emp[0]))),
                FName = emp[1].ToString(),
                LName = emp[2].ToString(),
                DeptNo = emp[3]?.ToString(),
                Salary = (emp[4] is null ? 0 : (int.Parse((string)emp[4]))),
            });
        }

        return emps;
    }

    public static Employee? GetEmployeeById(int id)
    {
        Employee?  emp= new Employee();
        try
        {
            DataTable table = DatabaseManager.GetQueryResult($"select * from HR.Employee where  EmpNo = {id}");
            if (table.Rows.Count == 0)
                return null;


            emp.Id = (table.Rows[0][0] is null ? -1 : (int.Parse((string)table.Rows[0][0])));
            emp.FName = table.Rows[0][1].ToString();
            emp.LName = table.Rows[0][2].ToString();
            emp.DeptNo = table.Rows[0][3]?.ToString();
            emp.Salary = (table.Rows[0][4] is null ? 0 : (int.Parse((string)table.Rows[0][4])));

        }
        catch
        {
            Console.WriteLine("invalid emp id");
        }

        return emp;
    }

    public static bool TryAddEmployee(Employee emp)
    {
        if (emp is null)
            throw new ArgumentNullException("emp is null");

        int result;
        try
        {
            result = DatabaseManager.ExecuteNonQuery($"insert into HR.Employee values ({emp.Id},'{emp.FName}','{emp.LName}' ,'{emp.DeptNo}' ,{emp.Salary})");
        }
        catch
        {
            throw new ArgumentException("Employee id is already existing!");
        }

        if (result == -1)
            return false;

        return true;
    }


    public static bool TryUpdateEmployee(int id, Employee updatedEmp)
    {
        if (id < 0 || updatedEmp is null)
            throw new ArgumentNullException("arguemnt is null!!");

        Employee? emp = GetEmployeeById(id);

        if (emp is null)
            throw new ArgumentException("there's no employee with this ID!!");

        int result = -1;
        try
        {
            string cmd = @$"update company.department
                                set FName='{updatedEmp.FName}' ,LName ='{updatedEmp.LName}' ,DeptNo ='{updatedEmp.DeptNo}' ,Salary ={updatedEmp.Salary}
                                where EmpNo ={id}";

            result = DatabaseManager.ExecuteNonQuery(cmd);
        }
        catch
        {
            Console.WriteLine("updated Employee data is incorrect!");
        }

        if (result == -1)
            return false;

        return true;
    }


    public static bool TryDeleteEmployee(int id)
    {
        if (id < 0)
            throw new ArgumentException("id can't negative");

        int result = -1;

        try
        {
            string cmd = $@"delete from HR.Employee
                                    where EmpNo = '{id}'";


            result = DatabaseManager.ExecuteNonQuery(cmd);
        }
        catch
        {
            Console.WriteLine("invalid employee number!");
        }

        if (result == -1)
            return false;

        return true;

    }
}
