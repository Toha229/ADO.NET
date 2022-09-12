using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
//using Microsoft.Data.SqlClient;
using System.Configuration;

namespace ADO_NET_Storage
{
    class Program
    {
        public static SqlConnection connection = null;
        public Program()
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=StorageDb;Integrated Security=True;";
            connection = new SqlConnection(connectionString);
        }

        static void Main(string[] args)
        {
            Program workerDB = new Program();
            workerDB.InfoConnection();
            br();
            Task3.infoAllProduct();
            br();
            Task3.InfoAllProductCategories();
            br();
            Task3.InfoAllProductManufacturers();
            br();
            Task3.sumaProduct();
            br();
            Task3.maxProduct();
            br();
            Task3.minProduct();
            br();
            Task3.maxProductPrice();
            br();
            Task3.minProductPrice();
            br();
            Task4.infoCategoryByName("Drinks");
            br();
            Task4.infoByManufacturerName("Chernigivske");
            br();
            Task4.infoOldestProduct();
            br();
            Task4.countProductsByCategory();
            br();
            Console.Read();
        }
        //task2
        public void InfoConnection()
        {
            try
            {
                connection.Open();
                Console.WriteLine("Пiдключення вiдкрито");
                // Виведення інформації про підключення
                Console.WriteLine("Властивостi пiдключення:");
                Console.WriteLine($"\tРядок пiдключення: {connection.ConnectionString}");
                Console.WriteLine($"\tБаза даних: {connection.Database}");
                Console.WriteLine($"\tСервер: {connection.DataSource}");
                Console.WriteLine($"\tВерсiя сервера: {connection.ServerVersion}");
                Console.WriteLine($"\tСтан: {connection.State}");
                Console.WriteLine($"\tWorkstationld: {connection.WorkstationId}");
                Console.WriteLine(connection.ClientConnectionId);
            }
            catch (SqlException err)
            {
                Console.WriteLine(err.Message);
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }

            }
        }
        public static void br()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
