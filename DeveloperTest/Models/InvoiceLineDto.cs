using System;
namespace DeveloperTest.Models
{
    /// <summary>
    /// A DTO representing one line of an Invoice
    /// </summary>
    public class InvoiceLineDto
    {
        /// <summary>
        /// Invoice Line Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Number of Items billed in the Invoice Line
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// ItemId in this Invoice Line
        /// </summary>
        public int ItemId { get; set; }
        /// <summary>
        /// A DTO of an Item from the Inventory
        /// </summary>
        public ItemDto Item { get; set; } = new ItemDto();
        /// <summary>
        /// SubTotal for the given Invoice Line
        /// </summary>
        public double SubTotal
        {
            get
            {
                return Item.UnitPrice * Quantity;
            }
        }
    }
}

