using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITInventory.Areas.Setup.Models
{
    public class FirstRun
    {
        public string ID { get; set; }
        public bool IsFirstRun { get; set; }
        public bool SetupCompleted { get; set; }
        public int SetupStep { get; set; }
    }
}
