using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AccountantSystemv5.Models
{
    public class Employee
    {
        //public Employee()
        //{
        //}
        [Key]
        [Display(Name = "Employee #")]
        public int EmployeeID { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Lastname cannot be longer than 50 and at least 1 characters.")]
        public string EmployeeLastName { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Firstname cannot be longer than 50 and at least 1 characters.")]
        public string EmployeeFirstName { get; set; }

        [Required]
        [Display(Name = "MI")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "MI cannot be longer than 50 and at least 1 characters.")]
        public string MI { get; set; }

        //SSN = socail security number
        [Required]
        [Display(Name = "SSN")]
        [StringLength(11, MinimumLength = 1, ErrorMessage = "SSN cannot be longer than 11 and at least 1 characters.")]
        public string EmployeeSSN { get; set; }

        [Required]
        [Display(Name = "Address")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Address cannot be longer than 50 and at least 1 characters.")]
        public string EmAddress1 { get; set; }


        [Display(Name = "Address")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Address cannot be longer than 50 and at least 1 characters.")]
        public string EmAddress2 { get; set; }
            
        [Required]
        [Display(Name = "City")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "City cannot be longer than 50 and at least 1 characters.")]
        public string EmCity { get; set; }

        [Required]
        [Display(Name = "State")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "State cannot be longer than 50 and at least 1 characters.")]
        public string EmState { get; set; }

        [Required]
        [Display(Name = "Zip Code")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Zipcode cannot be longer than 50 and at least 1 characters.")]
        public string EmZipcode { get; set; }

        [Required]
        [Display(Name = "Phone")]
        [StringLength(20, MinimumLength = 10, ErrorMessage = "Phone cannot be longer than 20 and at least 10 characters.")]
        public string EmTelephone { get; set; }

        [Required]
        [Display(Name = "Marital Status")]
        public int MaritalStatusID { get; set; }

        [Required]
        [Display(Name = "Exemption")]
        public int ExemptionNum { get; set; }

        [Required]
        [Display(Name = "Pay Rate")]
        [DisplayFormat(DataFormatString = "{0:$#.##}")]
        public decimal EmPayRate { get; set; }

        [Display(Name = "Type")]
        public int EmployeeTypeID { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        [DataType(DataType.Date, ErrorMessage = "Date Time is invalid")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EmStartDate { get; set; }

        //m-1 employeetype exemption
        public virtual EmployeeType EmployeeType { get; set; }
        public virtual Exemptions Exemptions { get; set; }

        //1-m purchase purchaseorder laboracquisition cashdisbursement LoanAgreement cashreceipt StockSubscription sale saleoder 
        //public virtual ICollection<Purchase> Purchase { get; set; }
        public virtual ICollection<PurchaseOrder> PurchaseOrder { get; set; }
        public virtual ICollection<LaborAcquisition> LaborAcquisition { get; set; }
        //public virtual ICollection<CashDisbursement> CashDisbursement { get; set; }
        public virtual ICollection<LoanAgreement> LoanAgreemnet { get; set; }
        //public virtual ICollection<CashReceipt> CashReceipt { get; set; }
        public virtual ICollection<StockSubscription> StockSubscription { get; set; }
        //public virtual ICollection<Sale> Sale { get; set; }
        public virtual ICollection<SaleOrder> SaleOrder { get; set; }

        //1-1 withholding
        public virtual Withholding Withholding { get; set; } 
        
        // 1-m Inflow E-W
        //public ICollection<InflowEmployeeWithholding> InflowEmployeeWithholdings { get; set; }

        //Dat 
        //Employee vs WorkSchedule
        //public List<ExternalPartWSE> ExternalPartWSEs { get; set; }
    }
}
