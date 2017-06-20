﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AccountantSystemv5.Models
{
    public class Customer
    {
        [Key]
        [Display(Name = "Customer #")]
        public int CustomerID { get; set; }

        [Required]
        [Display(Name = "Name")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Customer's name cannot be longer than 50 and at least 1 characters.")]
        public string CustomerName { get; set; }

        [Required]
        [Display(Name = "Address 1")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Address cannot be longer than 50 and at least 1 characters.")]
        public string CustomerAddress1 { get; set; }

        [Display(Name = "Address 2")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Address cannot be longer than 50 and at least 1 characters.")]
        public string CustomerAddress2 { get; set; }

        [Required]
        [Display(Name = "City")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = " City cannot be longer than 50 and at least 1 characters.")]
        public string CustomerCity { get; set; }

        [Required]
        [Display(Name = "State")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "State cannot be longer than 50 and at least 1 characters.")]
        public string CustomerState { get; set; }

        [Required]
        [Display(Name = "Zipcode")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Zipcode cannot be longer than 50 and at least 1 characters.")]
        public string CustomerZipcode { get; set; }

        [Required]
        [Display(Name = "Phone #")]
        [StringLength(20, MinimumLength = 10, ErrorMessage = "Phone cannot be longer than 20 and at least 10 characters.")]
        public string CustomerTelephone { get; set; }

        [Range(0, 50000)]
        [Display(Name = "Credit Limit")]
        [DisplayFormat(DataFormatString = "{0:$#.##}")]
        public decimal CustomerCreditLimit { get; set; }

        [Display(Name = "Primary Contact")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Contact cannot be longer than 50 and at least 1 characters.")]
        public string CustomerPrimaryContact { get; set; }

        //1-m cashreceipt sale saleorder
        //public virtual ICollection<CashReceipt> CashReceipt { get; set; }
        //public virtual ICollection<Sale> Sale { get; set; }
        public virtual ICollection<SaleOrder> SaleOrder { get; set; }
    }
}
