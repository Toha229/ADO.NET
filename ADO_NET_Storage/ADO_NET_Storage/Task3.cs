using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;


namespace ADO_NET_Storage
{
    abstract class Task3
    {
        //-Відображення всієї інформації про товар;
        public static void infoAllProduct()
        {
            SqlDataReader reader = null;
            try
            {
                Program.connection.Open();
                SqlCommand command = new SqlCommand();
                command.CommandText = @"SELECT ProductName as Product, Price, Amount, DeliveryDt, CreatedDt, ManufacturerName, CategoryName
                                      FROM Products as P
                                      JOIN Manufacturers as M ON P.ManufacturerId=M.Id
                                      JOIN Categorys as C ON P.CategoryId=C.Id;";
                command.Connection = Program.connection;
                reader = command.ExecuteReader();

                int row = 0;
                while (reader.Read())
                {
                    //Console.WriteLine(reader[0] + " " + reader[1] + " " + reader[2] + " " + reader[5]);
                    //Console.WriteLine(reader["Product"] + " " + reader["Price"] + " " + reader["ManufacturerName"] + " " + reader["CategoryName"]);
                    if (row == 0)
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            Console.Write(reader.GetName(i).ToString() + "\t");
                        }
                        Console.WriteLine();
                    }

                    row++;
                    string productName = reader.GetString(0);
                    Decimal price = reader.GetDecimal(1);
                    Int32 amount = reader.GetInt32(2);
                    DateTime deliveryDt = reader.GetDateTime(3);
                    DateTime createdDt = reader.GetDateTime(4);
                    string manufacturerName = reader.GetString(5);
                    string categoryName = reader.GetString(6);


                    Console.WriteLine($"{productName}\t{price}\t{amount}\t{deliveryDt}\t{createdDt}\t{manufacturerName}\t{categoryName}");

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

        //Відображення всіх типів товарів;
        public static void InfoAllProductCategories()
        {
            SqlDataReader reader = null;
            string connectionText = @"SELECT CategoryName FROM Categorys";
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
                    Console.WriteLine($"{reader["CategoryName"]}");
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
        //Відображення всіх постачальників;
        public static void InfoAllProductManufacturers()
        {
            SqlDataReader reader = null;
            string connectionText = @"SELECT * FROM Manufacturers";
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
                    Console.WriteLine($"{reader["ManufacturerName"], -15}\t{reader["Address"], -8}\t{reader["Details"]}\t{reader["Email"], -25}\t{reader["Phone"]}");
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

        //Показати загальну кількість товару;
        public static void sumaProduct()
        {
            string connectionText = @"SELECT Sum(Amount) FROM Products";
            try
            {
                Program.connection.Open();
                SqlCommand command = new SqlCommand(connectionText, Program.connection);
                object sumaAmount = command.ExecuteScalar();
                Console.WriteLine($"In table Products sumaAmount {sumaAmount}");
            }
            finally
            {
                if (Program.connection != null)
                {
                    Program.connection.Close();
                }
            }

        }
        //Показати товар із максимальною кількістю;
        public static void maxProduct()
        {
            SqlDataReader reader = null;
            string connectionText = @"SELECT ProductName, Amount 
                                      FROM Products 
                                      WHERE Amount=(SELECT MAX(Amount) FROM Products)";
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
                    Console.WriteLine($"{reader["ProductName"]}\t{reader["Amount"]}");
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
        //Показати товар із мінімальною кількістю;
        public static void minProduct()
        {
            SqlDataReader reader = null;
            string connectionText = @"SELECT ProductName, Amount 
                                      FROM Products 
                                      WHERE Amount=(SELECT MIN(Amount) FROM Products)";
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
                    Console.WriteLine($"{reader["ProductName"]}\t{reader["Amount"]}");
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
        //Показати товар із максимальною собівартістю;
        public static void maxProductPrice()
        {
            SqlDataReader reader = null;
            string connectionText = @"SELECT ProductName, Price 
                                      FROM Products 
                                      WHERE Price=(SELECT MAX(Price) FROM Products)";
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
                    Console.WriteLine($"{reader["ProductName"]}\t{reader["Price"]}");
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
        //Показати товар із мінімальною собівартістю;
        public static void minProductPrice()
        {
            SqlDataReader reader = null;
            string connectionText = @"SELECT ProductName, Price 
                                      FROM Products 
                                      WHERE Price=(SELECT MIN(Price) FROM Products)";
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
                    Console.WriteLine($"{reader["ProductName"]}\t{reader["Price"]}");
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
