using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ITInventory.Models
{
    public class Customer : User
    {
        public string Department { get; set; }
        public Customer Manager { get; set; }
        public List<InventoryItem> Items { get; set; }
    }
}
