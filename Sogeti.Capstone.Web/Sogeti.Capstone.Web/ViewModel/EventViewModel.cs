using System;
using System.ComponentModel.DataAnnotations;
using Sogeti.Capstone.Data.Model;

namespace Sogeti.Capstone.Web.ViewModel
{
    public class EventViewModel : BaseEntityViewModel
    {
        [Required(ErrorMessage = "A title is required")]
        [Display(Name = "Title")]
        [DataType(DataType.Text)]
        public string Title { get; set; }

        [Display(Name = "Event Type")]
        [DataType(DataType.Text)]
        public EventType EventType { get; set; }

        private DateTime _startDateTime = DateTime.MinValue;
        [Required(ErrorMessage = "A start date is required")]
        [Display(Name = "Start Time")]
        [DataType(DataType.DateTime)]
        public DateTime StartDateTime
        {
            get
            {
                return (_startDateTime == DateTime.MinValue) ? DateTime.Now : _startDateTime;
            }
            set
            {
                { _startDateTime = value; }
            }
        }

        private DateTime _endDateTime = DateTime.MaxValue;
        [Required(ErrorMessage = "An end date is required")]
        [Display(Name = "End Time")]
        [DataType(DataType.DateTime)]
        public DateTime EndDateTime
        {
            get
            {
                return (_endDateTime == DateTime.MaxValue) ? DateTime.Now.AddDays(1) : _endDateTime;
            }
            set
            {
                { _endDateTime = value; }
            }
        }

        [Required(ErrorMessage = "A location is required")]
        [Display(Name = "Location")]
        [DataType(DataType.Text)]
        public string LocationInformation { get; set; }

        [Required(ErrorMessage = "A description is required")]
        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required(ErrorMessage = "A logo path is required")]
        [Display(Name = "LogoPath")]
        [DataType(DataType.Url)]
        public string LogoPath { get; set; }

        [Display(Name = "Registration Type")]
        [DataType(DataType.Text)]
        public RegistrationType RegistrationType { get; set; }
    }
}