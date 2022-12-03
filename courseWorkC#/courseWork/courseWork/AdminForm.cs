using CourseWorkDB.Models;
using CourseWorkDB.Repositories;
using CourseWorkDB.Utilities;

namespace courseWork
{
    public partial class AdminForm : Form
    {
        private SortModel _currentInsurancesSort;
        private SortModel _currentUsersSort;
        public AdminForm()
        {
            InitializeComponent();
            _currentInsurancesSort = new SortModel("insurance_name", "ASC");
            _currentUsersSort = new SortModel("username", "ASC");
            LoadInsurances();
            LoadUsers();
            usersDataGridView.ColumnHeadersDefaultCellStyle.SelectionBackColor = usersDataGridView.ColumnHeadersDefaultCellStyle.BackColor;
        }

        public void LoadInsurances()
        {
            var rep = new InsuranceRepository();
            insurancesDataGridView.DataSource = rep.GetList(_currentInsurancesSort);
        }

        private void LoadUsers()
        {
            var rep = new UserRepository();
            usersDataGridView.DataSource = rep.GetList(_currentUsersSort);
        }

        private void insuranceAddButton_Click(object sender, EventArgs e)
        {
            var form = new InsuranceAddForm();

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                LoadInsurances();
            }
        }

        private void insuranceEditButton_Click(object sender, EventArgs e)
        {
            var form = new InsuranceAddForm((InsuranceModel)insurancesDataGridView.CurrentRow.DataBoundItem);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                LoadInsurances();
            }
        }

        private void usersDataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {   
            if (e.RowIndex != -1)
            {
                var form = new MainForm((UserModel)usersDataGridView.CurrentRow.DataBoundItem, true);
                form.FormClosed += DialogClosed;
                form.ShowDialog();
            }
        }

        private void DialogClosed(Object? sender, FormClosedEventArgs? e)
        {
            LoadUsers();
        }

        private void outlogButton_Click(object sender, EventArgs e)
        {
            var form = new AuthForm();
            form.Show();
            Close();
        }

        private void deleteInsuranceButton_Click(object sender, EventArgs e)
        {
            var choosenIns = (InsuranceModel)insurancesDataGridView.CurrentRow.DataBoundItem;
            var rep = new InsuranceRepository();
            rep.Delete(choosenIns.IncuranceId);
            LoadInsurances();
            LoadUsers();
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
            }
            LoadInsurances();
        }
    }
}
