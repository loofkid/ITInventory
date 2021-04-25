using ITInventory.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITInventory.ViewComponents
{
    public class LogoViewComponent : ViewComponent
    {
        private ApplicationDbContext _context;
        public LogoViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var siteSettings = await _context.SiteSettings.AsQueryable().Include(s => s.SiteLogo).FirstOrDefaultAsync();
            ViewBag.HasLogo = false;
            if (siteSettings.SiteLogo != null)
            {
                var logoID = siteSettings.SiteLogo.ImageID;
                ViewBag.HasLogo = true;
                ViewBag.ImageID = logoID;
                return View();
            }
            else
            {
                return View();
            }
        }
    }
}
