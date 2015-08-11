using System.Data.Entity;
using System.Security.Cryptography.X509Certificates;

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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<EventType> EventType { get; set; }
        public DbSet<RegistrationType> Category { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<FoodType> FoodType { get; set; }

    }
}