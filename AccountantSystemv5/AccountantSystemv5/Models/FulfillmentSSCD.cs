using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AccountantSystemv5.Models
{
    public class FulfillmentSSCD
    {
        [Key]
        [Display(Name = "Dividend #")]
        public int DividendID { get; set; }

        [Required]
        [Display(Name = "Stock Issue #")]
        public int StockID { get; set; }

        [Required]
        [Display(Name = "Date Declared")]
        [DataType(DataType.Date, ErrorMessage = "Date Time is invalid")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DividendDeclarationDate { get; set; }

        [Display(Name = "Did. Per Share")]
        [DisplayFormat(DataFormatString = "{0:$#.##}")]
        public decimal DividendPerShare { get; set; }

        //m-1 StockSubscription
        public virtual StockSubscription StockSubscription { get; set; }

        //1-1 CashDisbursement
        public virtual ICollection<CashDisbursement> CashDisbursement { get; set; }
    }
}
