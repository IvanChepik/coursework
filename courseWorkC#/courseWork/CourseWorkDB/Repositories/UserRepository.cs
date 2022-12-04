using CourseWorkDB.Models;
using CourseWorkDB.Utilities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace CourseWorkDB.Repositories
{
    public class UserRepository: BaseRepository<UserModel>
    {
        public UserRepository()
        {
        }

        public UserRepository(string connectionString) {
            this.connectionString = connectionString;
        }

        public void Create(UserModel item)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var cmd = connection.CreateCommand())
                {
                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandText = "INSERT INTO users VALUES (@username, @password, @role_id);";
                    cmd.Parameters.Add("@username", SqlDbType.NVarChar).Value = item.UserName;
                    cmd.Parameters.Add("@password", SqlDbType.NVarChar).Value = item.Password;
                    cmd.Parameters.Add("@role_id", SqlDbType.Int).Value = 2;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public UserModel GetByCredentials(string username, string password)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var cmd = connection.CreateCommand())
                {
                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandText = "SELECT TOP 1 *FROM users WHERE username=@username and password=@password";
                    cmd.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;
                    cmd.Parameters.Add("@password", SqlDbType.NVarChar).Value = password;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var userModel = new UserModel();
                            userModel.UserName = reader[0].ToString();
                            userModel.Password = reader[1].ToString();
                            userModel.RoleId = (int)reader[2];
                            return userModel;
                        }
                    }
                }
            }

            return null;
        }

        public UserModel GetByLogin(string username)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var cmd = connection.CreateCommand())
                {
                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandText = "SELECT TOP 1 *FROM users WHERE username=@username";
                    cmd.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var userModel = new UserModel();
                            userModel.UserName = reader[0].ToString();
                            userModel.Password = reader[1].ToString();
                            userModel.RoleId = (int)reader[2];
                            return userModel;
                        }
                    }
                }
            }

            return null;
        }


        public IEnumerable<UserModel> GetList(SortModel sort = null)
        {
            var userList = new List<UserModel>();
            using (var connection = new SqlConnection(connectionString))
            {
                using (var cmd = connection.CreateCommand())
                {
                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandText = "SELECT * FROM users_not_admin";
                    if (sort != null)
                    {
                        cmd.CommandText += $" ORDER BY {sort.Field} {sort.Order}";
                    }
                    cmd.CommandText += ";";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var userModel = new UserModel();
                            userModel.UserName = reader[0].ToString();
                            userModel.Password = reader[1].ToString();
                            userModel.RoleId = (int)reader[2];
                            userModel.RoleName = reader[3].ToString(); 
                            userList.Add(userModel);
                        }
                    }
                }
            }

            return userList;
        }

    }
}
