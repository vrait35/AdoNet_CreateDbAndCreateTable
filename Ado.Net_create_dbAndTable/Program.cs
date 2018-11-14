using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace Ado.Net_create_dbAndTable
{
    public class Program
    {
        static void Main(string[] args)
        {          
           string sqlQuery = "CREATE DATABASE MyDatabase14";
            string connectSqlServer = ConfigurationManager.ConnectionStrings["vrait34"].ConnectionString;
            using (SqlConnection myConn = new SqlConnection(connectSqlServer))
            {
                SqlCommand myCommand = new SqlCommand(sqlQuery, myConn);
                try
                {
                    myConn.Open();
                    myCommand.ExecuteNonQuery();
                    Console.WriteLine("DataBase is Created Successfully");
                    string connectionString = ConfigurationManager.ConnectionStrings["vrait35"].ConnectionString;
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        SqlCommand sql = new SqlCommand();
                        sql.CommandText = "create table customers(" +
                            "id int primary key identity(1,1)," +
                            "name_customer varchar(50) not null," +
                            "mob_number varchar(15) ," +
                            "el_adress varchar(50),)";
                        sql.Connection = connection;
                        try
                        {
                            sql.ExecuteNonQuery();
                        }
                        catch (SqlException ex) 
                        {
                            Console.WriteLine(ex.Message);
                           
                        }                       
                        catch(InvalidOperationException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }                   
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch(SqlException e)
                {
                    Console.WriteLine(e.Message+" таблица тоже существует");                    
                }
             
                finally
                {
                    myConn.Close();
                }
            }
        }
    }
}
