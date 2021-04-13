using ITInventory.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITInventory.Areas.Setup.Controllers
{
    [AllowAnonymous]
    [Area("Setup")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index()
        {
            _context.FirstRun.FirstOrDefault(e => e.ID == "firstrun").IsFirstRun = false;
            _context.SaveChanges();

            if (!_context.FirstRun.FirstOrDefault().SetupCompleted)
            {
                if (_context.FirstRun.FirstOrDefault().SetupStep == 0)
                    return View();
                else if (_context.FirstRun.FirstOrDefault().SetupStep == 1)
                    return RedirectToAction("RegisterFirstRun", "Account", new { area = "Identity" });
                else if (_context.FirstRun.FirstOrDefault().SetupStep == 2)
                    return RedirectToAction("Index", "Home", new { area = "SiteSettings" });
                else
                    return RedirectToAction("Index", "Home", new { area = "" });
            }
            else
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
        }
        public IActionResult IncrementStep()
        {
            _context.FirstRun.FirstOrDefault(e => e.ID == "firstrun").SetupStep = _context.FirstRun.FirstOrDefault(e => e.ID == "firstrun").SetupStep + 1;
            _context.SaveChanges();
            return RedirectToAction("Index", "Home", new { area = "Setup" });
        }
    }
}
