using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ITInventory.Models
{
    public class CustomerModel
    {
        public string Username { get; set; }
        [DisplayName("Email Address")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DisplayName("Display Name")]
        public string DisplayName { get; set; }
        public string Department { get; set; }
        public CustomerModel Manager { get; set; }
        public List<InventoryItemModel> Items { get; set; }
    }
}
