using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Sogeti.Capstone.Data.Model
{
    public class Event : BaseEntity
    {
        public string Title { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string Description { get; set; }
        public string LogoPath { get; set; }
        public string LocationInformation { get; set; }

        public virtual Category Category { get; set; }
        public virtual List<Registration> Registrations { get; set; }
        public virtual EventType EventType { get; set; }
        public virtual Status Status { get; set; }
    }
}
