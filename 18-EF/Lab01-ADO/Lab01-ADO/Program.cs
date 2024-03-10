using Lab01_ADO;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;

string? connectionString = new ConfigurationBuilder()
                                        .AddJsonFile("appSettings.json")
                                        .Build()
                                        .GetSection("connectionString")
                                        .Value;


SqlConnection sqlConnection = new SqlConnection(connectionString);

SqlCommand getDepartmentsCommand = new SqlCommand("select * from company.Department", sqlConnection);

sqlConnection.Open();

List<Department> departments = new List<Department>();
SqlDataReader sqlDataReaderDepartment = getDepartmentsCommand.ExecuteReader();
Department tempDept;
Console.WriteLine("***************Departments**********************");
while (sqlDataReaderDepartment.Read())
{
    tempDept = new Department()
    {
        Id = sqlDataReaderDepartment[0]?.ToString(),
        Name = sqlDataReaderDepartment[1]?.ToString(),
        Location = sqlDataReaderDepartment[2]?.ToString()
    };
    departments.Add(tempDept);
    Console.WriteLine(tempDept.ToString());
}
sqlConnection.Close();


SqlCommand getEmpsCommand = new SqlCommand("select * from HR.Employee", sqlConnection);
sqlConnection.Open();
SqlDataReader sqlDataReaderEmps = getEmpsCommand.ExecuteReader();
List<Employee> emps = new List<Employee>();
Employee tempEmployee;
Console.WriteLine("Employees");
while (sqlDataReaderEmps.Read())
{
    tempEmployee = new Employee()
    {
        Id = int.Parse(sqlDataReaderEmps[0].ToString()),
        FirstName = sqlDataReaderEmps[1]?.ToString(),
        LastName = sqlDataReaderEmps[2]?.ToString(),
        Salary = int.Parse(sqlDataReaderEmps[4]?.ToString()),
        DeptId = sqlDataReaderEmps[3]?.ToString(),
    };
    emps.Add(tempEmployee);
    Console.WriteLine(tempEmployee);
}
sqlConnection.Close();



SqlCommand insertEmployee = new SqlCommand("insert into HR.Employee Values (@id,@fname,@lname,@DId,@salary)",sqlConnection);
insertEmployee.Parameters.Add(new SqlParameter() { ParameterName = "@id", DbType = DbType.Int64 ,Value=102});
insertEmployee.Parameters.Add(new SqlParameter() { ParameterName = "@fname", DbType = DbType.String, Value = "Mohamed" });
insertEmployee.Parameters.Add(new SqlParameter() { ParameterName = "@lname", DbType = DbType.String, Value = "Elbaz" });
insertEmployee.Parameters.Add(new SqlParameter() { ParameterName = "@DId", DbType = DbType.String, Value = "d1" });
insertEmployee.Parameters.Add(new SqlParameter() { ParameterName = "@salary", DbType = DbType.Int64, Value = 15000 });

sqlConnection.Open();
//int affectedRows = insertEmployee.ExecuteNonQuery();
//Console.WriteLine($"number of affected rows :{affectedRows}");
sqlConnection.Close();



SqlCommand updateDeptNameCommand = new SqlCommand("updateDepartmentName" ,sqlConnection);
updateDeptNameCommand.CommandType = CommandType.StoredProcedure;

updateDeptNameCommand.Parameters.Add(new SqlParameter() { ParameterName = "@id", DbType = DbType.String, Value = "d1"});
updateDeptNameCommand.Parameters.Add(new SqlParameter() { ParameterName = "@name", DbType = DbType.String, Value = "d1-updated" });

sqlConnection.Open();
int affectedRows = updateDeptNameCommand.ExecuteNonQuery();
sqlConnection.Close();

Console.WriteLine($"number of affected rows :{affectedRows}");


SqlCommand deleteDepartmentCommand= new SqlCommand("deleteDeptById", sqlConnection);
deleteDepartmentCommand.CommandType = CommandType.StoredProcedure;
deleteDepartmentCommand.Parameters.Add(new SqlParameter() { ParameterName = "@deptId", DbType = DbType.String, Value = "d3" });

//sqlConnection.Open();
//int affectedRows2 = deleteDepartmentCommand.ExecuteNonQuery();
//sqlConnection.Close();

//Console.WriteLine($"number of affected rows :{affectedRows2}");


sqlConnection.Open();

SqlCommand getStudentsCommand = new SqlCommand("select * from HR.Employee", sqlConnection);
SqlDataAdapter adapter = new SqlDataAdapter(getStudentsCommand);

SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(adapter);
Console.WriteLine(sqlCommandBuilder.GetInsertCommand().CommandText);
















