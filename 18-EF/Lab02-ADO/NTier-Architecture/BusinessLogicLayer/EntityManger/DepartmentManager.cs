using DataAccessLayer;
using System.Data;

namespace BusinessLogicLayer;

public static class DepartmentManager
{
    public static DepartmentList GetAllDepartments()
    {
        DataTable deptsTable = DatabaseManager.GetQueryResult("select * from company.Department");
        DepartmentList departments = new DepartmentList();
        
        foreach(DataRow dept in deptsTable.Rows)
        {
            departments.Add(new Department()
            {
                Number = dept[0]?.ToString() ?? "No Number",
                Name = dept[1]?.ToString() ?? "No Name",
                Location = dept[2]?.ToString() ?? "No Location"
            });  
        }

        return departments;
    }
     
    public static Department? GetDepartmentByNumber(string deptNo)
    {
        Department department= new Department();
        try
        { 
            DataTable table = DatabaseManager.GetQueryResult($"select * from company.Department where DeptNo = '{deptNo}'");
            if (table.Rows.Count == 0)
                return null;
            
            department.Number = table.Rows[0][0]?.ToString() ?? "No Number";
            department.Name = table.Rows[0][1]?.ToString() ?? "No Number";
            department.Location = table.Rows[0][0]?.ToString() ?? "No Number";
        }
        catch
        {
            Console.WriteLine("invalid deptNo");
        }

        return department;
    }

    public static bool TryAddDepartment(Department department)
    {
        if (department is null)
            throw new ArgumentNullException("department is null");
        
        int result;
        try
        {
            result = DatabaseManager.ExecuteNonQuery($"insert into company.Department values ('{department.Number}','{department.Name}','{department.Location}')");
        }
        catch
        {
            throw new ArgumentException("department id is already existing!");
        }

        if(result == -1)
            return false;

        return true;
    }


    public static bool TryUpdateDepartment(string deptNo ,Department updatedDept)
    {
        if (deptNo is null || updatedDept is null)
            throw new ArgumentNullException("arguemnt is null!!");

        Department? department = GetDepartmentByNumber(deptNo);

        if (department is null)
            throw new ArgumentException("there's no department with this ID!!");

        int result = -1;
        try
        {
            string cmd = @$"update company.department
                               set DeptName ='{updatedDept.Name}' ,Location ='{updatedDept.Location}'
                                   where DeptNo = '{deptNo}'";

            result = DatabaseManager.ExecuteNonQuery(cmd);
        }
        catch
        {
            Console.WriteLine("updated department data is incorrect!");
        }

        if(result == -1)
            return false;

        return true;
    }


    public static bool TryDeleteDepartment(string deptNo)
    {
        if (string.IsNullOrWhiteSpace(deptNo))
            throw new ArgumentException("deptNo can't be null or empty or whiteSpace");

        int result = -1;

        try
        {
            string cmd =$@"delete from company.Department
                                    where DeptNo = '{deptNo}'";


            result = DatabaseManager.ExecuteNonQuery(cmd);
        }
        catch
        {
            Console.WriteLine("invalid department number!");
        }

        if(result == -1)
            return false;

        return true;

    }

}
