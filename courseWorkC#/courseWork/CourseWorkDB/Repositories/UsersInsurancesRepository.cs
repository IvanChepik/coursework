using CourseWorkDB.Models;
using CourseWorkDB.Utilities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace CourseWorkDB.Repositories
{
    public class UsersInsurancesRepository : BaseRepository<UsersInsurancesModel>
    {
        public UsersInsurancesRepository()
        {
        }

        public UsersInsurancesRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Create(UsersInsurancesModel item)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var cmd = connection.CreateCommand())
                {
                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandText = "INSERT INTO users_insurances VALUES (@insurance_id, @username, @date);";
                    cmd.Parameters.Add("@insurance_id", SqlDbType.Int).Value = item.InsuranceId;
                    cmd.Parameters.Add("@username", SqlDbType.NVarChar).Value = item.Username;
                    cmd.Parameters.Add("date", SqlDbType.Date).Value = DateTime.Now;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int insurance_id, string username)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "DELETE FROM users_insurances " +
                    "WHERE insurance_id=@insurance_id AND username = @username;";
                command.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;
                command.Parameters.Add("@insurance_id", SqlDbType.Int).Value = insurance_id;
                command.ExecuteNonQuery();
            }
        }


    }
}
