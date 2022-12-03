using CourseWorkDB.Models;
using CourseWorkDB.Repositories;

namespace courseWork
{
    public partial class InsuranceAddForm : Form
    {

        InsuranceModel? editedInsurance {get; set;}

        public InsuranceAddForm(InsuranceModel? insurance = null)
        {
            InitializeComponent();
            editedInsurance = insurance;  
            Text = insurance == null ? "Создание страховки" : "Редактирование страховки";
            addButton.Text = insurance == null ? "Создать" : "Редактировать";
            if (insurance != null)
            {
                nameTextBox.Text = editedInsurance?.IncuranceName;
                priceTextBox.Text = editedInsurance?.Price.ToString();
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            var rep = new InsuranceRepository();
            if (editedInsurance != null)
            {
                rep.Update(new InsuranceModel(editedInsurance.IncuranceId, nameTextBox.Text, Decimal.Parse(priceTextBox.Text)));
            }
            else
            {
                rep.Create(new InsuranceModel(nameTextBox.Text, Convert.ToDecimal(priceTextBox.Text)));
            }
        }

        private void priceTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
