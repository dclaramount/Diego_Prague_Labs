using System;
using System.Net.NetworkInformation;
using DeveloperTest.Entities;
using Microsoft.EntityFrameworkCore;

namespace DeveloperTest.DbContexts
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {

        }
        public DbSet<UserType> UserTypes { get; set; } = null!;
        public DbSet<Item> Item { get; set; } = null!;
        public DbSet<UserAccount> UserAccount { get; set; } = null!;
        public DbSet<InvoiceLine> InvoiceLines { get; set; } = null!;
        public DbSet<Invoice> Invoice { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Seeding Data for User Type
            modelBuilder.Entity<UserType>().HasData(
                new UserType("VIP Customer")
                {
                    Id = 1
                },
                new UserType("Regular Customer")
                {
                    Id = 2
                },
                new UserType("Bad Credit Customer")
                {
                    Id = 3
                },
                new UserType("Other")
                {
                    Id = 4
                });
            #endregion

            #region Seeding Data for Items
            modelBuilder.Entity<Item>().HasData(
                new Item("Milk (1 Lt)")
                {
                    Id = 1,
                    UnitPrice = 1,
                    Currency = "USD"
                },
                new Item("Eggs (Package of 5)")
                {
                    Id = 2,
                    UnitPrice = 0.60,
                    Currency = "USD"
                },
                new Item("Beans (1Kg)")
                {
                    Id = 3,
                    UnitPrice = 1.50,
                    Currency = "USD"
                },
                new Item("Butter (500g)")
                {
                    Id = 4,
                    UnitPrice = 0.50,
                    Currency = "USD"
                },
                new Item("Coffee (250g)")
                {
                    Id = 5,
                    UnitPrice = 12.50,
                    Currency = "USD"
                },
                new Item("Orange Juice (1 lt)")
                {
                    Id = 6,
                    UnitPrice = 2.50,
                    Currency = "USD"
                },
                new Item("Bacon (500g)")
                {
                    Id = 7,
                    UnitPrice = 2.25,
                    Currency = "USD"
                },
                new Item("Ham (500g)")
                {
                    Id = 8,
                    UnitPrice = 1.75,
                    Currency = "USD"
                },
                new Item("Bread (500g)")
                {
                    Id = 9,
                    UnitPrice = 2.25,
                    Currency = "USD"
                },
                new Item("Sugar (500g)")
                {
                    Id = 10,
                    UnitPrice = 1.15,
                    Currency = "USD"
                });
            #endregion

            #region Seeding Data for User Accounts
            modelBuilder.Entity<UserAccount>().HasData(
                new UserAccount("Diego", "Claramount")
                {
                    Id = 1,
                    UserTypeId = 1,
                    PhoneNumber = "+420-775642233",
                    Email = "diegoaclaramount@gmail.com"
                },
                new UserAccount("Frankie", "Jones")
                {
                    Id = 2,
                    UserTypeId = 2,
                    Email = "frankie@gmail.com"
                },
                new UserAccount("Andrea", "Ruiz")
                {
                    Id = 3,
                    UserTypeId = 1,
                },
                new UserAccount("Jorge", "Campos")
                {
                    Id = 4,
                    UserTypeId = 3,
                    PhoneNumber = "+473-723-1433",
                    Email = "jorge_campos@gmail.com"
                },
                new UserAccount("Rafael", "Carranza")
                {
                    Id = 5,
                    UserTypeId = 3,
                    PhoneNumber = "+420-723-1433",
                    Email = "rcarranza@gmail.com"
                },
                new UserAccount("David", "Villareal")
                {
                    Id = 6,
                    UserTypeId = 4,
                    Email = "dvillareal@gmail.com"
                });
            #endregion

            #region Seeding Data for Invoices
            modelBuilder.Entity<Invoice>().HasData(
                new Invoice()
                {
                    Id = 1,
                    UserAccountId = 1,
                    Status = "Paid"
                },
                new Invoice()
                {
                    Id = 2,
                    UserAccountId = 2,
                    Status = "Unpaid"
                },
                new Invoice()
                {
                    Id = 3,
                    UserAccountId = 2,
                    Status = "Unpaid"
                },
                new Invoice()
                {
                    Id = 4,
                    UserAccountId = 3,
                    Status = "Paid"
                },
                new Invoice()
                {
                    Id = 5,
                    UserAccountId = 3,
                    Status = "Unpaid"
                },
                new Invoice()
                {
                    Id = 6,
                    UserAccountId = 3,
                    Status = "Paid"
                },
                new Invoice()
                {
                    Id = 7,
                    UserAccountId = 4,
                    Status = "Unpaid"
                },
                new Invoice()
                {
                    Id = 8,
                    UserAccountId = 4,
                    Status = "Unpaid"
                },
                new Invoice()
                {
                    Id = 9,
                    UserAccountId = 4,
                    Status = "Unpaid"
                },
                new Invoice()
                {
                    Id = 10,
                    UserAccountId = 4,
                    Status = "Paid"
                },
                new Invoice()
                {
                    Id = 11,
                    UserAccountId = 5,
                    Status = "Paid"
                },
                new Invoice()
                {
                    Id = 12,
                    UserAccountId = 5,
                    Status = "Paid"
                },
                new Invoice()
                {
                    Id = 13,
                    UserAccountId = 5,
                    Status = "Unpaid"
                },
                new Invoice()
                {
                    Id = 14,
                    UserAccountId = 5,
                    Status = "Unpaid"
                },
                new Invoice()
                {
                    Id = 15,
                    UserAccountId = 5,
                    Status = "Unpaid"
                },
                new Invoice()
                {
                    Id = 16,
                    Status = "Unpaid"
                });
            #endregion

            #region Seeding Data of Invoice Lines
            modelBuilder.Entity<InvoiceLine>().HasData(
            #region Invoice 1
            new InvoiceLine()
            {
                Id              = 1,
                InvoiceId       = 1,
                ItemId          = 9,
                Quantity        = 1,
            },
            new InvoiceLine()
            {
                Id              = 2,
                InvoiceId       = 1,
                ItemId          = 10,
                Quantity        = 2,
            },
            new InvoiceLine()
            {
                Id              = 3,
                InvoiceId       = 1,
                ItemId          = 1,
                Quantity        = 1,
            },
            #endregion

            #region Invoice 2
            new InvoiceLine()
            {
                Id              = 4,
                InvoiceId       = 2,
                ItemId          = 1,
                Quantity        = 2,
            },
            new InvoiceLine()
            {
                Id              = 5,
                InvoiceId       = 2,
                ItemId          = 3,
                Quantity        = 1,
            },
            new InvoiceLine()
            {
                Id              = 6,
                InvoiceId       = 2,
                ItemId          = 4,
                Quantity        = 1,
            },
            #endregion

            #region Invoice 3
            new InvoiceLine()
            {
                Id              = 7,
                InvoiceId       = 3,
                ItemId          = 3,
                Quantity        = 2,
            },
            new InvoiceLine()
            {
                Id              = 8,
                InvoiceId       = 3,
                ItemId          = 5,
                Quantity        = 1,
            },
            new InvoiceLine()
            {
                Id              = 9,
                InvoiceId       = 3,
                ItemId          = 7,
                Quantity        = 1,
            },
            #endregion

            #region Invoice 4
            new InvoiceLine()
            {
                Id              = 10,
                InvoiceId       = 4,
                ItemId          = 2,
                Quantity        = 2,
            },
            new InvoiceLine()
            {
                Id              = 11,
                InvoiceId       = 4,
                ItemId          = 6,
                Quantity        = 1,
            },
            new InvoiceLine()
            {
                Id              = 12,
                InvoiceId       = 4,
                ItemId          = 10,
                Quantity        = 1,
            },
            #endregion

            #region Invoice 5
            new InvoiceLine()
            {
                Id              = 13,
                InvoiceId       = 5,
                ItemId          = 1,
                Quantity        = 1,
            },
            new InvoiceLine()
            {
                Id              = 14,
                InvoiceId       = 5,
                ItemId          = 3,
                Quantity        = 1,
            },
            new InvoiceLine()
            {
                Id              = 15,
                InvoiceId       = 5,
                ItemId          = 9,
                Quantity        = 1,
            },
            #endregion

            #region Invoice 6
            new InvoiceLine()
            {
                Id              = 16,
                InvoiceId       = 6,
                ItemId          = 5,
                Quantity        = 10,
            },
            #endregion

            #region Invoice 7
            new InvoiceLine()
            {
                Id              = 17,
                InvoiceId       = 7,
                ItemId          = 7,
                Quantity        = 5,
            },
            #endregion

            #region Invoice 8
            new InvoiceLine()
            {
                Id              = 18,
                InvoiceId       = 8,
                ItemId          = 1,
                Quantity        = 15,
            },
            #endregion

            #region Invoice 9
            new InvoiceLine()
            {
                Id              = 19,
                InvoiceId       = 9,
                ItemId          = 2,
                Quantity        = 5,
            },
            #endregion

            #region Invoice 10
            new InvoiceLine()
            {
                Id              = 20,
                InvoiceId       = 10,
                ItemId          = 8,
                Quantity        = 13,
            },
            #endregion

            #region Invoice 11
            new InvoiceLine()
            {
                Id              = 21,
                InvoiceId       = 11,
                ItemId          = 3,
                Quantity        = 21,
            },
            #endregion

            #region Invoice 12
            new InvoiceLine()
            {
                Id              = 22,
                InvoiceId       = 12,
                ItemId          = 5,
                Quantity        = 7,
            },
            #endregion

            #region Invoice 13
            new InvoiceLine()
            {
                Id              = 23,
                InvoiceId       = 13,
                ItemId          = 6,
                Quantity        = 18,
            },
            #endregion

            #region Invoice 14
            new InvoiceLine()
            {
                Id              = 24,
                InvoiceId       = 14,
                ItemId          = 7,
                Quantity        = 12,
            },
            #endregion

            #region Invoice 15
            new InvoiceLine()
            {
                Id              = 25,
                InvoiceId       = 15,
                ItemId          = 1,
                Quantity        = 2,
            },
            new InvoiceLine()
            {
                Id              = 26,
                InvoiceId       = 15,
                ItemId          = 3,
                Quantity        = 3,
            },
            #endregion

            #region Invoice 16
            new InvoiceLine()
            {
                Id              = 27,
                InvoiceId       = 16,
                ItemId          = 3,
                Quantity        = 1,
            }
            #endregion

            );
            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }

}

