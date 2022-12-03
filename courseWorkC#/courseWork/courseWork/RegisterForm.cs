﻿using CourseWorkDB.Models;
using CourseWorkDB.Repositories;

namespace courseWork
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
            errorLabel.Text = string.Empty;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            var authForm = new AuthForm();
            authForm.Show();
            Close();
        }

        private void registrationButton_Click(object sender, EventArgs e)
        {
            var rep = new UserRepository();
            var existedUser = rep.GetByLogin(loginTextBox.Text);
            if (existedUser != null)
            {
                errorLabel.Text = "Пользователь под таким именем уже существует";
            }
            else
            {
                rep.Create(new UserModel(loginTextBox.Text, passwordTextBox.Text));
                var authForm = new AuthForm();
                authForm.Show();
                Close();
            }
        }

        private void loginTextBox_TextChanged(object sender, EventArgs e)
        {
            errorLabel.Text = string.Empty;
        }
    }
}
