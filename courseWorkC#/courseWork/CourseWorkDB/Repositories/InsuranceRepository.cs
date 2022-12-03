using CourseWorkDB.Models;
using CourseWorkDB.Utilities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace CourseWorkDB.Repositories
{
    public class InsuranceRepository : BaseRepository<InsuranceModel>
    {
        public InsuranceRepository()
        {
        }

        public InsuranceRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public override void Create(InsuranceModel item)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var cmd = connection.CreateCommand())
                {
                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandText = "INSERT INTO insurances VALUES (@insurance_name, @price);";
                    cmd.Parameters.Add("@insurance_name", SqlDbType.NVarChar).Value = item.IncuranceName;
                    cmd.Parameters.Add("@price", SqlDbType.Money).Value = item.Price;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public override void Delete(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "DELETE FROM insurances " +
                    "WHERE insurance_id=@insurance_id";
                command.Parameters.Add("@insurance_id", SqlDbType.Int).Value = id;
                command.ExecuteNonQuery();
            }
        }

        public override InsuranceModel Get(int id)
        {
            throw new System.NotImplementedException();
        }
        
        public override IEnumerable<InsuranceModel> GetList(SortModel sort = null)
        {
            var incuranceList = new List<InsuranceModel>();
            using (var connection = new SqlConnection(connectionString))
            {
                using (var cmd = connection.CreateCommand())
                {
                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandText = "SELECT *FROM insurances";
                    if (sort != null)
                    {
                        cmd.CommandText += $" ORDER BY {sort.Field} {sort.Order}";
                    }
                    cmd.CommandText += ";";

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var incuranceModel = new InsuranceModel();
                            incuranceModel.IncuranceId = (int)reader[0];
                            incuranceModel.IncuranceName = reader[1].ToString();
                            incuranceModel.Price = (decimal)reader[2];
                            incuranceList.Add(incuranceModel);
                        }
                    }
                }
            }

            return incuranceList;
        }

        public override void Save()
        {
            throw new System.NotImplementedException();
        }

        public override void Update(InsuranceModel item)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var cmd = connection.CreateCommand())
                {
                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandText = "UPDATE insurances SET insurance_name=@insurance_name, price=@price WHERE insurance_id=@id";
                    cmd.Parameters.Add("@insurance_name", SqlDbType.NVarChar).Value = item.IncuranceName;
                    cmd.Parameters.Add("@price", SqlDbType.Money).Value = item.Price;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = item.IncuranceId;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<InsuranceModel> GetUserInsurances(string username)
        {
            var incuranceList = new List<InsuranceModel>();
            using (var connection = new SqlConnection(connectionString))
            {
                using (var cmd = connection.CreateCommand())
                {
                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandText = "SELECT * FROM insurances as ins " +
                        "INNER JOIN users_insurances as ui " +
                            "ON ins.insurance_id = ui.insurance_id " +
                        "INNER JOIN users as u " +
                            " ON ui.username = u.username WHERE u.username = @username;";

                    cmd.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var incuranceModel = new InsuranceModel();
                            incuranceModel.IncuranceId = (int)reader[0];
                            incuranceModel.IncuranceName = reader[1].ToString();
                            incuranceModel.Price = (decimal)reader[2];
                            incuranceList.Add(incuranceModel);
                        }
                    }
                }
            }

            return incuranceList;
        }
    }
}
