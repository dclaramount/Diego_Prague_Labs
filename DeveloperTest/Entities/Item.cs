using System;
namespace DeveloperTest.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public double UnitPrice { get; set; }
        public string Currency { get; set; }

        public Item (string description)
        {
            Description = description;
        }
    }
}

