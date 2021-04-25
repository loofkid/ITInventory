using ITInventory.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ITInventory.Areas.Setup.Models;
using System;
using System.Collections.Generic;
using System.Text;
using ITInventory.Areas.SiteSettings.Models;

namespace ITInventory.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema("Inventory");
            builder.Entity<User>(entity =>
            {
                entity.ToTable(name: "Users", schema: "Identity");
                entity.Property(u => u.DisplayName)
                    .HasComputedColumnSql("[FirstName] + ' ' + [LastName]");
            });
            //builder.Entity<Customer>(entity =>
            //{
            //    entity.ToTable(name: "Customers", schema: "Identity");
            //});
            //builder.Entity<Technician>(entity =>
            //{
            //    entity.ToTable(name: "Technicians", schema: "Identity");
            //});
            builder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Role", schema: "Identity");
            });
            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("UserRoles", "Identity");
            });
            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("UserClaims", "Identity");
            });
            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("UserLogins", "Identity");
            });
            builder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("RoleClaims", "Identity");
            });
            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("UserTokens", "Identity");
            });

            builder.Entity<FirstRun>(entity =>
            {
                entity.ToTable("FirstRun", "Setup");
                entity.HasKey(e => e.ID);
                entity.HasData(new FirstRun { ID = "firstrun", IsFirstRun = true, SetupCompleted = false, SetupStep = 0 });
            });

            builder.Entity<InventoryItem>(entity =>
            {
                entity.ToTable("InventoryItems");
                entity.HasKey(i => i.InventoryId);
                entity.Property(i => i.Cost)
                    .HasColumnType("money");
            });
            //builder.Entity<HardwareItem>(entity =>
            //{
            //    entity.ToTable("HardwareItems");
            //});
            builder.Entity<SoftwareItem>(entity =>
            {
                entity.Property(s => s.SubscriptionCost)
                    .HasColumnType("money");
            });
            //builder.Entity<CellPhoneItem>(entity => 
            //{
            //    entity.ToTable("CellPhoneItems");
            //});
            builder.Entity<CheckOut>(entity =>
            {
                entity.ToTable("CheckOutRecords");
                entity.HasKey(c => new { c.CheckOutTime, c.InventoryId, c.CustomerId });
                entity.HasOne(c => c.Item)
                      .WithMany()
                      .HasForeignKey(c => c.InventoryId);
                entity.HasOne(c => c.Customer)
                      .WithMany()
                      .HasForeignKey(c => c.CustomerId);
            });
            builder.Entity<Receipt>(entity =>
            {
                entity.ToTable("Receipts");
                entity.HasKey(r => r.DocumentID );
                entity.Property(r => r.DocumentID)
                    .ValueGeneratedOnAdd();
                entity.Property(r => r.FileData)
                    .HasColumnType("varbinary(MAX)");

            });
            builder.Entity<SiteSettingsModel>(entity =>
            {
                entity.ToTable("SiteSettings", "Settings");
                entity.HasKey(s => s.SiteID);
                entity.Property(s => s.SiteID)
                    .ValueGeneratedOnAdd();
                entity.HasData(new SiteSettingsModel { SiteID = -1, SiteColorPrimary = "#0275d8", SiteColorSecondary = "#6C757D" });
            });
            builder.Entity<Image>(entity =>
            {
                entity.ToTable("Images", "Content");
                entity.HasKey(i => i.ImageID);
                entity.Property(i => i.ImageID)
                    .ValueGeneratedOnAdd();
            });
            builder.Entity<WeightedComboBoxItem>(entity =>
            {
                entity.ToTable("ComboBoxItems", "Metadata");
                entity.HasKey(e => new { e.Name, e.UserId });
                entity.HasOne(m => m.User)
                      .WithMany()
                      .HasForeignKey(m => m.UserId);
                entity.Property(e => e.Uses)
                      .HasDefaultValue(1);
                entity.Property(e => e.LastUsed)
                      .HasDefaultValueSql("GETDATE()");
            });
            //builder.Entity<Manufacturer>(entity =>
            //{
            //    entity.ToTable("Manufacturer", "Metadata");

            //});
            //builder.Entity<Category>(entity =>
            //{
            //    entity.ToTable("Category", "Metadata");
            //});
            //builder.Entity<ItemModel>(entity =>
            //{
            //    entity.ToTable("ItemModel", "Metadata");
            //});
            //builder.Entity<PhysicalLocation>(entity =>
            //{
            //    entity.ToTable("PhysicalLocation", "Metadata");
            //});
        }
        /// <summary>
        /// First run database object - tells application whether to run first time setup
        /// </summary>
        public DbSet<FirstRun> FirstRun { get; set; }
        /// <summary>
        /// Customers database object
        /// </summary>
        public DbSet<Customer> Customers { get; set; }
        /// <summary>
        /// Technicians database object
        /// </summary>
        public DbSet<Technician> Technicians { get; set; }
        /// <summary>
        /// Inventory items database object
        /// </summary>
        public DbSet<InventoryItem> InventoryItems { get; set; }
        /// <summary>
        /// Hardware items database object
        /// </summary>
        public DbSet<HardwareItem> HardwareItems { get; set; }
        /// <summary>
        /// Software items database object
        /// </summary>
        public DbSet<SoftwareItem> SoftwareItems { get; set; }
        /// <summary>
        /// Cell phone items database object
        /// </summary>
        public DbSet<CellPhoneItem> CellPhoneItems { get; set; }
        /// <summary>
        /// Checkouts database object
        /// </summary>
        public DbSet<CheckOut> CheckOuts { get; set; }
        /// <summary>
        /// Receipts database object
        /// </summary>
        public DbSet<Receipt> Receipts { get; set; }
        /// <summary>
        /// Site settings database object - stores global site settings
        /// </summary>
        public DbSet<SiteSettingsModel> SiteSettings { get; set; }
        /// <summary>
        /// Images database object
        /// </summary>
        public DbSet<Image> Images { get; set; }
        /// <summary>
        /// Manufacturers database object
        /// </summary>
        public DbSet<Manufacturer> Manufacturers { get; set; }
        /// <summary>
        /// Categories database object
        /// </summary>
        public DbSet<Category> Categories { get; set; }
        /// <summary>
        /// ItemModels database object
        /// </summary>
        public DbSet<ItemModel> ItemModels { get; set; }
        /// <summary>
        /// PhysicalLocations database object
        /// </summary>
        public DbSet<PhysicalLocation> PhysicalLocations { get; set; }
    }
}