using System;
namespace DeveloperTest.Models
{
    /// <summary>
    /// A DTO of an Item from the Inventory
    /// </summary>
    public class ItemDto
    {
        /// <summary>
        /// Description of the Item (Including unit of Measure)
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// Price per Unit of Measure
        /// </summary>
        public double UnitPrice { get; set; }
        /// <summary>
        /// Currency of the Unit Price
        /// </summary>
        public string Currency { get; set; }

    }
}

