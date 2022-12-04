using System.ComponentModel;

namespace CourseWorkDB.Models
{
    public class UserModel
    {
        [DisplayName("Логин")]
        public string UserName { get; set; }

        [DisplayName("Пароль")]
        public string Password { get; set; }

        [Browsable(false)]
        public int RoleId { get; set; }

        [DisplayName("Роль")]
        public string RoleName { get; set; }



        public UserModel()
        {
        }

        public UserModel(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

    }
}
