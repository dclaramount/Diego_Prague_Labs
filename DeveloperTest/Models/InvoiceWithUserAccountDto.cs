using System;
using DeveloperTest.Entities;

namespace DeveloperTest.Models
{
    /// <summary>
    /// A DTO of an Invoice with its User Account
    /// </summary>
    public class InvoiceWithUserAccountDto
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

    }
}

