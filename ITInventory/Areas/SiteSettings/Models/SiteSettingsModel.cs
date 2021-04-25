using ITInventory.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ITInventory.Areas.SiteSettings.Models
{
    public class SiteSettingsModel
    {
        public int SiteID { get; set; }
        [DisplayName("Site Color - Primary")]
        public string SiteColorPrimary { get; set; }
        [DisplayName("Site Color - Secondary")]
        public string SiteColorSecondary { get; set; }
        public Image SiteLogo { get; set; }
        [NotMapped]
        [DisplayName("Site Logo")]
        public IFormFile SiteLogoUpload { get; set; }

    }
}
