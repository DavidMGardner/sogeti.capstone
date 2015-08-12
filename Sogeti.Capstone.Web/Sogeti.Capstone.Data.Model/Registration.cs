using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sogeti.Capstone.Data.Model
{
    public class Registration : BaseEntity
    {
        public string Title { get; set; }
        public DateTime RegisterDateTime { get; set; }

        public virtual Event Event { get; set; }
        public virtual EventType EventType { get; set; }
        public virtual FoodType FoodType { get; set; }
    }
}
