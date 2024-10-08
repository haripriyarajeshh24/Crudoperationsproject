﻿using System;
using System.Data.SqlClient;


namespace Crudoperationsproject
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
                Console.WriteLine("Enter student name");
                string name = Console.ReadLine();
                Console.WriteLine("Enter age");
                int age = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Department");
                string department = Console.ReadLine();
                string insertQuery = "INSERT INTO Students (Name, Age, Department) VALUES ('" + name + "'," + age + ", '" + department + "')";
                SqlCommand insertCommand = new SqlCommand(insertQuery, sqlConnection);
                insertCommand.ExecuteNonQuery();
                Console.WriteLine("Datas inserted successfully");
                string selectallquery = "select * from Students";
                SqlCommand selectCommand = new SqlCommand(selectallquery, sqlConnection);
                SqlDataReader datareader = selectCommand.ExecuteReader();
                Console.WriteLine("Students in Db are : ");
                while (datareader.Read())
                {
                    Console.WriteLine("Id : " + datareader.GetValue(0).ToString());
                    Console.WriteLine("Name : " + datareader.GetValue(1).ToString()); 
                    Console.WriteLine("Age : " + datareader.GetValue(2).ToString());
                    Console.WriteLine("Department : " + datareader.GetValue(3).ToString());
                }
                datareader.Close();
                Console.WriteLine("Enter the StudentId of student whos depeartment need to be updated : ");
                int stud_id = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the depertament to be updated");
                string change_dept = Console.ReadLine();
                string updatequery = "Update Students Set Department ='" + change_dept + "' Where StudentID = " + stud_id + " ";
                SqlCommand updateCommand = new SqlCommand(updatequery, sqlConnection);
                updateCommand.ExecuteNonQuery();
                Console.WriteLine("Department updated successfully");
                Console.WriteLine("Enter student id to be removed");
                int delete_id = int.Parse(Console.ReadLine());
                string deleteQuery = "Delete from Students where StudentID=" + delete_id + "";
                SqlCommand deleteCommand = new SqlCommand(deleteQuery, sqlConnection);
                deleteCommand.ExecuteNonQuery();
                Console.WriteLine("Data deleted successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
