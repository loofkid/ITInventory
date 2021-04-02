using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITInventory.Models
{
    public class ReceiptModel
    {
        public string DocumentID { get; set; }
        public byte[] FileData { get; set; }
        public string Name { get; set; }
    }
}
