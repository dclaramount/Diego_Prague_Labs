using System;
using DeveloperTest.Models;

namespace DeveloperTest.Models
{
    /// <summary>
    /// A DTO of an Invoice with its Details and the User Account
    /// </summary>
    public class InvoiceWithDetailsAndUserAccountDto
    {
        /// <summary>
        /// The id of an Invoice
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The Payment Status of an Invoice
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// The User Account of the Invoice
        /// </summary>
        public UserAccountDto UserAccount { get; set; }
        /// <summary>
        /// List of Items Billed in the Invoice
        /// </summary>
        public ICollection<InvoiceLineDto> InvoiceLines { get; set; } = new List<InvoiceLineDto>();
        /// <summary>
        /// Total of the Invoice
        /// </summary>
        public double Total
        {
            get
            {
                return InvoiceLines.Sum(invoiceItem => invoiceItem.SubTotal);
            }
        }
    }
}