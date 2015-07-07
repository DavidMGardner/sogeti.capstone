using System;
using System.ComponentModel.DataAnnotations;
using Sogeti.Capstone.Data.Model;

namespace Sogeti.Capstone.Web.ViewModel
{
    public class EventViewModel : BaseEntityViewModel
    {
        [Required]
        [Display(Name = "Title")]
        [DataType(DataType.Text)]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Start Time")]
        [DataType(DataType.DateTime)]
        public DateTime StartDateTime { get; set; }

        [Required]
        [Display(Name = "End Time")]
        [DataType(DataType.DateTime)]
        public DateTime EndDateTime { get; set; }

        [Required]
        [Display(Name = "Location")]
        [DataType(DataType.Text)]
        public string LocationInformation { get; set; }

        [Required]
        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        [Display(Name = "LogoPath")]
        [DataType(DataType.Text)]
        public string LogoPath { get; set; }

    }
}