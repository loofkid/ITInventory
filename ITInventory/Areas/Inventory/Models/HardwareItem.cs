using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ITInventory.Models
{
    public class HardwareItem : InventoryItem
    {
        [DisplayName("Serial Number")]
        public string SerialNumber { get; set; }
        [DisplayName("Model")]
        [Required]
        public ItemModel Model { get; set; }
        [DisplayName("Warranty Expiration Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? WarrantyExpiration { get; set; }
        [DisplayName("Physical Location")]
        [Required]
        public PhysicalLocation PhysicalLocation { get; set; }
        [DisplayName("Can Take Home")]
        public bool CanTakeHome { get; set; }
        [DisplayName("Requires Approval")]
        public bool RequiresApproval { get; set; }
        public List<CheckOut> CheckOuts { get; set; }


        [NotMapped]
        public List<ItemModel> Models { get; set; }
        [NotMapped]
        public List<PhysicalLocation> PhysicalLocations { get; set; }
    }
}
