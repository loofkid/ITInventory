using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ITInventory.Models
{
    public class Receipt
    {
        public int DocumentID { get; set; }
        [JsonIgnore]
        public byte[] FileData { get; set; }
        [JsonIgnore]
        public string FileType { get; set; }
        public string Name { get; set; }
        [DisplayName("Date Added")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DateAdded { get; set; }
        [JsonIgnore]
        public List<InventoryItem> InventoryItems { get; set; }
        public string GetAsJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
