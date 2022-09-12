using System;
using DeveloperTest.DbContexts;
using DeveloperTest.Entities;
using Microsoft.EntityFrameworkCore;

namespace DeveloperTest.Services
{
    public class StoreRepository : IStoreRepository
    {
        public readonly StoreContext _context;

        public StoreRepository(StoreContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _context.Database.EnsureCreated();
        }
        /// <summary>
        /// Returns a list of Invoices based on the filter status requested
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Invoice>> GetInvoicesAsync(string status="")
        {
            if (status != "")
            {
                return await _context.Invoice.Include("UserAccount")
                                        .Include("UserAccount.UserType")
                                        .Include("InvoiceLines")
                                        .Include("InvoiceLines.Item")
                                        .Where(inv=> inv.Status==status)
                                        .OrderBy(i => i.Id)
                                        .ToListAsync();
            }
            else
            {
                return await _context.Invoice.Include("UserAccount")
                            .Include("UserAccount.UserType")
                            .Include("InvoiceLines")
                            .Include("InvoiceLines.Item")
                            .OrderBy(i => i.Id)
                            .ToListAsync();
            }
        }
        /// <summary>
        /// Returns an Specific Invoice by Invoice Id
        /// </summary>
        /// <param name="invoiceId"></param>
        /// <returns></returns>
        public async Task<Invoice?> GetInvoiceAsync(int invoiceId)
        {
            return await _context.Invoice.Where(inv => inv.Id == invoiceId)
                                        .Include("UserAccount")
                                        .Include("UserAccount.UserType")
                                        .Include("InvoiceLines")
                                        .Include("InvoiceLines.Item").FirstOrDefaultAsync();
        }
        /// <summary>
        /// Returns an Specific User Account by User Account Id
        /// </summary>
        /// <param name="userAccountId"></param>
        /// <returns></returns>
        public async Task<UserAccount?> GetUserAccountAsync(int userAccountId)
        {
            return await _context.UserAccount.Where(ua => ua.Id == userAccountId)
                                                .FirstOrDefaultAsync();
        }
        /// <summary>
        /// Returns an Specific Invoice Line from Data Base based on the Invoice Line Id
        /// </summary>
        /// <param name="invoiceLineId"></param>
        /// <returns></returns>
        public async Task<InvoiceLine?> GetInvoiceLineAsync(int invoiceLineId)
        {
            return await _context.InvoiceLines.Where(il => il.Id == invoiceLineId)
                                                .Include("Item")
                                                .FirstOrDefaultAsync();
        }
        /// <summary>
        /// Returns an Specific Item from Data Base based on the Item Id
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public async Task<Item?> GetItemAsync(int itemId)
        {
            return await _context.Item.Where(it => it.Id == itemId)
                                                .FirstOrDefaultAsync();
        }
        /// <summary>
        /// Verifies if an Invoice Exist
        /// </summary>
        /// <param name="invoiceId"></param>
        /// <returns></returns>
        public async Task<bool> InvoiceExist(int invoiceId)
        {
            return await _context.Invoice.AnyAsync(inv => inv.Id == invoiceId);
        }
        /// <summary>
        /// Verifies if a User Account Exist
        /// </summary>
        /// <param name="userAccountId">User Account Id</param>
        /// <returns></returns>
        public async Task<bool> UserAccountExist(int userAccountId)
        {
            return await _context.UserAccount.AnyAsync(ua => ua.Id == userAccountId);
        }

        /// <summary>
        /// Verifies if an Invoice Line Exist
        /// </summary>
        /// <param name="invoiceLineId">Invoice Line Id</param>
        /// <returns></returns>
        public async Task<bool> InvoiceLineExist(int invoiceLineId)
        {
            return await _context.InvoiceLines.AnyAsync(il => il.Id == invoiceLineId);
        }

        /// <summary>
        /// Verifies if an Item Exist
        /// </summary>
        /// <param name="itemId">Item Id</param>
        /// <returns></returns>
        public async Task<bool> ItemExist(int itemId)
        {
            return await _context.UserAccount.AnyAsync(it => it.Id == itemId);
        }

        /// <summary>
        /// Saves Changes to the Data Base
        /// </summary>
        /// <returns></returns>
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }


}

