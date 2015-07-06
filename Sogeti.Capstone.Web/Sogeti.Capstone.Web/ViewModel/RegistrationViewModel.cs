using System;

namespace Sogeti.Capstone.Web.ViewModel
{
    public class RegistrationViewModel
    {
        public string Title { get; set; }
        public DateTime RegisterDateTime { get; set; }

        public virtual EventViewModel Event { get; set; }
        public virtual EventTypeViewModel EventType { get; set; }
    }
}