using System.ComponentModel.DataAnnotations;

namespace MVCApplication.Models.ViewModel
{
    public class RegisterViewModel
    {
        public int RegisterID { get; set; }

        [MaxLength(30)]
        [Required]
        public string First_Name { get; set; }

        [MaxLength(30)]
        [Required]
        public string Last_Name { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email format.")]
        [EmailAddress]
        [StringLength(30)]
        [Required]
        public string Email { get; set; }

        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [Required]
        public string Password { get; set; }

        [Required]
        public string Confirm_Password { get; set; }
    }
}
