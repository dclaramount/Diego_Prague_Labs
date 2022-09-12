using System;
namespace DeveloperTest.Models
{
    public class UserAccountDto
    {
        /// <summary>
        /// Id of User Account
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// First Name
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Last Name
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Phone Number
        /// </summary>
        public string? PhoneNumber { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public string? Email { get; set; }
    }
}

