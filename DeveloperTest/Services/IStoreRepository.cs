using System;
using DeveloperTest.Entities;

namespace DeveloperTest.Services
{
    public interface IStoreRepository
    {
        Task<Invoice?> GetInvoiceAsync(int invoiceId);
        Task<UserAccount?> GetUserAccountAsync(int userAccountId);
        Task<InvoiceLine?> GetInvoiceLineAsync(int invoiceLineId);
        Task<Item?> GetItemAsync(int itemId);
        Task<IEnumerable<Invoice?>> GetInvoicesAsync(string status="");
        Task<bool> InvoiceExist(int invoiceId);
        Task<bool> UserAccountExist(int userAccountId);
        Task<bool> InvoiceLineExist(int invoiceLineId);
        Task<bool> ItemExist(int itemId);
        Task<bool> SaveChangesAsync();

    }
}

