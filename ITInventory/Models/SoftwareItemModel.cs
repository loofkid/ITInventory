using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ITInventory.Models
{
    public class SoftwareItemModel : InventoryItemModel
    {
        [DisplayName("License Key")]
        public string LicenseKey { get; set; }
        [DisplayName("Software Location")]
        public string SoftwareLocation { get; set; }
        public bool Physical { get; set; }
        [DisplayName("Support Expiration Date")]
        public DateTime? SupportExpiration { get; set; }
    }
}
