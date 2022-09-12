using System;
namespace DeveloperTest.Models
{
    public class UserAccountForUpdateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
    }
}

