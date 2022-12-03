using System.ComponentModel;

namespace CourseWorkDB.Models
{
    public class InsuranceModel
    {
        [Browsable(false)]
        public int IncuranceId { get; set; }

        [DisplayName("Наименование")]
        public string IncuranceName { get; set; }

        [DisplayName("Цена")]
        public decimal Price{ get; set; }
     
        public InsuranceModel(string incuranceName, decimal price)
        {
            IncuranceName = incuranceName;
            Price = price;
        }

        public InsuranceModel(int id, string incuranceName, decimal price)
        {
            IncuranceId = id;
            IncuranceName = incuranceName;
            Price = price;
        }

        public InsuranceModel()
        {
        }
    }
}
