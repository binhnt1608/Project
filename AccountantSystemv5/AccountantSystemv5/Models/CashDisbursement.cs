﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AccountantSystemv5.Models
{
    public class CashDisbursement
    {
        [Key]
        [Display(Name = "Check Number #")]
        public int CheckNumber { get; set; }

        [Display(Name = "Cash Account #")]
        public int CashAccountID { get; set; }

        [Display(Name = "CD Type #")]
        public int CDTypeID { get; set; }

        //VendorID
        /*[Display(Name = "Payee #")]
        public int PayeeID { get; set; }*/
        [Display(Name = "Payee #")]
        public int VendorID { get; set; }

        [Display(Name = "Employee #")]
        public int EmployeeID { get; set; }

        ////Labor Acquisition
        //[Display(Name = "Time Card #")]
        //public int TimeCardID { get; set; }

        //InventoryREceiptID
        [Display(Name = "Event #")]
        public int InventoryReceiptID { get; set; }
       
        //cashdisbursement amount
        [Display(Name = "Amount Paid")]
        [DisplayFormat(DataFormatString = "{0:$#.##}")]
        public decimal CashDisbursementAmount { get; set; }

        [Required]
        [Display(Name = "Date")]
        [DataType(DataType.Date, ErrorMessage = "Date Time is invalid")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CashDisbursementDate { get; set; }

        // m-1  cashaccount employee vendor
        
        public virtual CashAccount CashAccount { get; set; }
        //public virtual Employee Employee { get; set; }
       // public virtual Vendor Vendor { get; set; }
        public virtual CashDisbursementType CashDisbursementType { get; set; }
        //public virtual LaborAcquisition LaborAcquisition { get; set; }

        //1-1 purchase employee_1 FulfillmentLACD FulfillmentSSCD 
        // public Employee_1 Employee_1 { get; set; }
        public virtual Purchase Purchase { get; set; }
        public virtual FulfillmentLACD FulfillmentLACD { get; set; }
        public virtual FulfillmentSSCD FulfillmentSSCD { get; set; }
    }
}
