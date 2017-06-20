using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using AccountantSystemv5.Models;

namespace AccountantSystemv5.Migrations
{
    [DbContext(typeof(AccountantSystemv5Context))]
    partial class AccountantSystemv5ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AccountantSystemv5.Models.CashAccount", b =>
                {
                    b.Property<int>("CashAccountID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccountDescription")
                        .HasMaxLength(255);

                    b.Property<string>("BankName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("CashAccountDate");

                    b.HasKey("CashAccountID");

                    b.ToTable("CashAccount");
                });

            modelBuilder.Entity("AccountantSystemv5.Models.CashDisbursement", b =>
                {
                    b.Property<int>("CheckNumber")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CDTypeID");

                    b.Property<int>("CashAccountID");

                    b.Property<decimal>("CashDisbursementAmount");

                    b.Property<DateTime>("CashDisbursementDate");

                    b.Property<int>("EmployeeID");

                    b.Property<int?>("FulfillmentLACDLoanPaymentID");

                    b.Property<int?>("FulfillmentSSCDDividendID");

                    b.Property<int>("InventoryReceiptID");

                    b.Property<int>("VendorID");

                    b.HasKey("CheckNumber");

                    b.HasIndex("CDTypeID");

                    b.HasIndex("CashAccountID");

                    b.HasIndex("FulfillmentLACDLoanPaymentID");

                    b.HasIndex("FulfillmentSSCDDividendID");

                    b.HasIndex("InventoryReceiptID");

                    b.ToTable("CashDisbursement");
                });

