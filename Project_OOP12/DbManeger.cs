using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_OOP12
{
    internal class DbManeger
    {

        // Its string for conecting
        private static string connectionString = "Data Source=LAPTOP-P1QDASRA\\SQLEXPRESS01;Initial Catalog=University;Integrated Security=True";


        // Select last id
        public int GetLastId(string tableName, string idColumnName)
        {
            int lastId = 0;

            try
            {
                using (SqlConnection connection = GetOpenConnection())
                {
                    string query = $"SELECT MAX({idColumnName}) FROM {tableName}";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        object result = command.ExecuteScalar();

                        if (result != DBNull.Value && result != null)
                        {
                            lastId = Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }

            return lastId;
        }

        // Insert into database
        // Insert into database
        public void InsertDataIntoTable(string tableName, string name, string surname, string additionalInfo, string idColumnName, string additionalColumnName)
        {
            try
            {
                int itemId = GetLastId(tableName, idColumnName) + 1;
                using (SqlConnection connection = GetOpenConnection())
                {
                    // Use parameters to prevent SQL injection and ensure proper escaping
                    string query = $"INSERT INTO {tableName} ({idColumnName}, Name, Surname, {additionalColumnName}) VALUES (@ItemId, @Name, @Surname, @AdditionalInfo)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters with proper data types
                        command.Parameters.AddWithValue("@ItemId", itemId);
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@Surname", surname);
                        command.Parameters.AddWithValue("@AdditionalInfo", additionalInfo);

                        command.ExecuteNonQuery();
                        Console.WriteLine("Success.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }


        public void InsertDataIntoCourse(string tableName, string name, string idColumnName)
        {
            try
            {
                int itemId = GetLastId(tableName, idColumnName) + 1;
                using (SqlConnection connection = GetOpenConnection())
                {
                    // Use parameters to prevent SQL injection and ensure proper escaping
                    string query = $"INSERT INTO {tableName} ({idColumnName}, CourseName) VALUES (@ItemId, @Name)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters with proper data types
                        command.Parameters.AddWithValue("@ItemId", itemId);
                        command.Parameters.AddWithValue("@Name", name);
                        

                        command.ExecuteNonQuery();
                        Console.WriteLine("Success.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }




        // Get info by id
        public string GetInfoById(string tableName, string itemId, string idColumnName)
        {
            try
            {
                using (SqlConnection connection = GetOpenConnection())
                {
                    string query = $"SELECT * FROM {tableName} WHERE {idColumnName} = {itemId}";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            StringBuilder result = new StringBuilder();

                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                string columnName = reader.GetName(i);
                                object columnValue = reader.GetValue(i);

                                result.Append($"{columnName}: {columnValue}, ");
                            }

                            // Remove the trailing comma and space
                            result.Length -= 2;

                            return result.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }

            return "No information";
        }

        // Update database by id
        public void UpdateDataById(string tableName, string idColumnName, int itemId, string newName, string newSurname, string newThirdValue, string thirdColumnName)
        {
            try
            {
                using (SqlConnection connection = GetOpenConnection())
                {
                    // SQL-запрос для обновления данных в указанной таблице.
                    string query = $"UPDATE {tableName} SET Name = @NewName, Surname = @NewSurname, {thirdColumnName} = @NewThirdValue WHERE {idColumnName} = @ItemId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@NewName", newName);
                        command.Parameters.AddWithValue("@NewSurname", newSurname);
                        command.Parameters.AddWithValue("@NewThirdValue", newThirdValue);
                        command.Parameters.AddWithValue("@ItemId", itemId);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Update successful.");
                        }
                        else
                        {
                            Console.WriteLine($"No records were updated. {tableName} not found or specified item not found.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }


        // Delete from baza
        public void DeleteRecordById(string tableName, string idColumnName, int recordId)
        {
            try
            {
                using (SqlConnection connection = GetOpenConnection())
                {
                    // SQL-запрос для удаления записи из указанной таблицы.
                    string query = $"DELETE FROM {tableName} WHERE {idColumnName} = {recordId}";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Deletion successful.");
                        }
                        else
                        {
                            Console.WriteLine($"No records were deleted. {tableName} with the specified ID not found.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }

        // kakoi to konekt
        private SqlConnection GetOpenConnection()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }
    }
}
