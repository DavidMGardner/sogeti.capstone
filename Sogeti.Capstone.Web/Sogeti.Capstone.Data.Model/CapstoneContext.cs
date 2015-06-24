using System.Data.Entity;

namespace Sogeti.Capstone.Data.Model
{
    public class CapstoneContext : DbContext
    {
        public CapstoneContext() : base() { }
        public CapstoneContext(string connectionString) : base(connectionString) { }
        
        public DbSet<Event> Events { get; set; }
        public DbSet<EventType> EventType { get; set; }
    }
}