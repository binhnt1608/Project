using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AccountantSystemv5.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CashAccount",
                columns: table => new
                {
                    CashAccountID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountDescription = table.Column<string>(maxLength: 255, nullable: true),
                    BankName = table.Column<string>(maxLength: 50, nullable: false),
                    CashAccountDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashAccount", x => x.CashAccountID);
                });

            migrationBuilder.CreateTable(
                name: "CashDisbursementType",
                columns: table => new
                {
                    CDTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EventTypeName = table.Column<string>(maxLength: 50, nullable: false),
                    PayeeTypeName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashDisbursementType", x => x.CDTypeID);
                });

            migrationBuilder.CreateTable(
                name: "CashReceiptType",
                columns: table => new
                {
                    CRTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EventTypeName = table.Column<string>(maxLength: 50, nullable: false),
                    PayeeTypeName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashReceiptType", x => x.CRTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerAddress1 = table.Column<string>(maxLength: 50, nullable: false),
                    CustomerAddress2 = table.Column<string>(maxLength: 50, nullable: true),
                    CustomerCity = table.Column<string>(maxLength: 50, nullable: false),
                    CustomerCreditLimit = table.Column<decimal>(nullable: false),
                    CustomerName = table.Column<string>(maxLength: 50, nullable: false),
                    CustomerPrimaryContact = table.Column<string>(maxLength: 50, nullable: true),
                    CustomerState = table.Column<string>(maxLength: 50, nullable: false),
                    CustomerTelephone = table.Column<string>(maxLength: 20, nullable: false),
                    CustomerZipcode = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeType",
                columns: table => new
                {
                    EmployeeTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmployeeTypeName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeType", x => x.EmployeeTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Exemptions",
                columns: table => new
                {
                    ExemptionNum = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ExemptionAmount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exemptions", x => x.ExemptionNum);
                });

            migrationBuilder.CreateTable(
                name: "InventoryComposition",
                columns: table => new
                {
                    CompositionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InventoryCompositionCode = table.Column<string>(nullable: false),
                    InventoryCompositionDescription = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryComposition", x => x.CompositionID);
                });

            migrationBuilder.CreateTable(
                name: "InventoryDiameter",
                columns: table => new
                {
                    CompositionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InventoryDiameterCode = table.Column<int>(nullable: false),
                    InventoryDiameterDescription = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryDiameter", x => x.CompositionID);
                });

            migrationBuilder.CreateTable(
                name: "InventoryType",
                columns: table => new
                {
                    CompositionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InventoryTypeCode = table.Column<string>(nullable: true),
                    InventoryTypeDescription = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryType", x => x.CompositionID);
                });

            migrationBuilder.CreateTable(
                name: "LaborType",
                columns: table => new
                {
                    LaborTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaborType", x => x.LaborTypeID);
                });

            migrationBuilder.CreateTable(
                name: "StockHolderCreditor",
                columns: table => new
                {
                    VendorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FinancierAddress1 = table.Column<string>(maxLength: 50, nullable: false),
                    FinancierAddress2 = table.Column<string>(nullable: true),
                    FinancierCity = table.Column<string>(maxLength: 50, nullable: false),
                    FinancierName = table.Column<string>(maxLength: 50, nullable: false),
                    FinancierPrimaryContact = table.Column<string>(maxLength: 50, nullable: false),
                    FinancierState = table.Column<string>(maxLength: 50, nullable: false),
                    FinancierTelephone = table.Column<int>(nullable: false),
                    FinancierZipCode = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockHolderCreditor", x => x.VendorID);
                });

            migrationBuilder.CreateTable(
                name: "Vendor",
                columns: table => new
                {
                    VendorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VendorAddress1 = table.Column<string>(maxLength: 50, nullable: false),
                    VendorAddress2 = table.Column<string>(nullable: true),
                    VendorCity = table.Column<string>(maxLength: 50, nullable: false),
                    VendorName = table.Column<string>(maxLength: 50, nullable: false),
                    VendorPrimaryContact = table.Column<string>(maxLength: 50, nullable: false),
                    VendorState = table.Column<string>(maxLength: 50, nullable: false),
                    VendorTelephone = table.Column<int>(nullable: false),
                    VendorZipCode = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendor", x => x.VendorID);
                });

            migrationBuilder.CreateTable(
                name: "Withholding",
                columns: table => new
                {
                    MaritalStatusID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FWTBracket = table.Column<int>(nullable: false),
                    FWTBracketBaseAmt = table.Column<decimal>(nullable: false),
                    FWTLowerLimit = table.Column<decimal>(nullable: false),
                    FWTRate = table.Column<decimal>(nullable: false),
                    FWTUpperLimit = table.Column<decimal>(nullable: false),
                    MaritalStatus = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Withholding", x => x.MaritalStatusID);
                });

            migrationBuilder.CreateTable(
                name: "WorkSchedule",
                columns: table => new
                {
                    ScheduleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkSchedule", x => x.ScheduleID);
                });

            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    InventoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InventoryCompositionID = table.Column<int>(nullable: false),
                    InventoryDiameterID = table.Column<int>(nullable: false),
                    InventoryListPrice = table.Column<decimal>(nullable: false),
                    InventoryStdCosst = table.Column<decimal>(nullable: false),
                    InventoryTypeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.InventoryID);
                    table.ForeignKey(
                        name: "FK_Inventory_InventoryComposition_InventoryCompositionID",
                        column: x => x.InventoryCompositionID,
                        principalTable: "InventoryComposition",
                        principalColumn: "CompositionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventory_InventoryDiameter_InventoryDiameterID",
                        column: x => x.InventoryDiameterID,
                        principalTable: "InventoryDiameter",
                        principalColumn: "CompositionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventory_InventoryType_InventoryTypeID",
                        column: x => x.InventoryTypeID,
                        principalTable: "InventoryType",
                        principalColumn: "CompositionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmAddress1 = table.Column<string>(maxLength: 50, nullable: false),
                    EmAddress2 = table.Column<string>(maxLength: 50, nullable: true),
                    EmCity = table.Column<string>(maxLength: 50, nullable: false),
                    EmPayRate = table.Column<decimal>(nullable: false),
                    EmStartDate = table.Column<DateTime>(nullable: false),
                    EmState = table.Column<string>(maxLength: 50, nullable: false),
                    EmTelephone = table.Column<string>(maxLength: 20, nullable: false),
                    EmZipcode = table.Column<string>(maxLength: 50, nullable: false),
                    EmployeeFirstName = table.Column<string>(maxLength: 50, nullable: false),
                    EmployeeLastName = table.Column<string>(maxLength: 50, nullable: false),
                    EmployeeSSN = table.Column<string>(maxLength: 11, nullable: false),
                    EmployeeTypeID = table.Column<int>(nullable: false),
                    ExemptionNum = table.Column<int>(nullable: false),
                    MI = table.Column<string>(maxLength: 50, nullable: false),
                    MaritalStatusID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeID);
                    table.ForeignKey(
                        name: "FK_Employee_EmployeeType_EmployeeTypeID",
                        column: x => x.EmployeeTypeID,
                        principalTable: "EmployeeType",
                        principalColumn: "EmployeeTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employee_Exemptions_ExemptionNum",
                        column: x => x.ExemptionNum,
                        principalTable: "Exemptions",
                        principalColumn: "ExemptionNum",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employee_Withholding_MaritalStatusID",
                        column: x => x.MaritalStatusID,
                        principalTable: "Withholding",
                        principalColumn: "MaritalStatusID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReservationWSLT",
                columns: table => new
                {
                    ScheduleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LaborTypeID = table.Column<int>(nullable: false),
                    WorkScheduleScheduleID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationWSLT", x => x.ScheduleID);
                    table.ForeignKey(
                        name: "FK_ReservationWSLT_LaborType_LaborTypeID",
                        column: x => x.LaborTypeID,
                        principalTable: "LaborType",
                        principalColumn: "LaborTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservationWSLT_WorkSchedule_WorkScheduleScheduleID",
                        column: x => x.WorkScheduleScheduleID,
                        principalTable: "WorkSchedule",
                        principalColumn: "ScheduleID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExternalPartWSE",
                columns: table => new
                {
                    ScheduleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmployeeID = table.Column<int>(nullable: false),
                    ScheduleID1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalPartWSE", x => x.ScheduleID);
                    table.ForeignKey(
                        name: "FK_ExternalPartWSE_Employee_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employee",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExternalPartWSE_WorkSchedule_ScheduleID1",
                        column: x => x.ScheduleID1,
                        principalTable: "WorkSchedule",
                        principalColumn: "ScheduleID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LaborAcquisition",
                columns: table => new
                {
                    TimeCardID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmployeeID = table.Column<int>(nullable: false),
                    EmployeeSupervisorID = table.Column<int>(nullable: false),
                    LAOvertime = table.Column<int>(nullable: false),
                    LAPayPeriodEnded = table.Column<DateTime>(nullable: false),
                    LARegularTime = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaborAcquisition", x => x.TimeCardID);
                    table.ForeignKey(
                        name: "FK_LaborAcquisition_Employee_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employee",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoanAgreement",
                columns: table => new
                {
                    LoanID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmployeeID = table.Column<int>(nullable: false),
                    FinancierID = table.Column<int>(nullable: false),
                    InterestRate = table.Column<decimal>(nullable: false),
                    LoanAmount = table.Column<decimal>(nullable: false),
                    LoanDate = table.Column<DateTime>(nullable: false),
                    MaturityDate = table.Column<DateTime>(nullable: false),
                    PaymentsPerYear = table.Column<int>(nullable: false),
                    StockHolderCreditorVendorID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanAgreement", x => x.LoanID);
                    table.ForeignKey(
                        name: "FK_LoanAgreement_Employee_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employee",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanAgreement_StockHolderCreditor_StockHolderCreditorVendorID",
                        column: x => x.StockHolderCreditorVendorID,
                        principalTable: "StockHolderCreditor",
                        principalColumn: "VendorID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrder",
                columns: table => new
                {
                    PurchaseOrderID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmployeeID = table.Column<int>(nullable: false),
                    ExpectedDeliveryDate = table.Column<DateTime>(nullable: false),
                    PurchaseOrderAmount = table.Column<decimal>(nullable: false),
                    PurchaseOrderDate = table.Column<DateTime>(nullable: false),
                    VendorID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrder", x => x.PurchaseOrderID);
                    table.ForeignKey(
                        name: "FK_PurchaseOrder_Employee_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employee",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseOrder_Vendor_VendorID",
                        column: x => x.VendorID,
                        principalTable: "Vendor",
                        principalColumn: "VendorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SaleOrder",
                columns: table => new
                {
                    SaleOrderID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerID = table.Column<int>(nullable: false),
                    CustomerPO = table.Column<string>(nullable: true),
                    EmployeeID = table.Column<int>(nullable: false),
                    SaleOrderAmount = table.Column<decimal>(nullable: false),
                    SaleOrderDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleOrder", x => x.SaleOrderID);
                    table.ForeignKey(
                        name: "FK_SaleOrder_Customer_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customer",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaleOrder_Employee_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employee",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StockSubscription",
                columns: table => new
                {
                    StockID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmployeeID = table.Column<int>(nullable: false),
                    FinancierID = table.Column<int>(nullable: false),
                    PricePerShare = table.Column<decimal>(nullable: false),
                    SharesIssued = table.Column<int>(nullable: false),
                    StockHolderCreditorVendorID = table.Column<int>(nullable: true),
                    StockIssueDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockSubscription", x => x.StockID);
                    table.ForeignKey(
                        name: "FK_StockSubscription_Employee_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employee",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StockSubscription_StockHolderCreditor_StockHolderCreditorVendorID",
                        column: x => x.StockHolderCreditorVendorID,
                        principalTable: "StockHolderCreditor",
                        principalColumn: "VendorID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FulfillmentWSLA",
                columns: table => new
                {
                    ScheduleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TimeCardID = table.Column<int>(nullable: false),
                    WorkScheduleScheduleID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FulfillmentWSLA", x => x.ScheduleID);
                    table.ForeignKey(
                        name: "FK_FulfillmentWSLA_LaborAcquisition_TimeCardID",
                        column: x => x.TimeCardID,
                        principalTable: "LaborAcquisition",
                        principalColumn: "TimeCardID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FulfillmentWSLA_WorkSchedule_WorkScheduleScheduleID",
                        column: x => x.WorkScheduleScheduleID,
                        principalTable: "WorkSchedule",
                        principalColumn: "ScheduleID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InflowLALT",
                columns: table => new
                {
                    TimeCardID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LaborAcquisitionTimeCardID = table.Column<int>(nullable: true),
                    LaborTypeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InflowLALT", x => x.TimeCardID);
                    table.ForeignKey(
                        name: "FK_InflowLALT_LaborAcquisition_LaborAcquisitionTimeCardID",
                        column: x => x.LaborAcquisitionTimeCardID,
                        principalTable: "LaborAcquisition",
                        principalColumn: "TimeCardID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InflowLALT_LaborType_LaborTypeID",
                        column: x => x.LaborTypeID,
                        principalTable: "LaborType",
                        principalColumn: "LaborTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FulfillmentLACD",
                columns: table => new
                {
                    LoanPaymentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InterestAmount = table.Column<decimal>(nullable: false),
                    LoanID = table.Column<int>(nullable: false),
                    PaymentDueDate = table.Column<DateTime>(nullable: false),
                    PaymentNum = table.Column<int>(nullable: false),
                    PrincipalAmount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FulfillmentLACD", x => x.LoanPaymentID);
                    table.ForeignKey(
                        name: "FK_FulfillmentLACD_LoanAgreement_LoanID",
                        column: x => x.LoanID,
                        principalTable: "LoanAgreement",
                        principalColumn: "LoanID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Purchase",
                columns: table => new
                {
                    InventoryReceiptID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmployeeID = table.Column<int>(nullable: false),
                    InventoryReceiptAmount = table.Column<decimal>(nullable: false),
                    PurchaseOrderID = table.Column<int>(nullable: false),
                    ReceivingReportDate = table.Column<DateTime>(nullable: false),
                    ReceivingReportVendorInvoiceID = table.Column<string>(nullable: false),
                    VendorID = table.Column<string>(nullable: false),
                    VendorID1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchase", x => x.InventoryReceiptID);
                    table.ForeignKey(
                        name: "FK_Purchase_PurchaseOrder_PurchaseOrderID",
                        column: x => x.PurchaseOrderID,
                        principalTable: "PurchaseOrder",
                        principalColumn: "PurchaseOrderID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Purchase_Vendor_VendorID1",
                        column: x => x.VendorID1,
                        principalTable: "Vendor",
                        principalColumn: "VendorID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReservationPurchaseOrderInventory",
                columns: table => new
                {
                    PurchaseOrderID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InventoryID = table.Column<int>(nullable: false),
                    POPrice = table.Column<decimal>(nullable: false),
                    PurchaseOrderID1 = table.Column<int>(nullable: true),
                    QuantityOrdered = table.Column<int>(nullable: false),
                    VendorItemID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationPurchaseOrderInventory", x => x.PurchaseOrderID);
                    table.ForeignKey(
                        name: "FK_ReservationPurchaseOrderInventory_Inventory_InventoryID",
                        column: x => x.InventoryID,
                        principalTable: "Inventory",
                        principalColumn: "InventoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservationPurchaseOrderInventory_PurchaseOrder_PurchaseOrderID1",
                        column: x => x.PurchaseOrderID1,
                        principalTable: "PurchaseOrder",
                        principalColumn: "PurchaseOrderID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReservationSaleOrderInventory",
                columns: table => new
                {
                    SaleOrderID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InventoryID = table.Column<int>(nullable: false),
                    QuantityOrdered = table.Column<int>(nullable: false),
                    SOPrice = table.Column<decimal>(nullable: false),
                    SaleOrderID1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationSaleOrderInventory", x => x.SaleOrderID);
                    table.ForeignKey(
                        name: "FK_ReservationSaleOrderInventory_Inventory_InventoryID",
                        column: x => x.InventoryID,
                        principalTable: "Inventory",
                        principalColumn: "InventoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservationSaleOrderInventory_SaleOrder_SaleOrderID1",
                        column: x => x.SaleOrderID1,
                        principalTable: "SaleOrder",
                        principalColumn: "SaleOrderID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sale",
                columns: table => new
                {
                    InvoiceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerID = table.Column<int>(nullable: false),
                    EmployeeID = table.Column<int>(nullable: false),
                    SaleAmount = table.Column<int>(nullable: false),
                    SaleOrderID = table.Column<int>(nullable: false),
                    ShippingDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sale", x => x.InvoiceID);
                    table.ForeignKey(
                        name: "FK_Sale_SaleOrder_SaleOrderID",
                        column: x => x.SaleOrderID,
                        principalTable: "SaleOrder",
                        principalColumn: "SaleOrderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FulfillmentSSCD",
                columns: table => new
                {
                    DividendID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DividendDeclarationDate = table.Column<DateTime>(nullable: false),
                    DividendPerShare = table.Column<decimal>(nullable: false),
                    StockID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FulfillmentSSCD", x => x.DividendID);
                    table.ForeignKey(
                        name: "FK_FulfillmentSSCD_StockSubscription_StockID",
                        column: x => x.StockID,
                        principalTable: "StockSubscription",
                        principalColumn: "StockID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InflowPurchaseInventory",
                columns: table => new
                {
                    InventoryReceiptID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InventoryID = table.Column<int>(nullable: false),
                    InventoryReceiptPrice = table.Column<int>(nullable: false),
                    PurchaseInventoryReceiptID = table.Column<int>(nullable: true),
                    QuantityReceived = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InflowPurchaseInventory", x => x.InventoryReceiptID);
                    table.ForeignKey(
                        name: "FK_InflowPurchaseInventory_Inventory_InventoryID",
                        column: x => x.InventoryID,
                        principalTable: "Inventory",
                        principalColumn: "InventoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InflowPurchaseInventory_Purchase_PurchaseInventoryReceiptID",
                        column: x => x.PurchaseInventoryReceiptID,
                        principalTable: "Purchase",
                        principalColumn: "InventoryReceiptID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CashReceipt",
                columns: table => new
                {
                    RemittanceAdviceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CRTypeID = table.Column<int>(nullable: false),
                    CashAccountID = table.Column<int>(nullable: false),
                    CashReceiptDate = table.Column<DateTime>(nullable: false),
                    CasheReceiptAmount = table.Column<decimal>(nullable: false),
                    CustomerID = table.Column<int>(nullable: false),
                    EmployeeID = table.Column<int>(nullable: false),
                    InvoiceID = table.Column<int>(nullable: false),
                    LoanAgreementLoanID = table.Column<int>(nullable: true),
                    PayorCheckNum = table.Column<int>(nullable: false),
                    StockSubscriptionStockID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashReceipt", x => x.RemittanceAdviceID);
                    table.ForeignKey(
                        name: "FK_CashReceipt_CashReceiptType_CRTypeID",
                        column: x => x.CRTypeID,
                        principalTable: "CashReceiptType",
                        principalColumn: "CRTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CashReceipt_CashAccount_CashAccountID",
                        column: x => x.CashAccountID,
                        principalTable: "CashAccount",
                        principalColumn: "CashAccountID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CashReceipt_Sale_InvoiceID",
                        column: x => x.InvoiceID,
                        principalTable: "Sale",
                        principalColumn: "InvoiceID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CashReceipt_LoanAgreement_LoanAgreementLoanID",
                        column: x => x.LoanAgreementLoanID,
                        principalTable: "LoanAgreement",
                        principalColumn: "LoanID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CashReceipt_StockSubscription_StockSubscriptionStockID",
                        column: x => x.StockSubscriptionStockID,
                        principalTable: "StockSubscription",
                        principalColumn: "StockID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OutflowSaleInventory",
                columns: table => new
                {
                    InvoiceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InventoryID = table.Column<int>(nullable: false),
                    QuantityOrdered = table.Column<int>(nullable: false),
                    SOPrice = table.Column<decimal>(nullable: false),
                    SaleInvoiceID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutflowSaleInventory", x => x.InvoiceID);
                    table.ForeignKey(
                        name: "FK_OutflowSaleInventory_Inventory_InventoryID",
                        column: x => x.InventoryID,
                        principalTable: "Inventory",
                        principalColumn: "InventoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OutflowSaleInventory_Sale_SaleInvoiceID",
                        column: x => x.SaleInvoiceID,
                        principalTable: "Sale",
                        principalColumn: "InvoiceID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CashDisbursement",
                columns: table => new
                {
                    CheckNumber = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CDTypeID = table.Column<int>(nullable: false),
                    CashAccountID = table.Column<int>(nullable: false),
                    CashDisbursementAmount = table.Column<decimal>(nullable: false),
                    CashDisbursementDate = table.Column<DateTime>(nullable: false),
                    EmployeeID = table.Column<int>(nullable: false),
                    FulfillmentLACDLoanPaymentID = table.Column<int>(nullable: true),
                    FulfillmentSSCDDividendID = table.Column<int>(nullable: true),
                    InventoryReceiptID = table.Column<int>(nullable: false),
                    VendorID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashDisbursement", x => x.CheckNumber);
                    table.ForeignKey(
                        name: "FK_CashDisbursement_CashDisbursementType_CDTypeID",
                        column: x => x.CDTypeID,
                        principalTable: "CashDisbursementType",
                        principalColumn: "CDTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CashDisbursement_CashAccount_CashAccountID",
                        column: x => x.CashAccountID,
                        principalTable: "CashAccount",
                        principalColumn: "CashAccountID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CashDisbursement_FulfillmentLACD_FulfillmentLACDLoanPaymentID",
                        column: x => x.FulfillmentLACDLoanPaymentID,
                        principalTable: "FulfillmentLACD",
                        principalColumn: "LoanPaymentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CashDisbursement_FulfillmentSSCD_FulfillmentSSCDDividendID",
                        column: x => x.FulfillmentSSCDDividendID,
                        principalTable: "FulfillmentSSCD",
                        principalColumn: "DividendID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CashDisbursement_Purchase_InventoryReceiptID",
                        column: x => x.InventoryReceiptID,
                        principalTable: "Purchase",
                        principalColumn: "InventoryReceiptID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CashDisbursement_CDTypeID",
                table: "CashDisbursement",
                column: "CDTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_CashDisbursement_CashAccountID",
                table: "CashDisbursement",
                column: "CashAccountID");

            migrationBuilder.CreateIndex(
                name: "IX_CashDisbursement_FulfillmentLACDLoanPaymentID",
                table: "CashDisbursement",
                column: "FulfillmentLACDLoanPaymentID");

            migrationBuilder.CreateIndex(
                name: "IX_CashDisbursement_FulfillmentSSCDDividendID",
                table: "CashDisbursement",
                column: "FulfillmentSSCDDividendID");

            migrationBuilder.CreateIndex(
                name: "IX_CashDisbursement_InventoryReceiptID",
                table: "CashDisbursement",
                column: "InventoryReceiptID");

            migrationBuilder.CreateIndex(
                name: "IX_CashReceipt_CRTypeID",
                table: "CashReceipt",
                column: "CRTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_CashReceipt_CashAccountID",
                table: "CashReceipt",
                column: "CashAccountID");

            migrationBuilder.CreateIndex(
                name: "IX_CashReceipt_InvoiceID",
                table: "CashReceipt",
                column: "InvoiceID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CashReceipt_LoanAgreementLoanID",
                table: "CashReceipt",
                column: "LoanAgreementLoanID");

            migrationBuilder.CreateIndex(
                name: "IX_CashReceipt_StockSubscriptionStockID",
                table: "CashReceipt",
                column: "StockSubscriptionStockID");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_EmployeeTypeID",
                table: "Employee",
                column: "EmployeeTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_ExemptionNum",
                table: "Employee",
                column: "ExemptionNum");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_MaritalStatusID",
                table: "Employee",
                column: "MaritalStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_ExternalPartWSE_EmployeeID",
                table: "ExternalPartWSE",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_ExternalPartWSE_ScheduleID1",
                table: "ExternalPartWSE",
                column: "ScheduleID1");

            migrationBuilder.CreateIndex(
                name: "IX_FulfillmentLACD_LoanID",
                table: "FulfillmentLACD",
                column: "LoanID");

            migrationBuilder.CreateIndex(
                name: "IX_FulfillmentSSCD_StockID",
                table: "FulfillmentSSCD",
                column: "StockID");

            migrationBuilder.CreateIndex(
                name: "IX_FulfillmentWSLA_TimeCardID",
                table: "FulfillmentWSLA",
                column: "TimeCardID");

            migrationBuilder.CreateIndex(
                name: "IX_FulfillmentWSLA_WorkScheduleScheduleID",
                table: "FulfillmentWSLA",
                column: "WorkScheduleScheduleID");

            migrationBuilder.CreateIndex(
                name: "IX_InflowLALT_LaborAcquisitionTimeCardID",
                table: "InflowLALT",
                column: "LaborAcquisitionTimeCardID");

            migrationBuilder.CreateIndex(
                name: "IX_InflowLALT_LaborTypeID",
                table: "InflowLALT",
                column: "LaborTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_InflowPurchaseInventory_InventoryID",
                table: "InflowPurchaseInventory",
                column: "InventoryID");

            migrationBuilder.CreateIndex(
                name: "IX_InflowPurchaseInventory_PurchaseInventoryReceiptID",
                table: "InflowPurchaseInventory",
                column: "PurchaseInventoryReceiptID");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_InventoryCompositionID",
                table: "Inventory",
                column: "InventoryCompositionID");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_InventoryDiameterID",
                table: "Inventory",
                column: "InventoryDiameterID");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_InventoryTypeID",
                table: "Inventory",
                column: "InventoryTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_LaborAcquisition_EmployeeID",
                table: "LaborAcquisition",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_LoanAgreement_EmployeeID",
                table: "LoanAgreement",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_LoanAgreement_StockHolderCreditorVendorID",
                table: "LoanAgreement",
                column: "StockHolderCreditorVendorID");

            migrationBuilder.CreateIndex(
                name: "IX_OutflowSaleInventory_InventoryID",
                table: "OutflowSaleInventory",
                column: "InventoryID");

            migrationBuilder.CreateIndex(
                name: "IX_OutflowSaleInventory_SaleInvoiceID",
                table: "OutflowSaleInventory",
                column: "SaleInvoiceID");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_PurchaseOrderID",
                table: "Purchase",
                column: "PurchaseOrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_VendorID1",
                table: "Purchase",
                column: "VendorID1");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrder_EmployeeID",
                table: "PurchaseOrder",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrder_VendorID",
                table: "PurchaseOrder",
                column: "VendorID");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationPurchaseOrderInventory_InventoryID",
                table: "ReservationPurchaseOrderInventory",
                column: "InventoryID");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationPurchaseOrderInventory_PurchaseOrderID1",
                table: "ReservationPurchaseOrderInventory",
                column: "PurchaseOrderID1");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationSaleOrderInventory_InventoryID",
                table: "ReservationSaleOrderInventory",
                column: "InventoryID");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationSaleOrderInventory_SaleOrderID1",
                table: "ReservationSaleOrderInventory",
                column: "SaleOrderID1");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationWSLT_LaborTypeID",
                table: "ReservationWSLT",
                column: "LaborTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationWSLT_WorkScheduleScheduleID",
                table: "ReservationWSLT",
                column: "WorkScheduleScheduleID");

            migrationBuilder.CreateIndex(
                name: "IX_Sale_SaleOrderID",
                table: "Sale",
                column: "SaleOrderID");

            migrationBuilder.CreateIndex(
                name: "IX_SaleOrder_CustomerID",
                table: "SaleOrder",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_SaleOrder_EmployeeID",
                table: "SaleOrder",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_StockSubscription_EmployeeID",
                table: "StockSubscription",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_StockSubscription_StockHolderCreditorVendorID",
                table: "StockSubscription",
                column: "StockHolderCreditorVendorID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CashDisbursement");

            migrationBuilder.DropTable(
                name: "CashReceipt");

            migrationBuilder.DropTable(
                name: "ExternalPartWSE");

            migrationBuilder.DropTable(
                name: "FulfillmentWSLA");

            migrationBuilder.DropTable(
                name: "InflowLALT");

            migrationBuilder.DropTable(
                name: "InflowPurchaseInventory");

            migrationBuilder.DropTable(
                name: "OutflowSaleInventory");

            migrationBuilder.DropTable(
                name: "ReservationPurchaseOrderInventory");

            migrationBuilder.DropTable(
                name: "ReservationSaleOrderInventory");

            migrationBuilder.DropTable(
                name: "ReservationWSLT");

            migrationBuilder.DropTable(
                name: "CashDisbursementType");

            migrationBuilder.DropTable(
                name: "FulfillmentLACD");

            migrationBuilder.DropTable(
                name: "FulfillmentSSCD");

            migrationBuilder.DropTable(
                name: "CashReceiptType");

            migrationBuilder.DropTable(
                name: "CashAccount");

            migrationBuilder.DropTable(
                name: "LaborAcquisition");

            migrationBuilder.DropTable(
                name: "Purchase");

            migrationBuilder.DropTable(
                name: "Sale");

            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropTable(
                name: "LaborType");

            migrationBuilder.DropTable(
                name: "WorkSchedule");

            migrationBuilder.DropTable(
                name: "LoanAgreement");

            migrationBuilder.DropTable(
                name: "StockSubscription");

            migrationBuilder.DropTable(
                name: "PurchaseOrder");

            migrationBuilder.DropTable(
                name: "SaleOrder");

            migrationBuilder.DropTable(
                name: "InventoryComposition");

            migrationBuilder.DropTable(
                name: "InventoryDiameter");

            migrationBuilder.DropTable(
                name: "InventoryType");

            migrationBuilder.DropTable(
                name: "StockHolderCreditor");

            migrationBuilder.DropTable(
                name: "Vendor");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "EmployeeType");

            migrationBuilder.DropTable(
                name: "Exemptions");

            migrationBuilder.DropTable(
                name: "Withholding");
        }
    }
}
