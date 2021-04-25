using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ITInventory.Models
{
    public class Receipt
    {
        public int DocumentID { get; set; }
        public byte[] FileData { get; set; }
        public string FileType { get; set; }
        public string Name { get; set; }
        [DisplayName("Date Added")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DateAdded { get; set; }
        public List<InventoryItem> InventoryItems { get; set; }
    }
}
