using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ITInventory.Models
{
    public class CustomerModel : UserModel
    {
        public string Department { get; set; }
        public CustomerModel Manager { get; set; }
        public List<InventoryItemModel> Items { get; set; }
    }
}
