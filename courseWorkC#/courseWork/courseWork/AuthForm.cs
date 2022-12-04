using CourseWorkDB.Repositories;
using CourseWorkDB.Utilities;

namespace courseWork
{
    public partial class AuthForm : Form
    {
        public AuthForm()
        {
            InitializeComponent();
            errorLabel.Text = string.Empty;
            loginTextBox.TextChanged += CheckOnWrongFields;
            passwordTextBox.TextChanged += CheckOnWrongFields;
            CheckOnWrongFields(null, null);
            
        }  

        private void LoginButton_Click(object sender, EventArgs e)
        {
            var rep = new UserRepository();
            var user = rep.GetByCredentials(loginTextBox.Text, PasswordHashService.GetHash(passwordTextBox.Text));
            if (user != null)
            {
                if (user.RoleId != 1)
                {
                    var mainForm = new MainForm(user);
                    mainForm.Show();
                    Close();
                }
                else
                {
                    var adminForm = new AdminForm();
                    adminForm.Show();
                    Close();
                }
            }
            else
            {
                errorLabel.Text = "Неверное имя пользователя или пароль";                
            }
        }

        private void newAccountButton_Click(object sender, EventArgs e)
        {
            var registerForm = new RegisterForm();
            registerForm.Show();
            this.Close();
        }

        private void loginTextBox_TextChanged(object sender, EventArgs e)
        {
            errorLabel.Text = string.Empty;
        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {
            errorLabel.Text = string.Empty;
        }

        private void CheckOnWrongFields(object? sender, EventArgs? e)
        {
            if (loginTextBox.Text.Length == 0 || passwordTextBox.Text.Length == 0)
            {
                loginButton.Enabled = false;
            }
            else
            {
                loginButton.Enabled = true;
            }
        }

    }
}