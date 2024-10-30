using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ReliefManagementApp.Models
{
    public class User : IdentityUser
    {
        public int UserID { get; set; }  // Assuming UserID is an integer

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }  // Storing password as string (e.g., Base64)

        public string Phone { get; set; }

        public string Role { get; set; } = "User";  // Default role
    }
}
