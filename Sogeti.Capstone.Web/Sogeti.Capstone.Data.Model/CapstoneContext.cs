using System.Data.Entity;

namespace Sogeti.Capstone.Data.Model
{
    public class CapstoneContext : DbContext
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<EventType> EventType { get; set; } 
    }
}