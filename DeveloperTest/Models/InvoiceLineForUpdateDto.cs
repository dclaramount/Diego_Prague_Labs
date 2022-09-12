using System;
namespace DeveloperTest.Models
{
    public class InvoiceLineForUpdateDto
    {
        /// <summary> T
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
        public ItemForUpdateDto Item { get; set; } = new ItemForUpdateDto();
    }
}

