using System.ComponentModel.DataAnnotations;

namespace Sogeti.Capstone.Web.ViewModel
{
    public class UserLoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}