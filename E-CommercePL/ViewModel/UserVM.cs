using System.ComponentModel.DataAnnotations;

namespace E_CommercePL.ViewModel
{
    public class UserVM
    {
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }
        public string Email { get; set; }
        public string RoleName { get; set; }
    }
}
