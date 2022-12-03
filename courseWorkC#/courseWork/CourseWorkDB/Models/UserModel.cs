using System;
using System.ComponentModel;

namespace CourseWorkDB.Models
{
    public class UserModel
    {
        [DisplayName("Имя")]
        public string UserName { get; set; }

        [DisplayName("Пароль")]
        public string Password { get; set; }

        [Browsable(false)]
        public bool IsAdmin { get; set; }

        [DisplayName("Количество страховок")]
        public int InsuranceCount { get; set; }

        public UserModel()
        {
        }

        public UserModel(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        public UserModel(string userName, string password, int insuranceCount)
        {
            UserName = userName;
            Password = password;
            InsuranceCount = insuranceCount;
        }
    }
}
