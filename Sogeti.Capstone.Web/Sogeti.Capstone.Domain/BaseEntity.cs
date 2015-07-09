using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sogeti.Capstone.Domain
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
    }
}
