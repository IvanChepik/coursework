using CourseWorkDB.Models;
using CourseWorkDB.Repositories;

namespace courseWork
{
    public partial class MainForm : Form
    {
        private UserModel _currentUser;

        public MainForm(UserModel currentUser, bool isAdminOpen = false)
        {
            InitializeComponent();
            _currentUser = currentUser;
            userNameLabel.Text = _currentUser.UserName;
            insuranceBuyButton.Text = isAdminOpen ? "Добавить" : "Купить";
            outlogButton.Visible = !isAdminOpen;
            LoadInsurances(); 
            LoadUserInsurances();

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void insuranceBuyButton_Click(object sender, EventArgs e)
        {
            var rep = new UsersInsurancesRepository();
            var choosenInsurance = (InsuranceModel)insurancesDataGridView.CurrentRow.DataBoundItem;
            rep.Create(new UsersInsurancesModel(choosenInsurance.IncuranceId, _currentUser.UserName));
            LoadUserInsurances();
        }

        private void LoadUserInsurances()
        {
            var rep = new InsuranceRepository();
            userInsurancesDataGridView.DataSource = rep.GetUserInsurances(_currentUser.UserName);
        }

        private void LoadInsurances()
        {
            var rep = new InsuranceRepository();
            insurancesDataGridView.DataSource = rep.GetList();
        }

        private void deleteUserInsuranceButton_Click(object sender, EventArgs e)
        {   
            var rep = new UsersInsurancesRepository();
            var choosenInsurance = (InsuranceModel)insurancesDataGridView.CurrentRow.DataBoundItem;
            Console.WriteLine(choosenInsurance.IncuranceName);
            rep.Delete(choosenInsurance.IncuranceId, _currentUser.UserName);
            LoadUserInsurances();
        }

        private void outlogButton_Click(object sender, EventArgs e)
        {
            var form = new AuthForm();
            form.Show();
            Close();
        }
    }
}
