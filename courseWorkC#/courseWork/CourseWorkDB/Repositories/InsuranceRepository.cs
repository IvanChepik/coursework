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

        public void Create(InsuranceModel item)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var cmd = connection.CreateCommand())
                {
                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandText = "INSERT INTO insurances VALUES (@insurance_name, @price, @insurance_type_id);";
                    cmd.Parameters.Add("@insurance_name", SqlDbType.NVarChar).Value = item.IncuranceName;
                    cmd.Parameters.Add("@price", SqlDbType.Money).Value = item.Price;
                    cmd.Parameters.Add("@insurance_type_id", SqlDbType.Int).Value = item.InsuranceTypeId;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
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

        public IEnumerable<InsuranceModel> GetList(SortModel sort = null)
        {
            var incuranceList = new List<InsuranceModel>();
            using (var connection = new SqlConnection(connectionString))
            {
                using (var cmd = connection.CreateCommand())
                {
                    Console.WriteLine(sort?.Field);
                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandText = "SELECT " +
                                $"i.insurance_id, " +
                                "i.insurance_name, " +
                                "i.price, " +
                                "it.insurance_type_id, " +
                                "it.insurance_type_name " +
                                $"FROM {sort.Field}_{sort.Order} as i " +
                                "INNER JOIN insurance_types as it " +
                                    "ON it.insurance_type_id = i.insurance_type_id " +
                                "GROUP BY i.insurance_id, i.insurance_name, i.price, it.insurance_type_id, it.insurance_type_name;";

                    

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var incuranceModel = new InsuranceModel();
                            incuranceModel.IncuranceId = (int)reader[0];
                            incuranceModel.IncuranceName = reader[1].ToString();
                            incuranceModel.Price = (decimal)reader[2];
                            incuranceModel.InsuranceTypeId = (int)reader[3];
                            incuranceModel.InsuranceTypeName = reader[4].ToString();
                            incuranceList.Add(incuranceModel);
                        }
                    }
                }
            }

            return incuranceList;
        }
      
        public void Update(InsuranceModel item)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var cmd = connection.CreateCommand())
                {
                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandText = "UPDATE insurances SET insurance_name=@insurance_name, price=@price, insurance_type_id=@insurance_type_id WHERE insurance_id=@id";
                    cmd.Parameters.Add("@insurance_name", SqlDbType.NVarChar).Value = item.IncuranceName;
                    cmd.Parameters.Add("@price", SqlDbType.Money).Value = item.Price;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = item.IncuranceId;
                    cmd.Parameters.Add("insurance_type_id", SqlDbType.Int).Value = item.InsuranceTypeId;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<UserInsuranceModel> GetUserInsurances(string username, SortModel sort = null)
        {
            var incuranceList = new List<UserInsuranceModel>();
            using (var connection = new SqlConnection(connectionString))
            {
                using (var cmd = connection.CreateCommand())
                {
                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandText = "SELECT ins.insurance_id, ins.insurance_name, ui.buy_date, it.insurance_type_name " +
                        "FROM insurances as ins " +
                        "INNER JOIN insurance_types as it " +
                            "ON it.insurance_type_id = ins.insurance_type_id " +
                        "INNER JOIN users_insurances as ui " +
                            "ON ins.insurance_id = ui.insurance_id " +
                        "INNER JOIN users as u " +
                            "ON ui.username = u.username WHERE u.username = @username " +                       
                        "GROUP BY ins.insurance_id, ins.insurance_name, ui.buy_date, it.insurance_type_name " +
                        $"ORDER BY {sort.Field} {sort.Order};";

                    cmd.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            
                            var incuranceModel = new UserInsuranceModel();
                            incuranceModel.InsuranceId = (int)reader[0];
                            incuranceModel.Name = reader[1].ToString();
                            incuranceModel.DateBuy = (DateTime)reader[2]; ;
                            incuranceModel.InsuranceTypeName = reader[3].ToString(); ;
                            incuranceList.Add(incuranceModel);
                        }
                    }
                }
            }

            return incuranceList;
        }
    }
}
