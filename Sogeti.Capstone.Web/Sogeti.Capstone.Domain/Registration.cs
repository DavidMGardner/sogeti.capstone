using System;

namespace Sogeti.Capstone.Domain
{
    public class Registration : BaseEntity
    {
        public string Title { get; set; }
        public DateTime RegisterDateTime { get; set; }

        public virtual Event Event { get; set; }
        public virtual EventType EventType { get; set; }
    }
}