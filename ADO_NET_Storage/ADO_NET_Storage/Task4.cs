using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace ADO_NET_Storage
{
    abstract class Task4
    {
        //Показати товари, заданої категорії;
        public static void infoCategoryByName(string categoryName)
        {
            SqlDataReader reader = null;
            string connectionText = @"SELECT ProductName as Product, Price, CategoryName as Category
                                      FROM Products
                                      JOIN Categorys ON Products.CategoryId=Categorys.Id
                                      WHERE CategoryName='" + categoryName + "';";
            try
            {
                Program.connection.Open();
                SqlCommand command = new SqlCommand(connectionText, Program.connection);
                reader = command.ExecuteReader();
                int row = 0;
                while (reader.Read())
                {
                    if (row == 0)
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            Console.Write(reader.GetName(i).ToString() + "\t");
                        }
                        Console.WriteLine();
                    }

                    row++;
                    Console.WriteLine($"{reader["Product"]}\t{reader["Price"]}\t{reader["Category"]}");
                }
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (Program.connection != null)
                {
                    Program.connection.Close();
                }
            }
        }
        //Показати товари, задані постачальником;
        public static void infoByManufacturerName(string name)
        {
            SqlDataReader reader = null;
            string connectionText = @"SELECT ProductName as Product, Price, ManufacturerName as Manufacturer
                                      FROM Products
                                      JOIN Manufacturers ON Products.ManufacturerId=Manufacturers.Id
                                      WHERE ManufacturerName='" + name + "';";
            try
            {
                Program.connection.Open();
                SqlCommand command = new SqlCommand(connectionText, Program.connection);
                reader = command.ExecuteReader();
                int row = 0;
                while (reader.Read())
                {
                    if (row == 0)
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            Console.Write(reader.GetName(i).ToString() + "\t");
                        }
                        Console.WriteLine();
                    }

                    row++;
                    Console.WriteLine($"{reader["Product"]}\t{reader["Price"]}\t{reader["Manufacturer"]}");
                }
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (Program.connection != null)
                {
                    Program.connection.Close();
                }
            }
        }
        //Показати найстаріший товар на складі;
        public static void infoOldestProduct()
        {
            SqlDataReader reader = null;
            string connectionText = @"SELECT ProductName as Product, Price, DeliveryDt as Delivery
                                      FROM Products
                                      WHERE DeliveryDt = (SELECT MIN(DeliveryDt) FROM Products);";
            try
            {
                Program.connection.Open();
                SqlCommand command = new SqlCommand(connectionText, Program.connection);
                reader = command.ExecuteReader();
                int row = 0;
                while (reader.Read())
                {
                    if (row == 0)
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            Console.Write(reader.GetName(i).ToString() + "\t");
                        }
                        Console.WriteLine();
                    }

                    row++;
                    Console.WriteLine($"{reader["Product"]}\t{reader["Price"]}\t{reader["Delivery"]}");
                }
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (Program.connection != null)
                {
                    Program.connection.Close();
                }
            }
        }
        //Показати середню кількість товарів по кожному типу товару.
        public static void countProductsByCategory()
        {
            SqlDataReader reader = null;
            string connectionText = @"SELECT CategoryName, COUNT(Products.Id) as [Product count]
                                      FROM Products
                                      JOIN Categorys ON CategoryId = Categorys.Id
                                      GROUP BY CategoryName;";
            try
            {
                Program.connection.Open();
                SqlCommand command = new SqlCommand(connectionText, Program.connection);
                reader = command.ExecuteReader();
                int row = 0;
                while (reader.Read())
                {
                    if (row == 0)
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            Console.Write(reader.GetName(i).ToString() + "\t");
                        }
                        Console.WriteLine();
                    }

                    row++;
                    Console.WriteLine($"{reader["CategoryName"], -16}{reader["Product count"]}");
                }
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (Program.connection != null)
                {
                    Program.connection.Close();
                }
            }
        }
    }
}
