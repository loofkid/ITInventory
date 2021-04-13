using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ITInventory.Models
{
    public abstract class InventoryItem
    {
        [DisplayName("ID")]
        public int InventoryId { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Category { get; set; }
        [DisplayName("Date of Purchase")]
        public DateTime DateOfPurchase { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Cost { get; set; }
        [DisplayName("Support Expiration Date")]
        public DateTime? SupportExpiration { get; set; }
        [DisplayName("Renew Support?")]
        public bool RenewSupport { get; set; } = false;
        public string Notes { get; set; }
        public List<Receipt> Receipts { get; set; }
    }
}
