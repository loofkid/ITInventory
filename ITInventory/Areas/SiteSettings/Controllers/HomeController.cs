using ITInventory.Data;
using ITInventory.Areas.SiteSettings.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.IO;
using ITInventory.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace ITInventory.Areas.SiteSettings.Controllers
{
    [Area("SiteSettings")]
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Setup()
        {
            var siteSettings = _context.SiteSettings.Include(s => s.SiteLogo).FirstOrDefault(s => s.SiteID == -1);
            return View(siteSettings);
        }
        [HttpPost]
        public IActionResult SaveSettingsSetup(SiteSettingsModel siteSettings)
        {
            var siteLogo = siteSettings.SiteLogoUpload;
            if (siteLogo != null && siteLogo.Length > 0)
            {
                siteSettings.SiteLogo = new Image
                {
                    ImageName = "logo",
                    ImageData = GetImage(siteLogo),
                    DataType = siteLogo.ContentType
                };
            }
            siteSettings.SiteID = 1;
            _context.SiteSettings.Update(siteSettings);
            _context.SaveChanges();
            return RedirectToAction("IncrementStep", "Home", new { area = "Setup" });
        }
        private byte[] GetImage(IFormFile image)
        {
            byte[] byteImage;
            using (var fileStream = image.OpenReadStream())
            using (var memoryStream = new MemoryStream())
            {
                fileStream.CopyTo(memoryStream);
                byteImage = memoryStream.ToArray();
            }
            return byteImage;
        }
    }
}
