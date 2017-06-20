using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AccountantSystemv5.Models
{
    public class Salary
    {
        public Employee Employee { get; set; }
        public LaborAcquisition LaborAcquisition { get; set; }
        //public int EmployeeID { get; set; }
        //public int TimeCardID { get; set; }
        //public DateTime LAPayPeriodEnded { get; set; }
        //public decimal EmPayRate { get; set; }
        //public int LARegularTime { get; set; }
        //public int LAOvertime { get; set; }
        [Display(Name = "Regular Pay")]
        [DisplayFormat(DataFormatString = "{0:$#.##}")]
        public decimal RegularPay { get; set; }

        [Display(Name = "Over Time Pay")]
        [DisplayFormat(DataFormatString = "{0:$#.##}")]
        public decimal OverTimePay { get; set; }

        [Display(Name = "Gross Pay")]
        [DisplayFormat(DataFormatString = "{0:$#.##}")]
        public decimal GrossPay { get; set; }

        [Display(Name = "Gross Less Exemption")]
        [DisplayFormat(DataFormatString = "{0:$#.##}")]
        public decimal GrossLessExemption { get; set; }

        [Display(Name = "FWT")]
        [DisplayFormat(DataFormatString = "{0:$#.##}")]
        public decimal FWT { get; set; }

        [Display(Name = "FWT")]
        [DisplayFormat(DataFormatString = "{0:$#.##}")]
        public decimal FICA { get; set; }

        [Display(Name = "Medicare")]
        [DisplayFormat(DataFormatString = "{0:$#.##}")]
        public decimal Medicare { get; set; }

        [Display(Name = "Net Pay")]
        [DisplayFormat(DataFormatString = "{0:$#.##}")]
        public decimal NetPay { get; set; }
    }
}
