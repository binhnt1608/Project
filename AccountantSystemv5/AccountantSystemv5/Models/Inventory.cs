﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AccountantSystemv5.Models
{
    public class Inventory
    {
        //public Inventory() { }
        [Key]
        [Required]
        [Display(Name = "Inventory #")]
        public int InventoryID { get; set; }

        [Display(Name = "Composition")]
        public int InventoryCompositionID { get; set; }

        [Display(Name = "Type")]
        public int InventoryTypeID { get; set; }

        [Display(Name = "Diameter")]
        public int InventoryDiameterID { get; set; }

        [Display(Name = "Std. Cost")]
        [DisplayFormat(DataFormatString = "{0:$#.##}")]
        public Decimal InventoryStdCosst { get; set; }

        [Required]
        [Display(Name = "List Price")]
        [DisplayFormat(DataFormatString = "{0:$#.##}")]
        public Decimal InventoryListPrice { get; set; }

        //m-1 composition type diameter
        public virtual InventoryComposition InventoryComposition { get; set; }

        public virtual InventoryType InventoryType { get; set; }

        public virtual InventoryDiameter InventoryDiameter { get; set; }

        //Dat
        // Inventory vs Sale Order
        public virtual List<ReservationSaleOrderInventory> ReservationSaleOrderInventories { get; set; }

        // Inventory vs Sale
        public virtual List<OutflowSaleInventory> OutflowSaleInventories { get; set; }

        // Inventory vs Purchase Order
        public virtual List<ReservationPurchaseOrderInventory> ReservationPurchaseOrderInventories { get; set; }
        
        // Inventory vs Purchase
        public virtual List<InflowPurchaseInventory> InflowPurchaseInventories { get; set; }

    }
}