            modelBuilder.Entity("AccountantSystemv5.Models.CashDisbursementType", b =>
                {
                    b.Property<int>("CDTypeID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EventTypeName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("PayeeTypeName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("CDTypeID");

                    b.ToTable("CashDisbursementType");
                });

            modelBuilder.Entity("AccountantSystemv5.Models.CashReceipt", b =>
                {
                    b.Property<int>("RemittanceAdviceID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CRTypeID");

                    b.Property<int>("CashAccountID");

                    b.Property<DateTime>("CashReceiptDate");

                    b.Property<decimal>("CasheReceiptAmount");

                    b.Property<int>("CustomerID");

                    b.Property<int>("EmployeeID");

                    b.Property<int>("InvoiceID");

                    b.Property<int?>("LoanAgreementLoanID");

                    b.Property<int>("PayorCheckNum");

                    b.Property<int?>("StockSubscriptionStockID");

                    b.HasKey("RemittanceAdviceID");

                    b.HasIndex("CRTypeID");

                    b.HasIndex("CashAccountID");

                    b.HasIndex("InvoiceID")
                        .IsUnique();

                    b.HasIndex("LoanAgreementLoanID");

                    b.HasIndex("StockSubscriptionStockID");

                    b.ToTable("CashReceipt");
                });

            modelBuilder.Entity("AccountantSystemv5.Models.CashReceiptType", b =>
                {
                    b.Property<int>("CRTypeID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EventTypeName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("PayeeTypeName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("CRTypeID");

                    b.ToTable("CashReceiptType");
                });

            modelBuilder.Entity("AccountantSystemv5.Models.Customer", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CustomerAddress1")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("CustomerAddress2")
                        .HasMaxLength(50);

                    b.Property<string>("CustomerCity")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<decimal>("CustomerCreditLimit");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("CustomerPrimaryContact")
                        .HasMaxLength(50);

                    b.Property<string>("CustomerState")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("CustomerTelephone")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("CustomerZipcode")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("CustomerID");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("AccountantSystemv5.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EmAddress1")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("EmAddress2")
                        .HasMaxLength(50);

                    b.Property<string>("EmCity")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<decimal>("EmPayRate");

                    b.Property<DateTime>("EmStartDate");

                    b.Property<string>("EmState")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("EmTelephone")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("EmZipcode")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("EmployeeFirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("EmployeeLastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("EmployeeSSN")
                        .IsRequired()
                        .HasMaxLength(11);

                    b.Property<int>("EmployeeTypeID");

                    b.Property<int>("ExemptionNum");

                    b.Property<string>("MI")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("MaritalStatusID");

                    b.HasKey("EmployeeID");

                    b.HasIndex("EmployeeTypeID");

                    b.HasIndex("ExemptionNum");

                    b.HasIndex("MaritalStatusID");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("AccountantSystemv5.Models.EmployeeType", b =>
                {
                    b.Property<int>("EmployeeTypeID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EmployeeTypeName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("EmployeeTypeID");

                    b.ToTable("EmployeeType");
                });

            modelBuilder.Entity("AccountantSystemv5.Models.Exemptions", b =>
                {
                    b.Property<int>("ExemptionNum")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("ExemptionAmount");

                    b.HasKey("ExemptionNum");

                    b.ToTable("Exemptions");
                });

            modelBuilder.Entity("AccountantSystemv5.Models.ExternalPartWSE", b =>
                {
                    b.Property<int>("ScheduleID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EmployeeID");

                    b.Property<int?>("ScheduleID1");

                    b.HasKey("ScheduleID");

                    b.HasIndex("EmployeeID");

                    b.HasIndex("ScheduleID1");

                    b.ToTable("ExternalPartWSE");
                });

            modelBuilder.Entity("AccountantSystemv5.Models.FulfillmentLACD", b =>
                {
                    b.Property<int>("LoanPaymentID")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("InterestAmount");

                    b.Property<int>("LoanID");

                    b.Property<DateTime>("PaymentDueDate");

                    b.Property<int>("PaymentNum");

                    b.Property<decimal>("PrincipalAmount");

                    b.HasKey("LoanPaymentID");

                    b.HasIndex("LoanID");

                    b.ToTable("FulfillmentLACD");
                });

            modelBuilder.Entity("AccountantSystemv5.Models.FulfillmentSSCD", b =>
                {
                    b.Property<int>("DividendID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DividendDeclarationDate");

                    b.Property<decimal>("DividendPerShare");

                    b.Property<int>("StockID");

                    b.HasKey("DividendID");

                    b.HasIndex("StockID");

                    b.ToTable("FulfillmentSSCD");
                });

            modelBuilder.Entity("AccountantSystemv5.Models.FulfillmentWSLA", b =>
                {
                    b.Property<int>("ScheduleID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("TimeCardID");

                    b.Property<int?>("WorkScheduleScheduleID");

                    b.HasKey("ScheduleID");

                    b.HasIndex("TimeCardID");

                    b.HasIndex("WorkScheduleScheduleID");

                    b.ToTable("FulfillmentWSLA");
                });

            modelBuilder.Entity("AccountantSystemv5.Models.InflowLALT", b =>
                {
                    b.Property<int>("TimeCardID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("LaborAcquisitionTimeCardID");

                    b.Property<int>("LaborTypeID");

                    b.HasKey("TimeCardID");

                    b.HasIndex("LaborAcquisitionTimeCardID");

                    b.HasIndex("LaborTypeID");

                    b.ToTable("InflowLALT");
                });

            modelBuilder.Entity("AccountantSystemv5.Models.InflowPurchaseInventory", b =>
                {
                    b.Property<int>("InventoryReceiptID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("InventoryID");

                    b.Property<int>("InventoryReceiptPrice");

                    b.Property<int?>("PurchaseInventoryReceiptID");

                    b.Property<int>("QuantityReceived");

                    b.HasKey("InventoryReceiptID");

                    b.HasIndex("InventoryID");

                    b.HasIndex("PurchaseInventoryReceiptID");

                    b.ToTable("InflowPurchaseInventory");
                });

            modelBuilder.Entity("AccountantSystemv5.Models.Inventory", b =>
                {
                    b.Property<int>("InventoryID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("InventoryCompositionID");

                    b.Property<int>("InventoryDiameterID");

                    b.Property<decimal>("InventoryListPrice");

                    b.Property<decimal>("InventoryStdCosst");

                    b.Property<int>("InventoryTypeID");

                    b.HasKey("InventoryID");

                    b.HasIndex("InventoryCompositionID");

                    b.HasIndex("InventoryDiameterID");

                    b.HasIndex("InventoryTypeID");

                    b.ToTable("Inventory");
                });

            modelBuilder.Entity("AccountantSystemv5.Models.InventoryComposition", b =>
                {
                    b.Property<int>("CompositionID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("InventoryCompositionCode")
                        .IsRequired();

                    b.Property<string>("InventoryCompositionDescription")
                        .HasMaxLength(50);

                    b.HasKey("CompositionID");

                    b.ToTable("InventoryComposition");
                });

            modelBuilder.Entity("AccountantSystemv5.Models.InventoryDiameter", b =>
                {
                    b.Property<int>("CompositionID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("InventoryDiameterCode");

                    b.Property<string>("InventoryDiameterDescription")
                        .HasMaxLength(50);

                    b.HasKey("CompositionID");

                    b.ToTable("InventoryDiameter");
                });

            modelBuilder.Entity("AccountantSystemv5.Models.InventoryType", b =>
                {
                    b.Property<int>("CompositionID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("InventoryTypeCode");

                    b.Property<string>("InventoryTypeDescription")
                        .HasMaxLength(50);

                    b.HasKey("CompositionID");

                    b.ToTable("InventoryType");
                });

            modelBuilder.Entity("AccountantSystemv5.Models.LaborAcquisition", b =>
                {
                    b.Property<int>("TimeCardID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EmployeeID");

                    b.Property<int>("EmployeeSupervisorID");

                    b.Property<int>("LAOvertime");

                    b.Property<DateTime>("LAPayPeriodEnded");

                    b.Property<int>("LARegularTime");

                    b.HasKey("TimeCardID");

                    b.HasIndex("EmployeeID");

                    b.ToTable("LaborAcquisition");
                });

            modelBuilder.Entity("AccountantSystemv5.Models.LaborType", b =>
                {
                    b.Property<int>("LaborTypeID")
                        .ValueGeneratedOnAdd();

                    b.HasKey("LaborTypeID");

                    b.ToTable("LaborType");
                });

            modelBuilder.Entity("AccountantSystemv5.Models.LoanAgreement", b =>
                {
                    b.Property<int>("LoanID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EmployeeID");

                    b.Property<int>("FinancierID");

                    b.Property<decimal>("InterestRate");

                    b.Property<decimal>("LoanAmount");

                    b.Property<DateTime>("LoanDate");

                    b.Property<DateTime>("MaturityDate");

                    b.Property<int>("PaymentsPerYear");

                    b.Property<int?>("StockHolderCreditorVendorID");

                    b.HasKey("LoanID");

                    b.HasIndex("EmployeeID");

                    b.HasIndex("StockHolderCreditorVendorID");

                    b.ToTable("LoanAgreement");
                });

            modelBuilder.Entity("AccountantSystemv5.Models.OutflowSaleInventory", b =>
                {
                    b.Property<int>("InvoiceID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("InventoryID");

                    b.Property<int>("QuantityOrdered");

                    b.Property<decimal>("SOPrice");

                    b.Property<int?>("SaleInvoiceID");

                    b.HasKey("InvoiceID");

                    b.HasIndex("InventoryID");

                    b.HasIndex("SaleInvoiceID");

                    b.ToTable("OutflowSaleInventory");
                });

            modelBuilder.Entity("AccountantSystemv5.Models.Purchase", b =>
                {
                    b.Property<int>("InventoryReceiptID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EmployeeID");

                    b.Property<decimal>("InventoryReceiptAmount");

                    b.Property<int>("PurchaseOrderID");

                    b.Property<DateTime>("ReceivingReportDate");

                    b.Property<string>("ReceivingReportVendorInvoiceID")
                        .IsRequired();

                    b.Property<string>("VendorID")
                        .IsRequired();

                    b.Property<int?>("VendorID1");

                    b.HasKey("InventoryReceiptID");

                    b.HasIndex("PurchaseOrderID");

                    b.HasIndex("VendorID1");

                    b.ToTable("Purchase");
                });

            modelBuilder.Entity("AccountantSystemv5.Models.PurchaseOrder", b =>
                {
                    b.Property<int>("PurchaseOrderID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EmployeeID");

                    b.Property<DateTime>("ExpectedDeliveryDate");

                    b.Property<decimal>("PurchaseOrderAmount");

                    b.Property<DateTime>("PurchaseOrderDate");

                    b.Property<int>("VendorID");

                    b.HasKey("PurchaseOrderID");

                    b.HasIndex("EmployeeID");

                    b.HasIndex("VendorID");

                    b.ToTable("PurchaseOrder");
                });

            modelBuilder.Entity("AccountantSystemv5.Models.ReservationPurchaseOrderInventory", b =>
                {
                    b.Property<int>("PurchaseOrderID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("InventoryID");

                    b.Property<decimal>("POPrice");

                    b.Property<int?>("PurchaseOrderID1");

                    b.Property<int>("QuantityOrdered");

                    b.Property<int>("VendorItemID");

                    b.HasKey("PurchaseOrderID");

                    b.HasIndex("InventoryID");

                    b.HasIndex("PurchaseOrderID1");

                    b.ToTable("ReservationPurchaseOrderInventory");
                });

            modelBuilder.Entity("AccountantSystemv5.Models.ReservationSaleOrderInventory", b =>
                {
                    b.Property<int>("SaleOrderID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("InventoryID");

                    b.Property<int>("QuantityOrdered");

                    b.Property<decimal>("SOPrice");

                    b.Property<int?>("SaleOrderID1");

                    b.HasKey("SaleOrderID");

                    b.HasIndex("InventoryID");

                    b.HasIndex("SaleOrderID1");

                    b.ToTable("ReservationSaleOrderInventory");
                });

            modelBuilder.Entity("AccountantSystemv5.Models.ReservationWSLT", b =>
                {
                    b.Property<int>("ScheduleID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("LaborTypeID");

                    b.Property<int?>("WorkScheduleScheduleID");

                    b.HasKey("ScheduleID");

                    b.HasIndex("LaborTypeID");

                    b.HasIndex("WorkScheduleScheduleID");

                    b.ToTable("ReservationWSLT");
                });

            modelBuilder.Entity("AccountantSystemv5.Models.Sale", b =>
                {
                    b.Property<int>("InvoiceID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CustomerID");

                    b.Property<int>("EmployeeID");

                    b.Property<int>("SaleAmount");

                    b.Property<int>("SaleOrderID");

                    b.Property<DateTime>("ShippingDate");

                    b.HasKey("InvoiceID");

                    b.HasIndex("SaleOrderID");

                    b.ToTable("Sale");
                });

            modelBuilder.Entity("AccountantSystemv5.Models.SaleOrder", b =>
                {
                    b.Property<int>("SaleOrderID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CustomerID");

                    b.Property<string>("CustomerPO");

                    b.Property<int>("EmployeeID");

                    b.Property<decimal>("SaleOrderAmount");

                    b.Property<DateTime>("SaleOrderDate");

                    b.HasKey("SaleOrderID");

                    b.HasIndex("CustomerID");

                    b.HasIndex("EmployeeID");

                    b.ToTable("SaleOrder");
                });

            modelBuilder.Entity("AccountantSystemv5.Models.StockHolderCreditor", b =>
                {
                    b.Property<int>("VendorID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FinancierAddress1")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("FinancierAddress2");

                    b.Property<string>("FinancierCity")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("FinancierName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("FinancierPrimaryContact")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("FinancierState")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("FinancierTelephone");

                    b.Property<string>("FinancierZipCode")
                        .IsRequired();

                    b.HasKey("VendorID");

                    b.ToTable("StockHolderCreditor");
                });

            modelBuilder.Entity("AccountantSystemv5.Models.StockSubscription", b =>
                {
                    b.Property<int>("StockID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EmployeeID");

                    b.Property<int>("FinancierID");

                    b.Property<decimal>("PricePerShare");

                    b.Property<int>("SharesIssued");

                    b.Property<int?>("StockHolderCreditorVendorID");

                    b.Property<DateTime>("StockIssueDate");

                    b.HasKey("StockID");

                    b.HasIndex("EmployeeID");

                    b.HasIndex("StockHolderCreditorVendorID");

                    b.ToTable("StockSubscription");
                });

            modelBuilder.Entity("AccountantSystemv5.Models.Vendor", b =>
                {
                    b.Property<int>("VendorID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("VendorAddress1")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("VendorAddress2");

                    b.Property<string>("VendorCity")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("VendorName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("VendorPrimaryContact")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("VendorState")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("VendorTelephone");

                    b.Property<string>("VendorZipCode")
                        .IsRequired();

                    b.HasKey("VendorID");

                    b.ToTable("Vendor");
                });

            modelBuilder.Entity("AccountantSystemv5.Models.Withholding", b =>
                {
                    b.Property<int>("MaritalStatusID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("FWTBracket");

                    b.Property<decimal>("FWTBracketBaseAmt");

                    b.Property<decimal>("FWTLowerLimit");

                    b.Property<decimal>("FWTRate");

                    b.Property<decimal>("FWTUpperLimit");

                    b.Property<string>("MaritalStatus")
                        .IsRequired();

                    b.HasKey("MaritalStatusID");

                    b.ToTable("Withholding");
                });

            modelBuilder.Entity("AccountantSystemv5.Models.WorkSchedule", b =>
                {
                    b.Property<int>("ScheduleID")
                        .ValueGeneratedOnAdd();

                    b.HasKey("ScheduleID");

                    b.ToTable("WorkSchedule");
                });

            modelBuilder.Entity("AccountantSystemv5.Models.CashDisbursement", b =>
                {
                    b.HasOne("AccountantSystemv5.Models.CashDisbursementType", "CashDisbursementType")
                        .WithMany("CashDisbursement")
                        .HasForeignKey("CDTypeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AccountantSystemv5.Models.CashAccount", "CashAccount")
                        .WithMany("CashDisbursement")
                        .HasForeignKey("CashAccountID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AccountantSystemv5.Models.FulfillmentLACD", "FulfillmentLACD")
                        .WithMany("CashDisbursement")
                        .HasForeignKey("FulfillmentLACDLoanPaymentID");

                    b.HasOne("AccountantSystemv5.Models.FulfillmentSSCD", "FulfillmentSSCD")
                        .WithMany("CashDisbursement")
                        .HasForeignKey("FulfillmentSSCDDividendID");

                    b.HasOne("AccountantSystemv5.Models.Purchase", "Purchase")
                        .WithMany("CashDisbursement")
                        .HasForeignKey("InventoryReceiptID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AccountantSystemv5.Models.CashReceipt", b =>
                {
                    b.HasOne("AccountantSystemv5.Models.CashReceiptType", "CashReceiptType")
                        .WithMany("CashReceipt")
                        .HasForeignKey("CRTypeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AccountantSystemv5.Models.CashAccount", "CashAccount")
                        .WithMany("CashReceipt")
                        .HasForeignKey("CashAccountID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AccountantSystemv5.Models.Sale", "Sale")
                        .WithOne("CashReceipt")
                        .HasForeignKey("AccountantSystemv5.Models.CashReceipt", "InvoiceID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AccountantSystemv5.Models.LoanAgreement", "LoanAgreement")
                        .WithMany("CashReceipt")
                        .HasForeignKey("LoanAgreementLoanID");

                    b.HasOne("AccountantSystemv5.Models.StockSubscription", "StockSubscription")
                        .WithMany("CashReceipt")
                        .HasForeignKey("StockSubscriptionStockID");
                });

            modelBuilder.Entity("AccountantSystemv5.Models.Employee", b =>
                {
                    b.HasOne("AccountantSystemv5.Models.EmployeeType", "EmployeeType")
                        .WithMany("Employee")
                        .HasForeignKey("EmployeeTypeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AccountantSystemv5.Models.Exemptions", "Exemptions")
                        .WithMany("Employee")
                        .HasForeignKey("ExemptionNum")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AccountantSystemv5.Models.Withholding", "Withholding")
                        .WithMany("Employee")
                        .HasForeignKey("MaritalStatusID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AccountantSystemv5.Models.ExternalPartWSE", b =>
                {
                    b.HasOne("AccountantSystemv5.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AccountantSystemv5.Models.WorkSchedule", "Schedule")
                        .WithMany("ExternalPartWSEs")
                        .HasForeignKey("ScheduleID1");
                });

            modelBuilder.Entity("AccountantSystemv5.Models.FulfillmentLACD", b =>
                {
                    b.HasOne("AccountantSystemv5.Models.LoanAgreement", "LoanAgreement")
                        .WithMany("FulfillmentLACD")
                        .HasForeignKey("LoanID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AccountantSystemv5.Models.FulfillmentSSCD", b =>
                {
                    b.HasOne("AccountantSystemv5.Models.StockSubscription", "StockSubscription")
                        .WithMany("FulfillmentSSCD")
                        .HasForeignKey("StockID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AccountantSystemv5.Models.FulfillmentWSLA", b =>
                {
                    b.HasOne("AccountantSystemv5.Models.LaborAcquisition", "LaborAcquisition")
                        .WithMany()
                        .HasForeignKey("TimeCardID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AccountantSystemv5.Models.WorkSchedule", "WorkSchedule")
                        .WithMany("FulfillmentWSLAs")
                        .HasForeignKey("WorkScheduleScheduleID");
                });

            modelBuilder.Entity("AccountantSystemv5.Models.InflowLALT", b =>
                {
                    b.HasOne("AccountantSystemv5.Models.LaborAcquisition", "LaborAcquisition")
                        .WithMany()
                        .HasForeignKey("LaborAcquisitionTimeCardID");

                    b.HasOne("AccountantSystemv5.Models.LaborType", "LaborType")
                        .WithMany("InflowLALTs")
                        .HasForeignKey("LaborTypeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AccountantSystemv5.Models.InflowPurchaseInventory", b =>
                {
                    b.HasOne("AccountantSystemv5.Models.Inventory", "Inventory")
                        .WithMany("InflowPurchaseInventories")
                        .HasForeignKey("InventoryID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AccountantSystemv5.Models.Purchase", "Purchase")
                        .WithMany("InflowPurchaseInventories")
                        .HasForeignKey("PurchaseInventoryReceiptID");
                });

            modelBuilder.Entity("AccountantSystemv5.Models.Inventory", b =>
                {
                    b.HasOne("AccountantSystemv5.Models.InventoryComposition", "InventoryComposition")
                        .WithMany("Inventory")
                        .HasForeignKey("InventoryCompositionID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AccountantSystemv5.Models.InventoryDiameter", "InventoryDiameter")
                        .WithMany("Inventory")
                        .HasForeignKey("InventoryDiameterID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AccountantSystemv5.Models.InventoryType", "InventoryType")
                        .WithMany("Inventory")
                        .HasForeignKey("InventoryTypeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AccountantSystemv5.Models.LaborAcquisition", b =>
                {
                    b.HasOne("AccountantSystemv5.Models.Employee", "Employee")
                        .WithMany("LaborAcquisition")
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AccountantSystemv5.Models.LoanAgreement", b =>
                {
                    b.HasOne("AccountantSystemv5.Models.Employee", "Employee")
                        .WithMany("LoanAgreemnet")
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AccountantSystemv5.Models.StockHolderCreditor", "StockHolderCreditor")
                        .WithMany("LoanAgreemnet")
                        .HasForeignKey("StockHolderCreditorVendorID");
                });

            modelBuilder.Entity("AccountantSystemv5.Models.OutflowSaleInventory", b =>
                {
                    b.HasOne("AccountantSystemv5.Models.Inventory", "Inventory")
                        .WithMany("OutflowSaleInventories")
                        .HasForeignKey("InventoryID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AccountantSystemv5.Models.Sale", "Sale")
                        .WithMany("OutflowSaleInventories")
                        .HasForeignKey("SaleInvoiceID");
                });

            modelBuilder.Entity("AccountantSystemv5.Models.Purchase", b =>
                {
                    b.HasOne("AccountantSystemv5.Models.PurchaseOrder", "PurchaseOrder")
                        .WithMany("Purchase")
                        .HasForeignKey("PurchaseOrderID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AccountantSystemv5.Models.Vendor", "Vendor")
                        .WithMany()
                        .HasForeignKey("VendorID1");
                });

            modelBuilder.Entity("AccountantSystemv5.Models.PurchaseOrder", b =>
                {
                    b.HasOne("AccountantSystemv5.Models.Employee", "Employee")
                        .WithMany("PurchaseOrder")
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AccountantSystemv5.Models.Vendor", "Vendor")
                        .WithMany("PurchaseOrder")
                        .HasForeignKey("VendorID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AccountantSystemv5.Models.ReservationPurchaseOrderInventory", b =>
                {
                    b.HasOne("AccountantSystemv5.Models.Inventory", "Inventory")
                        .WithMany("ReservationPurchaseOrderInventories")
                        .HasForeignKey("InventoryID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AccountantSystemv5.Models.PurchaseOrder", "PurchaseOrder")
                        .WithMany("ReservationPurchaseOrderInventories")
                        .HasForeignKey("PurchaseOrderID1");
                });

            modelBuilder.Entity("AccountantSystemv5.Models.ReservationSaleOrderInventory", b =>
                {
                    b.HasOne("AccountantSystemv5.Models.Inventory", "Inventory")
                        .WithMany("ReservationSaleOrderInventories")
                        .HasForeignKey("InventoryID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AccountantSystemv5.Models.SaleOrder", "SaleOrder")
                        .WithMany("ReservationSaleOrderInventories")
                        .HasForeignKey("SaleOrderID1");
                });

            modelBuilder.Entity("AccountantSystemv5.Models.ReservationWSLT", b =>
                {
                    b.HasOne("AccountantSystemv5.Models.LaborType", "LaborType")
                        .WithMany("ReservationWSLTs")
                        .HasForeignKey("LaborTypeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AccountantSystemv5.Models.WorkSchedule", "WorkSchedule")
                        .WithMany("ReservationWSLTs")
                        .HasForeignKey("WorkScheduleScheduleID");
                });

            modelBuilder.Entity("AccountantSystemv5.Models.Sale", b =>
                {
                    b.HasOne("AccountantSystemv5.Models.SaleOrder", "SaleOrder")
                        .WithMany("Sale")
                        .HasForeignKey("SaleOrderID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AccountantSystemv5.Models.SaleOrder", b =>
                {
                    b.HasOne("AccountantSystemv5.Models.Customer", "Customer")
                        .WithMany("SaleOrder")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AccountantSystemv5.Models.Employee", "Employee")
                        .WithMany("SaleOrder")
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AccountantSystemv5.Models.StockSubscription", b =>
                {
                    b.HasOne("AccountantSystemv5.Models.Employee", "Employee")
                        .WithMany("StockSubscription")
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AccountantSystemv5.Models.StockHolderCreditor", "StockHolderCreditor")
                        .WithMany("StockSubscription")
                        .HasForeignKey("StockHolderCreditorVendorID");
                });
        }
    }
}
