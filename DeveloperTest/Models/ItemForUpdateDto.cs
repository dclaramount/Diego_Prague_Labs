using System;
namespace DeveloperTest.Models
{
    public class ItemForUpdateDto
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

