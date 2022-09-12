using System;
namespace DeveloperTest.Models
{
    public class InvoiceWithDetailsAndUserAccountForUpdateDto
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
        public UserAccountForUpdateDto UserAccount { get; set; }
        /// <summary>
        /// List of Items Billed in the Invoice
        /// </summary>
        public ICollection<InvoiceLineForUpdateDto> InvoiceLines { get; set; } = new List<InvoiceLineForUpdateDto>();

    }
}

