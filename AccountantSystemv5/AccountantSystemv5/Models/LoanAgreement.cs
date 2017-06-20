﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AccountantSystemv5.Models
{
    public class LoanAgreement
    {
        [Key]
        [Display(Name = "Loan #")]
        public int LoanID { get; set; }

        [Required]
        [Display(Name = "Financier #")]
        public int FinancierID { get; set; }

        [Required]
        [Display(Name = "Employee #")]
        public int EmployeeID { get; set; }

        [Required]
        [Display(Name = "Loan Amount")]
        [DisplayFormat(DataFormatString = "{0:$#.##}")]
        public decimal LoanAmount { get; set; }

        [Required]
        [Display(Name = "Interest Rate")]
        [DisplayFormat(DataFormatString = "{0:#.####%}")]
        public decimal InterestRate { get; set; }

        [Required]
        [Display(Name = "Loan Date")]
        [DataType(DataType.Date, ErrorMessage = "Date Time is invalid")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime LoanDate { get; set; }

        [Required]
        [Display(Name = "Maturity Date")]
        [DataType(DataType.Date, ErrorMessage = "Date Time is invalid")]
        [DisplayFormat(DataFormatString = "{dd-MM-yyyy:0}", ApplyFormatInEditMode = true)]
        public DateTime MaturityDate { get; set; }

        [Required]
        [Display(Name = "Pmts Per Year")]
        [DisplayFormat(DataFormatString = "{0:0}")]
        public int PaymentsPerYear { get; set; }

        //m-1 Employee StockHolderCreditor
        public virtual Employee Employee { get; set; }
        public virtual StockHolderCreditor StockHolderCreditor { get; set; }

        //1-m FulfillmentLACD
        public virtual ICollection<FulfillmentLACD> FulfillmentLACD { get; set; }

        //1-1 
        public virtual ICollection<CashReceipt> CashReceipt { get; set; }
    }
}
