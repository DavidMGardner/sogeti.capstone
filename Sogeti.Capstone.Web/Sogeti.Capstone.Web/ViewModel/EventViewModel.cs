using System;

namespace Sogeti.Capstone.Web.ViewModel
{
    public class EventViewModel
    {
        public string Title { get; set; }
        public DateTime StartDateTime { get; set; }
        public string LocationInformation { get; set; }
        public DateTime EndDateTime { get; set; }
        public string Description { get; set; }
        public string LogoPath { get; set; }
    }
}