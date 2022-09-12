using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeveloperTest.Entities
{
    public class UserAccount
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }

        [ForeignKey("UserTypeId")]
        public UserType UserType { get; set; }
        public int UserTypeId { get; set; }

        public UserAccount(string firstName, string lastName)
        {
            FirstName   = firstName;
            LastName    = lastName;
        }
    }
}

