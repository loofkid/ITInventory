using ITInventory.Data;
using ITInventory.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;

namespace ITInventory.Controllers
{
    public class HomeController : Controller
    {
        // Backing fields
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<User> _userManager;
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Constructor for primary HomeController
        /// </summary>
        /// <param name="httpContextAccessor">Injected HttpContextAccessor</param>
        /// <param name="userManager">Injected UserManager for functions which require interacting with a User object</param>
        /// <param name="logger">Injected logger</param>
        /// <param name="context">Injected DbContext for SQL access</param>
        public HomeController(IHttpContextAccessor httpContextAccessor, UserManager<User> userManager, ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
            _context = context;
        }

        // Basic view method
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        /// <summary>
        /// This is your data method.
        /// DataTables will query this (HTTP GET) to fetch data to display.
        /// </summary>
        /// <param name="request">
        /// This represents your DataTables request.
        /// It's automatically binded using the default binder and settings.
        /// 
        /// You should use IDataTablesRequest as your model, to avoid unexpected behavior and allow
        /// custom binders to be attached whenever necessary.
        /// </param>
        /// <returns>
        /// Return data here, with a json-compatible result.
        /// </returns>
        [HttpPost]
        public async Task<IActionResult> GetHardwareItemsDataAsync(IDataTablesRequest request)
        {
            var user = (await _userManager.GetUserAsync(User)) as Customer;
            await _context.Entry(user).Reference(u => u.Items).LoadAsync();

            var data = await user.Items.AsQueryable().Where(i => i is HardwareItem).ToListAsync();

            var type = data.GetType().GetGenericArguments()[0];
            var properties = type.GetProperties();

            var filteredData = String.IsNullOrWhiteSpace(request.Search.Value)
                ? data
                : data.Where(h => properties
                        .Any(p =>
                        {
                            var value = p.GetValue(h);
                            return value != null && value.ToString().Contains(request.Search.Value);
                        }));

            var dataPage = filteredData.Skip(request.Start).Take(request.Length);

            var response = DataTablesResponse.Create(request, data.Count(), filteredData.Count(), dataPage);

            return new DataTablesJsonResult(response, true);
        }
        /// <summary>
         /// This is your data method.
         /// DataTables will query this (HTTP GET) to fetch data to display.
         /// </summary>
         /// <param name="request">
         /// This represents your DataTables request.
         /// It's automatically binded using the default binder and settings.
         /// 
         /// You should use IDataTablesRequest as your model, to avoid unexpected behavior and allow
         /// custom binders to be attached whenever necessary.
         /// </param>
         /// <returns>
         /// Return data here, with a json-compatible result.
         /// </returns>
        [HttpPost]
        public async Task<IActionResult> GetSoftwareItemsDataAsync(IDataTablesRequest request)
        {
            var user = (await _userManager.GetUserAsync(User)) as Customer;
            await _context.Entry(user).Reference(u => u.Items).LoadAsync();

            var data = await user.Items.AsQueryable().Where(i => i is SoftwareItem).ToListAsync();

            var type = data.GetType().GetGenericArguments()[0];
            var properties = type.GetProperties();

            var filteredData = String.IsNullOrWhiteSpace(request.Search.Value)
                ? data
                : data.Where(h => properties
                        .Any(p =>
                        {
                            var value = p.GetValue(h);
                            return value != null && value.ToString().Contains(request.Search.Value);
                        }));

            var dataPage = filteredData.Skip(request.Start).Take(request.Length);

            var response = DataTablesResponse.Create(request, data.Count(), filteredData.Count(), dataPage);

            return new DataTablesJsonResult(response, true);
        }


        /// <summary>
        /// Gets image from database
        /// </summary>
        /// <param name="imageID">Image ID of image record</param>
        /// <returns>Returns FileContentResult of image, ready to display in view.</returns>
        [AllowAnonymous]
        public async Task<IActionResult> GetImage(int imageID)
        {
            if (await _context.Images.AsAsyncEnumerable().AnyAsync(i => i.ImageID == imageID))
            {
                Image image = _context.Images.FirstOrDefault(i => i.ImageID == imageID);
                return File(image.ImageData, image.DataType);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
