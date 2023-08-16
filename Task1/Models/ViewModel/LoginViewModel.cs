using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MVCApplication.Models.ViewModel
{
    public class LoginViewModel
    {
        public int LoginID { get; set; }

        [ForeignKey("Email")]
        [Required]
        public string Email { get; set; }

        [ForeignKey("Password")]
        [Required]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
