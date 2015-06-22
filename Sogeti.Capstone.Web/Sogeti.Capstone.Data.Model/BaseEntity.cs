using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Sogeti.Capstone.Data.Model
{
    public class BaseEntity
    {
        [Key]
        public string Id { get; set; }
    }
}
