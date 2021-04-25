using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITInventory.Models
{
    public class Image
    {
        public int ImageID { get; set; }
        public string ImageName { get; set; }
        public byte[] ImageData { get; set; }
        public string DataType { get; set; }
    }
}
