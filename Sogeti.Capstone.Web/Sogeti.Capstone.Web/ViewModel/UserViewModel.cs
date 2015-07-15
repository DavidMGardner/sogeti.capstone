using System.ComponentModel.DataAnnotations;

namespace Sogeti.Capstone.Web.ViewModel
{
    public class UserViewModel : BaseEntityViewModel
    {
        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [DataType(DataType.Text)]
        public string AddressLineOne { get; set; }

        [DataType(DataType.Text)]
        public string AddressLineTwo { get; set; }

        [DataType(DataType.Text)]
        public string City { get; set; }

        [DataType(DataType.Text)]
        public string State { get; set; }

        [DataType(DataType.PostalCode)]
        public string ZipCode { get; set; }

        [DataType(DataType.PhoneNumber)]
        public int PrimaryPhone { get; set; }

        [DataType(DataType.Text)]
        public string CompanyName { get; set; }

        [DataType(DataType.Text)]
        public string BranchName { get; set; }

        [DataType(DataType.MultilineText)]
        public string AdditionalInfo { get; set; }

        public FoodTypeViewModel FoodPreference { get; set; }
    }

    public class RegisterUserViewModel : UserViewModel
    {
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}