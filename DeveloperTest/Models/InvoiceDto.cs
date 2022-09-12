using System;
namespace DeveloperTest.Models
{
    /// <summary>
    /// A DTO for an Invoice without any in detail information
    /// </summary>
    public class InvoiceDto
    {
        /// <summary>
        /// The Payment Status of an Invoice
        /// </summary>
        public string Status { get; set; }
    }
}

