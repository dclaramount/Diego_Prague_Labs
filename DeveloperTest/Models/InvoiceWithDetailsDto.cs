using System;
namespace DeveloperTest.Models
{
    /// <summary>
    /// A DTO of an Invoice with the Breakdown of
    /// Item Lines
    /// </summary>
    public class InvoiceWithDetailsDto
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

