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
    [Migration("20210405210452_hasfinishedsetup-nokey")]
    partial class hasfinishedsetupnokey
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
                    b.Property<bool>("IsFirstRun")
                        .HasColumnType("bit");

                    b.ToTable("FirstRun", "Setup");
                });

            modelBuilder.Entity("ITInventory.Models.CheckOut", b =>
                {
                    b.Property<int>("InventoryID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CheckOutTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Approved")
                        .HasColumnType("bit");

                    b.Property<string>("ApproverId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CustomerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("ItemInventoryId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ReturnTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("TechnicianId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("InventoryID", "CheckOutTime");

                    b.HasIndex("ApproverId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ItemInventoryId");

                    b.HasIndex("TechnicianId");

                    b.ToTable("CheckOutRecords");
                });

            modelBuilder.Entity("ITInventory.Models.InventoryItem", b =>
                {
                    b.Property<int>("InventoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Cost")
                        .HasColumnType("money");

                    b.Property<string>("CustomerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DateOfPurchase")
                        .HasColumnType("datetime2");

                    b.Property<string>("Manufacturer")
                        .HasColumnType("nvarchar(max)");

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

                    b.ToTable("InventoryItems");
                });

            modelBuilder.Entity("ITInventory.Models.Receipt", b =>
                {
                    b.Property<int>("DocumentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("FileData")
                        .HasColumnType("varbinary(max)");

                    b.Property<int?>("ItemInventoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DocumentID");

                    b.HasIndex("ItemInventoryId");

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
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhysicalLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("RequiresApproval")
                        .HasColumnType("bit");

                    b.Property<string>("SerialNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("WarrantyExpiration")
                        .HasColumnType("datetime2");

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

            modelBuilder.Entity("ITInventory.Models.CheckOut", b =>
                {
                    b.HasOne("ITInventory.Models.User", "Approver")
                        .WithMany()
                        .HasForeignKey("ApproverId");

                    b.HasOne("ITInventory.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.HasOne("ITInventory.Models.HardwareItem", "Item")
                        .WithMany("CheckOuts")
                        .HasForeignKey("ItemInventoryId");

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
                });

            modelBuilder.Entity("ITInventory.Models.Receipt", b =>
                {
                    b.HasOne("ITInventory.Models.InventoryItem", "Item")
                        .WithMany("Receipts")
                        .HasForeignKey("ItemInventoryId");

                    b.Navigation("Item");
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

            modelBuilder.Entity("ITInventory.Models.InventoryItem", b =>
                {
                    b.Navigation("Receipts");
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
