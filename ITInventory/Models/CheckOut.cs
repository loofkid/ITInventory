using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ITInventory.Models
{
    public class CheckOut
    {
        public HardwareItem Item { get; set; }
        [Display(Name = "Inventory ID")]
        public int InventoryID { get; set; }

        public Customer Customer { get; set; }
        public Technician Technician { get; set; }
        public bool Approved { get; set; }
        public User Approver { get; set; }
        [Display(Name = "Check Out Time")]
        public DateTime CheckOutTime { get; set; }
        [Display(Name = "Return Time")]
        public DateTime? ReturnTime { get; set; }
    }
}
