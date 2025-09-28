using System.ComponentModel.DataAnnotations;

namespace quizweb.ViewModels
{
    public class UserEditViewModel
    {
        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; } = null!;

        [Required]
        [Display(Name = "Full Name")]
        public string Fullname { get; set; } = null!;

        [Display(Name = "Birthday")]
        public DateOnly Birthday { get; set; }

        [Display(Name = "Sex")]
        public bool Sex { get; set; }
        
        [Display(Name = "Email")]
        public string Email { get; set; } = null!;
    }
}
