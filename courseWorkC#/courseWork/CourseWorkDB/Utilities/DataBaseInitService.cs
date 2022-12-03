using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Threading.Tasks;

namespace CourseWorkDB.Utilities
{
    public class DataBaseInitService
    {
        public static bool DoesTableExist(string connectionString, string tableName)
        {
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    DataTable dTable = conn.GetSchema("TABLES",
                                   new string[] { null, null, tableName });
                    Console.WriteLine(dTable.TableName);
                    return dTable.Rows.Count > 0;
                }
            }
            catch
            {
                return false;
            }
        }

        public static void InitDatabase(string connectionString)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    using (var cmd = connection.CreateCommand())
                    {
                        connection.Open();
                        cmd.Connection = connection;
                        cmd.CommandText = "CREATE TABLE users (" +
                            "username VARCHAR(255) PRIMARY KEY, " +
                            "password VARCHAR(255), is_admin BIT);";
                        cmd.CommandText += "CREATE TABLE insurances (" +
                            "insurance_id INT PRIMARY KEY IDENTITY," +
                            "insurance_name VARCHAR(255), price MONEY);";
                        cmd.CommandText += "CREATE TABLE users_insurances (" +
                            "insurance_id INT NOT NULL," +
                            "username VARCHAR(255) NOT NULL," +
                            "PRIMARY KEY(insurance_id, username)," +
                            "INDEX insurance_id (insurance_id)," +
                            "INDEX username (username)," +
                            "CONSTRAINT fk_insurances FOREIGN KEY (insurance_id)" +
                                "REFERENCES insurances (insurance_id) ON DELETE CASCADE," +
                            "CONSTRAINT fk_users FOREIGN KEY (username)" +
                                "REFERENCES users (username) ON DELETE CASCADE);";

                        cmd.CommandText += "INSERT INTO users VALUES (@username, @password, @is_admin);";
                        cmd.Parameters.Add("@username", SqlDbType.NVarChar).Value = "admin";
                        cmd.Parameters.Add("@password", SqlDbType.NVarChar).Value = "admin";
                        cmd.Parameters.Add("@is_admin", SqlDbType.Bit).Value = 1;

                        cmd.ExecuteNonQuery();
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
