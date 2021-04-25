using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ITInventory.Models
{
    public abstract class InventoryItem
    {
        [DisplayName("Inventory Number")]
        [Required]
        [RegularExpression(@"(\d+)", ErrorMessage = "Must be a number")]
        public string InventoryId { get; set; }
        public string Name { get; set; }
        [Required]
        public Manufacturer Manufacturer { get; set; }
        [DisplayName("Category")]
        [Required]
        public Category Category { get; set; }
        [DisplayName("Date of Purchase")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? DateOfPurchase { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:C}")]
        public decimal Cost { get; set; }
        [DisplayName("Support Expiration Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? SupportExpiration { get; set; }
        [DisplayName("Renew Support?")]
        public bool RenewSupport { get; set; } = false;
        public string Notes { get; set; }
        [DisplayName("Receipts")]
        [NotMapped]
        public List<IFormFile> ReceiptFiles { get; set; }
        public List<Receipt> Receipts { get; set; }


        [NotMapped]
        public List<Manufacturer> Manufacturers { get; set; }
        [NotMapped]
        public List<Category> Categories { get; set; }
    }
}