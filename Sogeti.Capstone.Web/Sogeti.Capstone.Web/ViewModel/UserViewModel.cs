using System.ComponentModel.DataAnnotations;

namespace Sogeti.Capstone.Web.ViewModel
{
    public class UserViewModel : BaseEntityViewModel
    {
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        [DataType(DataType.Password)]
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
}