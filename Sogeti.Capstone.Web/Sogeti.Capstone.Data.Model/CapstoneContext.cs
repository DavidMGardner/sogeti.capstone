using System.Data.Entity;

namespace Sogeti.Capstone.Data.Model
{
    public class CapstoneContext : DbContext
    {
        public CapstoneContext() : base()
        {
            Database.SetInitializer<CapstoneContext>(new CreateDatabaseIfNotExists<CapstoneContext>());
        }

        public CapstoneContext(string connectionString) : base(connectionString)
        {
            Database.SetInitializer<CapstoneContext>(new CreateDatabaseIfNotExists<CapstoneContext>());
        }
        
        public DbSet<Event> Events { get; set; }
        public DbSet<EventType> EventType { get; set; }
    }
}