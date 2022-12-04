using CourseWorkDB.Models;
using CourseWorkDB.Utilities;
using System.Collections.Generic;
using System;
using Microsoft.Data.SqlClient;

namespace CourseWorkDB.Repositories
{
    public class InsuranceTypesRepository: BaseRepository<InsuranceType>
    {

        public IEnumerable<InsuranceType> GetList(SortModel sort = null)
        {
            var incuranceList = new List<InsuranceType>();
            using (var connection = new SqlConnection(connectionString))
            {
                using (var cmd = connection.CreateCommand())
                {
                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandText = "SELECT * FROM insurance_types";

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                           
                            var incuranceModel = new InsuranceType();
                            incuranceModel.Id = (int)reader[0];
                            incuranceModel.Name = reader[1].ToString();
                            incuranceList.Add(incuranceModel);
                        }
                    }
                }
            }

            return incuranceList;
        }
    }
}
