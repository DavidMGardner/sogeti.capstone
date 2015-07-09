using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sogeti.Capstone.Domain
{
    public class Event
    {
        public string Title { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string Description { get; set; }
        public string LogoPath { get; set; }
        public string LocationInformation { get; set; }

        public virtual RegistrationType RegistrationType { get; set; }
        public virtual List<Registration> Registrations { get; set; }
        public virtual EventType EventType { get; set; }
        public virtual Status Status { get; set; }
    }
}
