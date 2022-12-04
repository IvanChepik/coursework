using CourseWorkDB.Models;
using CourseWorkDB.Repositories;
using CourseWorkDB.Utilities;

namespace courseWork
{
    public partial class MainForm : Form
    {
        private UserModel _currentUser;
        private SortModel _currentInsurancesSort;
        private SortModel _currentUsersInsurancesSort;

        public MainForm(UserModel currentUser, bool isAdminOpen = false)
        {
            InitializeComponent();
            _currentInsurancesSort = new SortModel("insurance_name", "ASC");
            _currentUsersInsurancesSort = new SortModel("insurance_name", "ASC");
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
            var choosenInsurance = (InsuranceModel)insurancesDataGridView.CurrentRow.DataBoundItem;
            var rep = new UsersInsurancesRepository();
            var isUserHas = ((List<UserInsuranceModel>)userInsurancesDataGridView.DataSource).Any(x => x.InsuranceId == choosenInsurance.IncuranceId);

            if (isUserHas)
            {
                MessageBox.Show("Пользователь уже имеет эту страховку","Ошибка");
            }
            else
            {
                rep.Create(new UsersInsurancesModel(choosenInsurance.IncuranceId, _currentUser.UserName));
                LoadUserInsurances();
            }

        }

        private void LoadUserInsurances()
        {
            var rep = new InsuranceRepository();
            var result =  rep.GetUserInsurances(_currentUser.UserName, _currentUsersInsurancesSort);
            deleteUserInsuranceButton.Enabled = result.Count() > 0;
            userInsurancesDataGridView.DataSource = result;
        }

        private void LoadInsurances()
        {
            var rep = new InsuranceRepository();
            var result = rep.GetList(_currentInsurancesSort);
            
            insurancesDataGridView.DataSource = result;
        }

        private void deleteUserInsuranceButton_Click(object sender, EventArgs e)
        {   
            var rep = new UsersInsurancesRepository();
            var choosenInsurance = (InsuranceModel)insurancesDataGridView.CurrentRow.DataBoundItem;
            rep.Delete(choosenInsurance.IncuranceId, _currentUser.UserName);
            LoadUserInsurances();
        }

        private void outlogButton_Click(object sender, EventArgs e)
        {
            var form = new AuthForm();
            form.Show();
            Close();
        }

        private void insurancesDataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 0:
                    _currentInsurancesSort = SortService.GetNewSort(_currentInsurancesSort, "insurance_name");
                    break;
                case 1:
                    _currentInsurancesSort = SortService.GetNewSort(_currentInsurancesSort, "price");
                    break;
                case 2:
                    _currentInsurancesSort = SortService.GetNewSort(_currentInsurancesSort, "type");
                    break;
            }
            LoadInsurances();
        }

        private void userInsurancesDataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Console.WriteLine(e.ColumnIndex);
            switch (e.ColumnIndex)
            {
                case 0:
                    _currentUsersInsurancesSort = SortService.GetNewSort(_currentUsersInsurancesSort, "ins.insurance_name");
                    break;
                case 1:
                    _currentUsersInsurancesSort = SortService.GetNewSort(_currentUsersInsurancesSort, "ui.buy_date");
                    break;  
                case 2:
                    _currentUsersInsurancesSort = SortService.GetNewSort(_currentUsersInsurancesSort, "it.insurance_type_name");
                    break;
            }
            LoadUserInsurances();
        }
    }
}
