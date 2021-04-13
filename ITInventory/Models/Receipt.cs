using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITInventory.Models
{
    public class Receipt
    {
        public int DocumentID { get; set; }
        public byte[] FileData { get; set; }
        public string Name { get; set; }
        public InventoryItem Item { get; set; }
    }
}
