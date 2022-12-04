using Microsoft.Data.SqlClient;
using System;
using System.Data;

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
                        var hashAdminPass = PasswordHashService.GetHash("admin");

                        connection.Open();
                        cmd.Connection = connection;

                        cmd.CommandText += "CREATE TABLE roles (" +
                            "role_id INT PRIMARY KEY IDENTITY," +
                            "role_name VARCHAR(255), " +
                            "INDEX role_id (role_id));";

                        cmd.CommandText += "CREATE TABLE insurance_types (" +
                            "insurance_type_id INT PRIMARY KEY IDENTITY," +
                            "insurance_type_name VARCHAR(255), " +
                            "INDEX insurance_type_id (insurance_type_id));";

                        cmd.CommandText += "CREATE TABLE users (" +
                            "username VARCHAR(255) PRIMARY KEY, " +
                            "password VARCHAR(255), " +
                            "role_id INT NOT NULL, " +
                            "INDEX username (username), " +
                            "CONSTRAINT fk_roles FOREIGN KEY (role_id) " +
                                "REFERENCES roles (role_id) ON DELETE CASCADE);";

                        cmd.CommandText += "CREATE TABLE insurances (" +
                            "insurance_id INT PRIMARY KEY IDENTITY," +
                            "insurance_name VARCHAR(255), price MONEY, " +
                            "insurance_type_id INT NOT NULL, " +
                            "INDEX insurance_id (insurance_id)," +
                            "CONSTRAINT fk_insurance_types FOREIGN KEY (insurance_type_id) " +
                                 "REFERENCES insurance_types (insurance_type_id) ON DELETE CASCADE);";


                        cmd.CommandText += "CREATE TABLE users_insurances (" +
                           "insurance_id INT NOT NULL," +
                           "username VARCHAR(255) NOT NULL," +
                           "buy_date DATE, " +
                           "PRIMARY KEY(insurance_id, username)," +
                           "INDEX insurance_id (insurance_id)," +
                           "INDEX username (username)," +
                           "CONSTRAINT fk_insurances FOREIGN KEY (insurance_id)" +
                               "REFERENCES insurances (insurance_id) ON DELETE CASCADE," +
                           "CONSTRAINT fk_users FOREIGN KEY (username)" +
                               "REFERENCES users (username) ON DELETE CASCADE);";


                        cmd.CommandText += "INSERT INTO roles VALUES (@role_name);";
                        cmd.Parameters.Add("@role_name", SqlDbType.NVarChar).Value = "Администратор";

                        cmd.CommandText += "INSERT INTO roles VALUES (@role_name1);";
                        cmd.Parameters.Add("@role_name1", SqlDbType.NVarChar).Value = "Пользователь";

                        cmd.CommandText += "INSERT INTO users VALUES (@username, @password, @role_id_user);";
                        cmd.Parameters.Add("@username", SqlDbType.NVarChar).Value = "admin";
                        cmd.Parameters.Add("@password", SqlDbType.NVarChar).Value = hashAdminPass;
                        cmd.Parameters.Add("@role_id_user", SqlDbType.Int).Value = 1;

                        cmd.CommandText += "INSERT INTO insurance_types VALUES (@insurance_type_name);";
                        cmd.Parameters.Add("@insurance_type_name", SqlDbType.NVarChar).Value = "Страхование жизни";

                        cmd.CommandText += "INSERT INTO insurance_types VALUES (@insurance_type_name1);";
                        cmd.Parameters.Add("@insurance_type_name1", SqlDbType.NVarChar).Value = "Страхование машины";

                        cmd.CommandText += "INSERT INTO insurance_types VALUES (@insurance_type_name2);";
                        cmd.Parameters.Add("@insurance_type_name2", SqlDbType.NVarChar).Value = "Страхование дома";

                        cmd.ExecuteNonQuery();
                    }

                }
                _createView("CREATE VIEW insurance_name_desc AS " +
                            "SELECT TOP(100) *FROM insurances " +
                            "ORDER BY insurance_name DESC; ", connectionString);

                _createView("CREATE VIEW insurance_name_asc AS " +
                            "SELECT TOP(100) *FROM insurances " +
                            "ORDER BY insurance_name ASC; ", connectionString);

                _createView("CREATE VIEW price_asc AS " +
                            "SELECT TOP(100) *FROM insurances " +
                            "ORDER BY price ASC; ", connectionString);

                _createView("CREATE VIEW price_desc AS " +
                            "SELECT TOP(100) *FROM insurances " +
                            "ORDER BY price DESC; ", connectionString);

                _createView("CREATE VIEW type_asc AS " +
                            "SELECT TOP(100) *FROM insurances " +
                            "ORDER BY insurance_type_id asc; ", connectionString);

                _createView("CREATE VIEW type_desc AS " +
                            "SELECT TOP(100) *FROM insurances " +
                            "ORDER BY insurance_type_id DESC; ", connectionString);

                _createView("CREATE VIEW users_not_admin " +
                            "AS SELECT TOP(100) u.username, u.password, u.role_id, r.role_name " +
                            "FROM users as u " +
                            "INNER JOIN roles as r " +
                                "ON r.role_id = u.role_id " +
                            "WHERE u.role_id = 2 " +
                            "GROUP BY u.username, u.password, u.role_id, r.role_name", connectionString);
               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        private static void _createView(string query, string connectionString)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var cmd = connection.CreateCommand())
                {
                    connection.Open();
                    cmd.Connection = connection;

                    cmd.CommandText = query;

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
