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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Configurations.Add(new CatalogTypeConfiguration());
            //modelBuilder.Configurations.Add(new SupplierTypeConfiguration());
            //modelBuilder.Configurations.Add(new ManufacturerTypeConfiguration());
            //modelBuilder.Configurations.Add(new MemberGroupTypeConfiguration());

            //modelBuilder.Configurations.Add(new MemberItemTypeConfiguration());
            //modelBuilder.Configurations.Add(new ItemMemberTypeConfiguration());

            //modelBuilder.Configurations.Add(new ItemTypeConfiguration());
            //modelBuilder.Configurations.Add(new SellerTypeConfiguration());
            //modelBuilder.Configurations.Add(new ItemCatalogMapTypeConfiguration());
            //modelBuilder.Configurations.Add(new ItemSpecificationTypeConfiguration());
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<EventType> EventType { get; set; }
    }
}