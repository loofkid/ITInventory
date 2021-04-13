using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ITInventory.Models
{
    public class HardwareItem : InventoryItem
    {
        [DisplayName("Serial Number")]
        public string SerialNumber { get; set; }
        public string Model { get; set; }
        [DisplayName("Warranty Expiration Date")]
        public DateTime? WarrantyExpiration { get; set; }
        [DisplayName("Physical Location")]
        public string PhysicalLocation { get; set; }
        [DisplayName("Can Take Home")]
        public bool CanTakeHome { get; set; }
        [DisplayName("Requires Approval")]
        public bool RequiresApproval { get; set; }
        public List<CheckOut> CheckOuts { get; set; }
    }
}
