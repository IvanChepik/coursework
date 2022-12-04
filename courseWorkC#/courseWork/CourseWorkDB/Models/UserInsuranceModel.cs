using System;
using System.ComponentModel;

namespace CourseWorkDB.Models
{
    public class UserInsuranceModel
    {
        [Browsable(false)]
        public int InsuranceId { get; set; }

        [DisplayName("Наименование")]
        public string Name { get; set; }

        [DisplayName("Дата покупки")]
        public DateTime DateBuy { get; set; }

        [DisplayName("Тип страховки")]
        public string InsuranceTypeName { get; set; }

    }
}
