﻿// <auto-generated />
using System;
using ITInventory.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ITInventory.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210416215800_add inventoryitem to receipts")]
    partial class addinventoryitemtoreceipts
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Inventory")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ITInventory.Areas.Setup.Models.FirstRun", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsFirstRun")
                        .HasColumnType("bit");

                    b.Property<bool>("SetupCompleted")
                        .HasColumnType("bit");

                    b.Property<int>("SetupStep")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("FirstRun", "Setup");

                    b.HasData(
                        new
                        {
                            ID = "firstrun",
                            IsFirstRun = true,
                            SetupCompleted = false,
                            SetupStep = 0
                        });
                });

            modelBuilder.Entity("ITInventory.Areas.SiteSettings.Models.SiteSettingsModel", b =>
                {
                    b.Property<int>("SiteID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SiteColorPrimary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SiteColorSecondary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SiteLogoImageID")
                        .HasColumnType("int");

                    b.HasKey("SiteID");

                    b.HasIndex("SiteLogoImageID");

                    b.ToTable("SiteSettings", "Settings");

                    b.HasData(
                        new
                        {
                            SiteID = -1,
                            SiteColorPrimary = "#0275d8",
                            SiteColorSecondary = "#6C757D"
                        });
                });

            modelBuilder.Entity("ITInventory.Models.CheckOut", b =>
                {
                    b.Property<DateTime>("CheckOutTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("InventoryId")
                        .HasColumnType("int");

                    b.Property<string>("CustomerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Approved")
                        .HasColumnType("bit");

                    b.Property<string>("ApproverId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("HardwareItemInventoryId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ReturnTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("TechnicianId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CheckOutTime", "InventoryId", "CustomerId");

                    b.HasIndex("ApproverId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("HardwareItemInventoryId");

                    b.HasIndex("InventoryId");

                    b.HasIndex("TechnicianId");

                    b.ToTable("CheckOutRecords");
                });

            modelBuilder.Entity("ITInventory.Models.Image", b =>
                {
                    b.Property<int>("ImageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DataType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("ImageData")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("ImageName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ImageID");

                    b.ToTable("Images", "Content");
                });

            modelBuilder.Entity("ITInventory.Models.InventoryItem", b =>
                {
                    b.Property<int>("InventoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CategoryUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Cost")
                        .HasColumnType("money");

                    b.Property<string>("CustomerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DateOfPurchase")
                        .HasColumnType("datetime2");

                    b.Property<string>("ManufacturerName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ManufacturerUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("RenewSupport")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("SupportExpiration")
                        .HasColumnType("datetime2");

                    b.HasKey("InventoryId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("CategoryName", "CategoryUserId");

                    b.HasIndex("ManufacturerName", "ManufacturerUserId");

                    b.ToTable("InventoryItems");
                });

            modelBuilder.Entity("ITInventory.Models.Receipt", b =>
                {
                    b.Property<int>("DocumentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("FileData")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DocumentID");

                    b.ToTable("Receipts");
                });

            modelBuilder.Entity("ITInventory.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DisplayName")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("nvarchar(max)")
                        .HasComputedColumnSql("[FirstName] + ' ' + [LastName]");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("EmployeeID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("HasFinishedSetup")
                        .HasColumnType("bit");

                    b.Property<string>("JobTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("Users", "Identity");
                });

            modelBuilder.Entity("ITInventory.Models.WeightedComboBoxItem", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("LastUsed")
                        .HasColumnType("datetime2");

                    b.Property<int>("Uses")
                        .HasColumnType("int");

                    b.HasKey("Name", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("ComboBoxItems", "Metadata");
                });

            modelBuilder.Entity("InventoryItemReceipt", b =>
                {
                    b.Property<int>("InventoryItemsInventoryId")
                        .HasColumnType("int");

                    b.Property<int>("ReceiptsDocumentID")
                        .HasColumnType("int");

                    b.HasKey("InventoryItemsInventoryId", "ReceiptsDocumentID");

                    b.HasIndex("ReceiptsDocumentID");

                    b.ToTable("InventoryItemReceipt");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Role", "Identity");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaims", "Identity");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaims", "Identity");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogins", "Identity");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles", "Identity");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserTokens", "Identity");
                });

            modelBuilder.Entity("ITInventory.Models.HardwareItem", b =>
                {
                    b.HasBaseType("ITInventory.Models.InventoryItem");

                    b.Property<bool>("CanTakeHome")
                        .HasColumnType("bit");

                    b.Property<string>("ModelName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ModelUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PhysicalLocationName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PhysicalLocationUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("RequiresApproval")
                        .HasColumnType("bit");

                    b.Property<string>("SerialNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("WarrantyExpiration")
                        .HasColumnType("datetime2");

                    b.HasIndex("ModelName", "ModelUserId");

                    b.HasIndex("PhysicalLocationName", "PhysicalLocationUserId");

                    b.ToTable("HardwareItems");
                });

            modelBuilder.Entity("ITInventory.Models.SoftwareItem", b =>
                {
                    b.HasBaseType("ITInventory.Models.InventoryItem");

                    b.Property<string>("LicenseKey")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Physical")
                        .HasColumnType("bit");

                    b.Property<string>("SoftwareLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Subscription")
                        .HasColumnType("bit");

                    b.Property<decimal?>("SubscriptionCost")
                        .HasColumnType("money");

                    b.ToTable("SoftwareItems");
                });

            modelBuilder.Entity("ITInventory.Models.Customer", b =>
                {
                    b.HasBaseType("ITInventory.Models.User");

                    b.Property<string>("Department")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ManagerId")
                        .HasColumnType("nvarchar(450)");

                    b.HasIndex("ManagerId");

                    b.ToTable("Customers", "Identity");
                });

            modelBuilder.Entity("ITInventory.Models.Category", b =>
                {
                    b.HasBaseType("ITInventory.Models.WeightedComboBoxItem");

                    b.ToTable("Category", "Metadata");
                });

            modelBuilder.Entity("ITInventory.Models.ItemModel", b =>
                {
                    b.HasBaseType("ITInventory.Models.WeightedComboBoxItem");

                    b.ToTable("ItemModel", "Metadata");
                });

            modelBuilder.Entity("ITInventory.Models.Manufacturer", b =>
                {
                    b.HasBaseType("ITInventory.Models.WeightedComboBoxItem");

                    b.ToTable("Manufacturer", "Metadata");
                });

            modelBuilder.Entity("ITInventory.Models.PhysicalLocation", b =>
                {
                    b.HasBaseType("ITInventory.Models.WeightedComboBoxItem");

                    b.ToTable("PhysicalLocation", "Metadata");
                });

            modelBuilder.Entity("ITInventory.Models.CellPhoneItem", b =>
                {
                    b.HasBaseType("ITInventory.Models.HardwareItem");

                    b.Property<string>("IMEINumber")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("CellPhoneItems");
                });

            modelBuilder.Entity("ITInventory.Models.Technician", b =>
                {
                    b.HasBaseType("ITInventory.Models.Customer");

                    b.ToTable("Technicians", "Identity");
                });

            modelBuilder.Entity("ITInventory.Areas.SiteSettings.Models.SiteSettingsModel", b =>
                {
                    b.HasOne("ITInventory.Models.Image", "SiteLogo")
                        .WithMany()
                        .HasForeignKey("SiteLogoImageID");

                    b.Navigation("SiteLogo");
                });

            modelBuilder.Entity("ITInventory.Models.CheckOut", b =>
                {
                    b.HasOne("ITInventory.Models.User", "Approver")
                        .WithMany()
                        .HasForeignKey("ApproverId");

                    b.HasOne("ITInventory.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ITInventory.Models.HardwareItem", null)
                        .WithMany("CheckOuts")
                        .HasForeignKey("HardwareItemInventoryId");

                    b.HasOne("ITInventory.Models.HardwareItem", "Item")
                        .WithMany()
                        .HasForeignKey("InventoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ITInventory.Models.Technician", "Technician")
                        .WithMany()
                        .HasForeignKey("TechnicianId");

                    b.Navigation("Approver");

                    b.Navigation("Customer");

                    b.Navigation("Item");

                    b.Navigation("Technician");
                });

            modelBuilder.Entity("ITInventory.Models.InventoryItem", b =>
                {
                    b.HasOne("ITInventory.Models.Customer", null)
                        .WithMany("Items")
                        .HasForeignKey("CustomerId");

                    b.HasOne("ITInventory.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryName", "CategoryUserId");

                    b.HasOne("ITInventory.Models.Manufacturer", "Manufacturer")
                        .WithMany()
                        .HasForeignKey("ManufacturerName", "ManufacturerUserId");

                    b.Navigation("Category");

                    b.Navigation("Manufacturer");
                });

            modelBuilder.Entity("ITInventory.Models.WeightedComboBoxItem", b =>
                {
                    b.HasOne("ITInventory.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("InventoryItemReceipt", b =>
                {
                    b.HasOne("ITInventory.Models.InventoryItem", null)
                        .WithMany()
                        .HasForeignKey("InventoryItemsInventoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ITInventory.Models.Receipt", null)
                        .WithMany()
                        .HasForeignKey("ReceiptsDocumentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ITInventory.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ITInventory.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ITInventory.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ITInventory.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ITInventory.Models.HardwareItem", b =>
                {
                    b.HasOne("ITInventory.Models.InventoryItem", null)
                        .WithOne()
                        .HasForeignKey("ITInventory.Models.HardwareItem", "InventoryId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("ITInventory.Models.ItemModel", "Model")
                        .WithMany()
                        .HasForeignKey("ModelName", "ModelUserId");

                    b.HasOne("ITInventory.Models.PhysicalLocation", "PhysicalLocation")
                        .WithMany()
                        .HasForeignKey("PhysicalLocationName", "PhysicalLocationUserId");

                    b.Navigation("Model");

                    b.Navigation("PhysicalLocation");
                });

            modelBuilder.Entity("ITInventory.Models.SoftwareItem", b =>
                {
                    b.HasOne("ITInventory.Models.InventoryItem", null)
                        .WithOne()
                        .HasForeignKey("ITInventory.Models.SoftwareItem", "InventoryId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ITInventory.Models.Customer", b =>
                {
                    b.HasOne("ITInventory.Models.User", null)
                        .WithOne()
                        .HasForeignKey("ITInventory.Models.Customer", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("ITInventory.Models.Customer", "Manager")
                        .WithMany()
                        .HasForeignKey("ManagerId");

                    b.Navigation("Manager");
                });

            modelBuilder.Entity("ITInventory.Models.Category", b =>
                {
                    b.HasOne("ITInventory.Models.WeightedComboBoxItem", null)
                        .WithOne()
                        .HasForeignKey("ITInventory.Models.Category", "Name", "UserId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ITInventory.Models.ItemModel", b =>
                {
                    b.HasOne("ITInventory.Models.WeightedComboBoxItem", null)
                        .WithOne()
                        .HasForeignKey("ITInventory.Models.ItemModel", "Name", "UserId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ITInventory.Models.Manufacturer", b =>
                {
                    b.HasOne("ITInventory.Models.WeightedComboBoxItem", null)
                        .WithOne()
                        .HasForeignKey("ITInventory.Models.Manufacturer", "Name", "UserId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ITInventory.Models.PhysicalLocation", b =>
                {
                    b.HasOne("ITInventory.Models.WeightedComboBoxItem", null)
                        .WithOne()
                        .HasForeignKey("ITInventory.Models.PhysicalLocation", "Name", "UserId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ITInventory.Models.CellPhoneItem", b =>
                {
                    b.HasOne("ITInventory.Models.HardwareItem", null)
                        .WithOne()
                        .HasForeignKey("ITInventory.Models.CellPhoneItem", "InventoryId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ITInventory.Models.Technician", b =>
                {
                    b.HasOne("ITInventory.Models.Customer", null)
                        .WithOne()
                        .HasForeignKey("ITInventory.Models.Technician", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ITInventory.Models.HardwareItem", b =>
                {
                    b.Navigation("CheckOuts");
                });

            modelBuilder.Entity("ITInventory.Models.Customer", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
