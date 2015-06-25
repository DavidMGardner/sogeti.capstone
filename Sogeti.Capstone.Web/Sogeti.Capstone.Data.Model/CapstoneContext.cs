using System.Data.Entity;
using System.Security.Cryptography.X509Certificates;

namespace Sogeti.Capstone.Data.Model
{
    public class CapstoneContext : DbContext
    {
        DatabaseDataDeleter dataDeleter;

        public CapstoneContext() : base()
        {
            Database.SetInitializer<CapstoneContext>(new CreateDatabaseIfNotExists<CapstoneContext>());
            dataDeleter = new DatabaseDataDeleter(this);
        }

        public CapstoneContext(string connectionString) : base(connectionString)
        {
            Database.SetInitializer<CapstoneContext>(new CreateDatabaseIfNotExists<CapstoneContext>());
            dataDeleter = new DatabaseDataDeleter(this);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<EventType> EventType { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<Status> Statuses { get; set; }

        public void RemoveAllDbSetDataDatabase()
        {
            RemoveDbSetData(Events);
            RemoveDbSetData(EventType);
            RemoveDbSetData(Category);
            RemoveDbSetData(Registrations);
            RemoveDbSetData(Statuses);
            SaveChanges();

            dataDeleter.DeleteAllObjects();
        }


        public void RemoveDbSetDataDatabase(DbSet set)
        {
            RemoveDbSetData(set);

            SaveChanges();

            dataDeleter.DeleteAllObjects();
        }

        private void RemoveDbSetData(DbSet set)
        {
            foreach (var @entity in set)
            {
                set.Remove(@entity);
            }
        }
    }
}