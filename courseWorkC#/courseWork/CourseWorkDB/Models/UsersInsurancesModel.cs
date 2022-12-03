namespace CourseWorkDB.Models
{
    public class UsersInsurancesModel
    {
        public int InsuranceId { get; set; }

        public string Username { get; set; }

        public UsersInsurancesModel() { }

        public UsersInsurancesModel(int insuranceId, string username) 
        {
            InsuranceId = insuranceId;
            Username = username;
        }
    }
}
