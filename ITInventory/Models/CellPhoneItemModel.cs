﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ITInventory.Models
{
    public class CellPhoneItemModel : HardwareItemModel
    {
        [DisplayName("IMEI")]
        public string IMEINumber { get; set; }
    }
}
