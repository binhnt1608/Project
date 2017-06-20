﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AccountantSystemv5.Models
{
    public class CashAccount
    {
        [Key]
        [Display(Name = "Cash Account #")]
        public int CashAccountID { get; set; }

        [Display(Name = "Description")]
        [StringLength(255, ErrorMessage = "Description cannot be longer than 255 characters.")]
        public string AccountDescription { get; set; }

        [Required]
        [Display(Name = "Bank Name")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Bank's name cannot be longer than 50 and at least 1 characters.")]
        public string BankName { get; set; }

        [Required]
        [Display(Name = "Date Established")]
        [DataType(DataType.Date, ErrorMessage = "Date Time is invalid")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CashAccountDate { get; set; }

        //1-m cashdisbursement cashreceipt
        public virtual ICollection<CashDisbursement> CashDisbursement { get; set; }
        public virtual ICollection<CashReceipt> CashReceipt { get; set; }
    }
}
