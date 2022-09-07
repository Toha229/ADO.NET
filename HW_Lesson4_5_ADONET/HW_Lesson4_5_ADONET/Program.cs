using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace HW_Lesson4_5_ADONET
{
    class Program
    {
        static void Main(string[] args)
        {
            //            Назва товару;
            //■ Тип товару;
            //■ Постачальник товару;
            //■ Кількість товару;
            //■ Собівартість;
            //■ Дата постачання.
            string connectionStringLocalDB = "Server=(localdb)\\mssqllocaldb;Database=master;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionStringLocalDB))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("База данних Підключена");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                try
                {
                    command.CommandText = "CREATE DATABASE Foods;";
                    command.ExecuteNonQuery();
                    command.CommandText = "USE Foods;" +
                                          "CREATE TABLE VegetablesAndFruits" +
                                          "(" +
                                          "Id INT PRIMARY KEY IDENTITY," +
                                          "Name NVARCHAR(100) NOT NULL," +
                                          "Type NVARCHAR(10) NOT NULL," +
                                          "Color NVARCHAR(10) NOT NULL," +
                                          "Calories INT NOT NULL CHECK(Calories>=0)" +
                                          ");";
                    command.ExecuteNonQuery();
                    command.CommandText = @"USE Foods;
                                            INSERT INTO VegetablesAndFruits(Name, Type, Color, Calories)
                                            VALUES
                                            (N'Томат', N'Овоч', N'Червоний', 20),
                                            (N'Яблуко', N'Фрукт', N'Червоний', 46),
                                            (N'Персик', N'Фрукт', N'Оранджевий', 45),
                                            (N'Картопля', N'Овоч', N'Коричневий', 74),
                                            (N'Редис', N'Овоч', N'Рожевий', 24);";
                    command.ExecuteNonQuery();
                    Console.WriteLine("БД Створена");
                }
                catch { }
            }
        }
    }
}
