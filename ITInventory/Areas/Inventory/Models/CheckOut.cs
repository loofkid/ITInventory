using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ITInventory.Models
{
    public class CheckOut
    {
        public HardwareItem Item { get; set; }
        [DisplayName("Inventory Number")]
        public string InventoryId { get; set; }
        public Customer Customer { get; set; }
        public string CustomerId { get; set; }
        public Technician Technician { get; set; }
        public bool Approved { get; set; }
        public User Approver { get; set; }
        [Display(Name = "Check Out Time")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime CheckOutTime { get; set; }
        [Display(Name = "Return Time")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? ReturnTime { get; set; }
    }
}
