using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Xml;

namespace DataAccessLayer;

public static class DatabaseManager
{
    private static SqlConnection sqlConnection;
    private static SqlDataAdapter adapter;
    private static SqlCommand cmd;

    static DatabaseManager()
    {
        string connection = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ConnectionString").Value;
        
        sqlConnection = new SqlConnection(connection);
        cmd = new SqlCommand();
        cmd.Connection = sqlConnection;

    }

    public static DataTable GetQueryResult(string cmdText)
    {
        DataTable tableResult = new DataTable();
        cmd.CommandText = cmdText;
        try
        {
            sqlConnection.Open();
            try
            {
                adapter = new SqlDataAdapter(cmd);
                adapter.Fill(tableResult);
            }
            catch
            {
                throw new ArgumentException("invalid sql command");
            }
        }
        catch(InvalidOperationException ex)
        {
            Console.WriteLine("DB Connection Error");
        }
        catch (SqlException ex)
        {
            Console.WriteLine("DB Connection Error");
        }
        finally
        { 
            sqlConnection.Close(); 
        }

        return tableResult;
    }


    public static int ExecuteNonQuery(string cmdText)
    {
        cmd.CommandText = cmdText;
        int result =-1;
        try
        {
            sqlConnection.Open();
            try
            {
                result = cmd.ExecuteNonQuery();
            }
            catch
            {
                throw new ArgumentException("Invalid command");
            }
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine("DB Connection Error");
        }
        catch (SqlException ex)
        {
            Console.WriteLine("DB Connection Error");
        }
        finally
        {
            sqlConnection.Close();
        }

        return result;
    }
}

