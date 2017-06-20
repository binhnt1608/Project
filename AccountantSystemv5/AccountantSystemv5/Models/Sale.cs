using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AccountantSystemv5.Models
{
    public class Sale
    {
        [Key]
        [Display(Name = "Invoce #")]
        public int InvoiceID { get; set; }

        [Required]
        [Display(Name = "Date")]
        [DataType(DataType.Date, ErrorMessage = "Date Time is invalid")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ShippingDate { get; set; }

        [Display(Name = "Customer #")]
        public int CustomerID { get; set; }

        [Display(Name = "Sale Order #")]
        public int SaleOrderID { get; set; }

        [Display(Name = "Materials Handler #")]
        public int EmployeeID { get; set; }

        [Required]
        [Display(Name = "Sale Amount")]
        [DisplayFormat(DataFormatString = "{0:$#.##}")]
        public int SaleAmount { get; set; }

        //m-1 saleorder customer employee
        public virtual SaleOrder SaleOrder { get; set; }
        //public virtual Customer Customer { get; set; }
        //public virtual Employee Employee { get; set; }

        //1-1 cashreceipt 
        public virtual CashReceipt CashReceipt { get; set; }
        

        //Dat
        // Inventory vs Sale
        public virtual List<OutflowSaleInventory> OutflowSaleInventories { get; set; }
    }
}
