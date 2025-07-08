using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace quizweb.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(100, ErrorMessage = "Full name cannot be longer than 100 characters.")]
        public string FullName { get; set; } = null!;

        [Required]
        public DateOnly BirthDay { get; set; }

        public bool Sex { get; set; }
    }
}
