using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ITInventory.Models
{
    public abstract class InventoryItemModel
    {
        [DisplayName("ID")]
        public int InventoryId { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Category { get; set; }
        [DisplayName("Date of Purchase")]
        public DateTime DateOfPurchase { get; set; }
        public decimal Cost { get; set; }
        public string Notes { get; set; }
        public List<ReceiptModel> Receipts { get; set; }
        public CustomerModel Customer { get; set; }
    }
}
