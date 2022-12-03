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

        public override void Create(UserModel item)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var cmd = connection.CreateCommand())
                {
                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandText = "INSERT INTO users VALUES (@username, @password, @is_admin);";
                    cmd.Parameters.Add("@username", SqlDbType.NVarChar).Value = item.UserName;
                    cmd.Parameters.Add("@password", SqlDbType.NVarChar).Value = item.Password;
                    cmd.Parameters.Add("@is_admin", SqlDbType.Bit).Value = 0;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public override void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public override UserModel Get(int id)
        {
            throw new System.NotImplementedException();
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
                            userModel.IsAdmin = Convert.ToBoolean(reader[2]);
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
                            userModel.IsAdmin = Convert.ToBoolean(reader[2]);
                            return userModel;
                        }
                    }
                }
            }

            return null;
        }


        public override IEnumerable<UserModel> GetList(SortModel sort = null)
        {
            var userList = new List<UserModel>();
            using (var connection = new SqlConnection(connectionString))
            {
                using (var cmd = connection.CreateCommand())
                {
                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandText = "SELECT u.username, u.password, u.is_admin " +
                        "FROM users as u " +
                        "LEFT JOIN users_insurances as ui " +
                            "ON ui.username = u.username " +
                        "WHERE u.is_admin = 0 " +
                        "GROUP BY u.username, u.password, u.is_admin";
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
                            userModel.IsAdmin = Convert.ToBoolean(reader[2]);
                            userModel.InsuranceCount = reader.FieldCount < 4? 0: (int)reader[3];
                            userList.Add(userModel);
                        }
                    }
                }
            }

            return userList;
        }

        public override void Save()
        {
            throw new System.NotImplementedException();
        }

        public override void Update(UserModel item)
        {
            throw new System.NotImplementedException();
        }
    }
}
