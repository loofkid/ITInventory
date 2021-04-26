using ITInventory.Data;
using ITInventory.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace ITInventory.Areas.Inventory.Controllers
{
    [Authorize(Roles = "SuperAdmin,Admin,Technician")]
    [Area("Inventory")]
    public class InventoryController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<User> _userManager;
        
        public InventoryController(IHttpContextAccessor httpContextAccessor, UserManager<User> userManager, ApplicationDbContext applicationDbContext)
        {
            _httpContextAccessor = httpContextAccessor;
            _applicationDbContext = applicationDbContext;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AddHardwareItem()
        {
            var model = new HardwareItem();
            model = (await PrepareComboBoxesAsync(model)) as HardwareItem;
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditHardwareItem(string hardwareItemId)
        {
            HardwareItem hardwareItem = await _applicationDbContext.HardwareItems
                .Include(h => h.Receipts)
                .Include(h => h.CheckOuts)
                .AsQueryable()
                .SingleOrDefaultAsync(h => h.InventoryId == hardwareItemId);
            hardwareItem = (await PrepareComboBoxesAsync(hardwareItem)) as HardwareItem;
            return View(hardwareItem);
        }
        [HttpPost]
        public async Task<IActionResult> EditHardwareItem(HardwareItem hardwareItem)
        {
            hardwareItem = (await PrepareComboBoxesAsync(hardwareItem)) as HardwareItem;
            return View(hardwareItem);
        }

        [HttpPost]
        public async Task<IActionResult> AddHardwareItem(HardwareItem hardwareItem)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                var category = new Category()
                {
                    Name = hardwareItem.Category.Name,
                    User = user,
                    LastUsed = DateTime.Now.Date
                };
                var model = new ItemModel()
                {
                    Name = hardwareItem.Model.Name,
                    User = user,
                    LastUsed = DateTime.Now.Date
                };
                var manufacturer = new Manufacturer()
                {
                    Name = hardwareItem.Manufacturer.Name,
                    User = user,
                    LastUsed = DateTime.Now.Date
                };
                var physicalLocation = new PhysicalLocation()
                {
                    Name = hardwareItem.PhysicalLocation.Name,
                    User = user,
                    LastUsed = DateTime.Now.Date
                };

                var dbCategory = await _applicationDbContext.Categories
                    .ToAsyncEnumerable()
                    .SingleOrDefaultAsync(c => c.Name == category.Name && c.User == category.User);
                var dbModel = await _applicationDbContext.ItemModels
                    .ToAsyncEnumerable()
                    .SingleOrDefaultAsync(c => c.Name == model.Name && c.User == model.User);
                var dbManufacturer = await _applicationDbContext.Manufacturers
                    .ToAsyncEnumerable()
                    .SingleOrDefaultAsync(c => c.Name == manufacturer.Name && c.User == manufacturer.User);
                var dbPhysicalLocation = await _applicationDbContext.PhysicalLocations
                    .ToAsyncEnumerable()
                    .SingleOrDefaultAsync(c => c.Name == physicalLocation.Name && c.User == physicalLocation.User);

                if (dbCategory == null)
                    dbCategory = (await _applicationDbContext.Categories.AddAsync(category)).Entity;
                else
                {
                    dbCategory.Update(category);
                    dbCategory.Uses++;
                    _applicationDbContext.Entry(dbCategory).State = EntityState.Modified;
                }

                if (dbModel == null)
                    dbModel = (await _applicationDbContext.ItemModels.AddAsync(model)).Entity;
                else
                {
                    dbModel.Update(model);
                    dbModel.Uses++;
                    _applicationDbContext.Entry(dbModel).State = EntityState.Modified;
                }

                if (dbManufacturer == null)
                    dbManufacturer = (await _applicationDbContext.Manufacturers.AddAsync(manufacturer)).Entity;
                else
                {
                    dbManufacturer.Update(manufacturer);
                    dbManufacturer.Uses++;
                    _applicationDbContext.Entry(dbManufacturer).State = EntityState.Modified;
                }

                if (dbPhysicalLocation == null)
                    dbPhysicalLocation = (await _applicationDbContext.PhysicalLocations.AddAsync(physicalLocation)).Entity;
                else
                {
                    dbPhysicalLocation.Update(physicalLocation);
                    dbPhysicalLocation.Uses++;
                    _applicationDbContext.Entry(dbPhysicalLocation).State = EntityState.Modified;
                }
                await _applicationDbContext.SaveChangesAsync();

                if (hardwareItem.ReceiptFiles != null && hardwareItem.ReceiptFiles.Count() > 0)
                {
                    var receipts = await hardwareItem.ReceiptFiles
                        .ToAsyncEnumerable()
                        .SelectAwait(async h => await GetReceiptAsBytes(h))
                        .ToListAsync();
                    hardwareItem.Receipts = receipts; 
                }

                hardwareItem.Category = null;
                hardwareItem.Model = null;
                hardwareItem.Manufacturer = null;
                hardwareItem.PhysicalLocation = null;

                var inventoryItems = _applicationDbContext.HardwareItems;
                hardwareItem = (await inventoryItems.AddAsync(hardwareItem)).Entity;
                //await _applicationDbContext.SaveChangesAsync();

                hardwareItem.Category = dbCategory;
                hardwareItem.Model = dbModel;
                hardwareItem.Manufacturer = dbManufacturer;
                hardwareItem.PhysicalLocation = dbPhysicalLocation;

                await _applicationDbContext.SaveChangesAsync(); 
            }

            hardwareItem = (await PrepareComboBoxesAsync(hardwareItem)) as HardwareItem;

            return View(hardwareItem);
            //return RedirectToAction("EditHardwareItem", new { hardwareItem = hardwareItem });
        }
        //[HttpPost]
        //public async Task<IActionResult> AddReceipts(IFormFile[] receipts, string InventoryId)
        //{
        //    var asyncReceipts = receipts.ToAsyncEnumerable();

        //    while (!(await _applicationDbContext.InventoryItems.AsQueryable().AnyAsync(i => i.InventoryId == InventoryId)))
        //    {
        //        await Task.Delay(100);
        //    }

        //    var inventoryItem = await _applicationDbContext.InventoryItems.AsQueryable()
        //                                                            .FirstOrDefaultAsync(i => i.InventoryId == InventoryId);
        //    var receiptList = new List<Receipt>();
        //    await asyncReceipts.ForEachAsync(async r =>
        //    {
        //        receiptList.Add(await GetReceiptAsBytes(r));
        //    });

        //    receiptList.ForEach(r =>
        //    {
        //        r.InventoryItems.Add(inventoryItem);
        //    });
        //    inventoryItem.Receipts.AddRange(receiptList);
        //    await _applicationDbContext.SaveChangesAsync();

        //    return Ok();
        //}

        private async Task<Receipt> GetReceiptAsBytes(IFormFile receipt)
        {
            var fullReceipt = new Receipt();
            fullReceipt.Name = receipt.FileName;
            fullReceipt.FileType = receipt.ContentType;
            using (var memoryStream = new MemoryStream())
            {
                await receipt.CopyToAsync(memoryStream);
                fullReceipt.FileData = memoryStream.ToArray();
            }

            return fullReceipt;
        }

        private async Task<InventoryItem> PrepareComboBoxesAsync(InventoryItem item)
        {
            item.Categories = await _applicationDbContext.Categories
                .ToAsyncEnumerable()
                .OrderByDescendingAwait(async c => await c.GetWeight(_httpContextAccessor, _userManager))
                .ToListAsync();
            item.Manufacturers = await _applicationDbContext.Manufacturers
                .ToAsyncEnumerable()
                .OrderByDescendingAwait(async c => await c.GetWeight(_httpContextAccessor, _userManager))
                .ToListAsync();
            if (item is HardwareItem)
                (item as HardwareItem).Models = await _applicationDbContext.ItemModels
                    .ToAsyncEnumerable()
                    .OrderByDescendingAwait(async c => await c.GetWeight(_httpContextAccessor, _userManager))
                    .ToListAsync();
            if (item is HardwareItem)
                (item as HardwareItem).PhysicalLocations = await _applicationDbContext.PhysicalLocations
                    .ToAsyncEnumerable()
                    .OrderByDescendingAwait(async c => await c.GetWeight(_httpContextAccessor, _userManager))
                    .ToListAsync();
            return item;
        }
    }
}
