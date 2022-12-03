using CourseWorkDB.Models;
using CourseWorkDB.Utilities;
using Microsoft.Data.SqlClient;
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

        public override void Create(UsersInsurancesModel item)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var cmd = connection.CreateCommand())
                {
                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandText = "INSERT INTO users_insurances VALUES (@insurance_id, @username);";
                    cmd.Parameters.Add("@insurance_id", SqlDbType.Int).Value = item.InsuranceId;
                    cmd.Parameters.Add("@username", SqlDbType.NVarChar).Value = item.Username;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public override void Delete(int id)
        {
            throw new System.NotImplementedException();
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

        public override UsersInsurancesModel Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public override IEnumerable<UsersInsurancesModel> GetList(SortModel sort = null)
        {
            throw new System.NotImplementedException();
            //var incuranceList = new List<UsersInsurancesModel>();
            //using (var connection = new SqlConnection(connectionString))
            //{
            //    using (var cmd = connection.CreateCommand())
            //    {
            //        connection.Open();
            //        cmd.Connection = connection;
            //        cmd.CommandText = "SELECT *FROM insurances";
            //        using (var reader = cmd.ExecuteReader())
            //        {
            //            while (reader.Read())
            //            {
            //                var incuranceModel = new InsuranceModel();
            //                incuranceModel.IncuranceId = (int)reader[0];
            //                incuranceModel.IncuranceName = reader[1].ToString();
            //                incuranceModel.Price = (decimal)reader[2];
            //                incuranceList.Add(incuranceModel);
            //            }
            //        }
            //    }
            //}

            //return incuranceList;


        }

        public override void Save()
        {
            throw new System.NotImplementedException();
        }

        public override void Update(UsersInsurancesModel item)
        {
            throw new System.NotImplementedException();
            //using (var connection = new SqlConnection(connectionString))
            //{
            //    using (var cmd = connection.CreateCommand())
            //    {
            //        connection.Open();
            //        cmd.Connection = connection;
            //        cmd.CommandText = "UPDATE insurances SET insurance_name=@insurance_name, price=@price WHERE insurance_id=@id";
            //        cmd.Parameters.Add("@insurance_name", SqlDbType.NVarChar).Value = item.IncuranceName;
            //        cmd.Parameters.Add("@price", SqlDbType.Money).Value = item.Price;
            //        cmd.Parameters.Add("@id", SqlDbType.Int).Value = item.IncuranceId;
            //        cmd.ExecuteNonQuery();
            //    }
            //}
        }
    }
}
