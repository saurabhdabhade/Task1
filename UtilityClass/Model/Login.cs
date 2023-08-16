using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryClass.Model
{
    public class Login
    {
        [Key]
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
