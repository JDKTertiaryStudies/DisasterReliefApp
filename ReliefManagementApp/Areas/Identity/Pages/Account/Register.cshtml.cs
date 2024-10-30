using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ReliefManagementApp.Data;
using ReliefManagementApp.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ReliefManagementApp.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly AppDbContext _context;
        private readonly UserManager<User> _userManager;

        public RegisterModel(AppDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            public string Name { get; set; }

            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
            public string Password { get; set; }

            [DataType(DataType.PhoneNumber)]
            public string Phone { get; set; }

            [Required]
            public string Role { get; set; } = "User";  // Default to User
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                // Find the current max UserID and increment by 1
                var maxUserId = _context.Users.Max(u => (int?)u.UserID) ?? 0;
                var newUserId = maxUserId + 1;

                // Create a new user instance with the incremented UserID and normalized fields
                var user = new User
                {
                    UserID = newUserId,
                    Name = Input.Name,
                    Email = Input.Email,
                    NormalizedEmail = Input.Email.Trim().ToUpper(),
                    UserName = Input.Email,
                    NormalizedUserName = Input.Email.Trim().ToUpper(),
                    Phone = Input.Phone,
                    Role = Input.Role
                };

                // Use ASP.NET Identity's password hashing to store a hashed password
                var passwordResult = await _userManager.CreateAsync(user, Input.Password);

                if (passwordResult.Succeeded)
                {
                    TempData["SuccessMessage"] = "Registration successful! Please log in.";
                    return RedirectToPage("Login");
                }
                else
                {
                    // If password or user creation failed, display errors
                    foreach (var error in passwordResult.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }

            // If model state is invalid, reload the registration page with validation errors
            return Page();
        }
    }
}
