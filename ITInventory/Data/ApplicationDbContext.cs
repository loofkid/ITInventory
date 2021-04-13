using ITInventory.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ITInventory.Areas.Setup.Models;
using System;
using System.Collections.Generic;
using System.Text;

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
            });
            builder.Entity<Customer>(entity =>
            {
                entity.ToTable(name: "Customers", schema: "Identity");
            });
            builder.Entity<Technician>(entity =>
            {
                entity.ToTable(name: "Technicians", schema: "Identity");
            });
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
            builder.Entity<HardwareItem>(entity =>
            {
                entity.ToTable("HardwareItems");
            });
            builder.Entity<SoftwareItem>(entity =>
            {
                entity.ToTable("SoftwareItems");
                entity.Property(s => s.SubscriptionCost)
                    .HasColumnType("money");
            });
            builder.Entity<CellPhoneItem>(entity => 
            {
                entity.ToTable("CellPhoneItems");
            });
            builder.Entity<CheckOut>(entity =>
            {
                entity.ToTable("CheckOutRecords");
                entity.HasKey(c => new { c.InventoryID, c.CheckOutTime });
            });
            builder.Entity<Receipt>(entity =>
            {
                entity.ToTable("Receipts");
                entity.HasKey(r => r.DocumentID);
                entity.Property(r => r.DocumentID)
                    .ValueGeneratedOnAdd();
            });
        }

        public DbSet<FirstRun> FirstRun { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Technician> Technicians { get; set; }
        public DbSet<InventoryItem> InventoryItems { get; set; }
        public DbSet<HardwareItem> HardwareItems { get; set; }
        public DbSet<SoftwareItem> SoftwareItems { get; set; }
        public DbSet<CellPhoneItem> CellPhoneItems { get; set; }
        public DbSet<CheckOut> CheckOuts { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
    }
}