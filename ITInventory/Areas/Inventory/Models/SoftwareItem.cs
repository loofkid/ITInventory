using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ITInventory.Models
{
    public class SoftwareItem : InventoryItem
    {
        [DisplayName("License Key")]
        public string LicenseKey { get; set; }
        [DisplayName("Software Location")]
        public string SoftwareLocation { get; set; }
        public bool Physical { get; set; }
        [DisplayName("Subscription?")]
        public bool Subscription { get; set; }
        [DisplayName("Subscription Cost")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:C}")]
        public double? SubscriptionCost { get; set; }
    }
}
