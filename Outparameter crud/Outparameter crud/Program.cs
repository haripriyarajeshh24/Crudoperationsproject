using System;
using System.Data;
using System.Data.SqlClient;

namespace Outparameter_crud
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SqlConnection sqlConnection;
                string connectingsql = @"Data Source=Xminds24\MSSQLSERVER02;Initial Catalog=testdb;Integrated Security=True";
                sqlConnection = new SqlConnection(connectingsql);
                sqlConnection.Open();
                Console.WriteLine("Connection successful");
                Console.WriteLine("Enter student id for retrieving data");
                int stud_id = int.Parse(Console.ReadLine());
                SqlCommand selectCommand = new SqlCommand("GetStudent", sqlConnection);
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.Parameters.AddWithValue("@student_id", stud_id);
                selectCommand.Parameters.Add("@name", SqlDbType.VarChar, 50);
                selectCommand.Parameters["@name"].Direction = ParameterDirection.Output;
                selectCommand.Parameters.Add("@age", SqlDbType.Int);
                selectCommand.Parameters["@age"].Direction = ParameterDirection.Output;
                selectCommand.Parameters.Add("@dept", SqlDbType.VarChar, 50);
                selectCommand.Parameters["@dept"].Direction = ParameterDirection.Output;
                selectCommand.ExecuteNonQuery();
                Console.WriteLine($"Name : " + selectCommand.Parameters["@name"].Value.ToString()+
                    $"\n Age : " + selectCommand.Parameters["@age"].Value.ToString()+
                    $"\n Department : " + selectCommand.Parameters["@dept"].Value.ToString());
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
