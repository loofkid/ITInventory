using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ITInventory.Models
{
    public class User : IdentityUser
    {
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DisplayName("Display Name")]
        public string DisplayName { get; private set; }
        [DisplayName("Job Title")]
        public string JobTitle { get; set; }
        [DisplayName("Employee ID")]
        public string EmployeeID { get; set; }
        public bool HasFinishedSetup { get; set; }
    }
}
