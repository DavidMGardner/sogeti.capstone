using System.Data.Entity;

namespace Sogeti.Capstone.Data.Model
{
    public static class CapstoneContextExtension
    {
        public static void DeleteAllDbSetData(this CapstoneContext context)
        {
            var dataDeleter = new DatabaseDataDeleter(context);

            RemoveDbSetData(context.Events);
            RemoveDbSetData(context.EventType);
            RemoveDbSetData(context.Category);
            RemoveDbSetData(context.Registrations);
            RemoveDbSetData(context.Statuses);
            context.SaveChanges();

            dataDeleter.DeleteAllObjects();
        }

        public static void DeleteDataFromDbSet(this CapstoneContext context, DbSet set)
        {
            var dataDeleter = new DatabaseDataDeleter(context);

            RemoveDbSetData(set);
            context.SaveChanges();

            dataDeleter.DeleteAllObjects();
        }

        private static void RemoveDbSetData(DbSet set)
        {
            foreach (var @entity in set)
            {
                set.Remove(@entity);
            }
        }
    }
}
