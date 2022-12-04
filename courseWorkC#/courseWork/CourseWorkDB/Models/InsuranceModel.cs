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

        [Browsable(false)]
        public int InsuranceTypeId { get; set;  }

        [DisplayName("Тип страховки")]
        public string InsuranceTypeName { get; set; }
     
        public InsuranceModel(string incuranceName, decimal price, int insuranceTypeId)
        {
            IncuranceName = incuranceName;
            Price = price;
            InsuranceTypeId = insuranceTypeId;    
        }

        public InsuranceModel(int id, string incuranceName, int insuranceTypeId, decimal price)
        {
            IncuranceId = id;
            IncuranceName = incuranceName;
            Price = price;
            InsuranceTypeId = insuranceTypeId;
        }

        public InsuranceModel()
        {
        }
    }
}
