using System;
using System.Data.Entity;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Shouldly;
using Sogeti.Capstone.Data.Model;

namespace Sogeti.Capstone.Data.IntegrationTests
{
    [TestFixture]
    public class DatabaseDeleterTests
    {
        private static readonly CapstoneContext Context = new CapstoneContext("Sogeti.Capstone.Data.Model.CapstoneContext");

        [TestFixtureSetUp]
        public void Init()
        {
            IntegrationTestDatabaseInitalizer.AssemblyInit(Context);
        }

        [Test]
        public void Database_Tables_Deleted()
        {
            //arrange
            DatabaseDataDeleter dataDeleter = new DatabaseDataDeleter(Context);

            //act
            dataDeleter.DeleteAllObjects();

            //assert
            Context.Database.ShouldBeOfType<Database>();
        }

        [Test]
        public void AutoIncrement_Reset()
        {
            //arrange
            var newEventType = new EventType()
            {
                Id = 1
            };

            //act
            Context.EventType.Add(newEventType);
            Context.SaveChanges();

            DatabaseDataDeleter dataDeleter = new DatabaseDataDeleter(Context);
            dataDeleter.DeleteAllObjects();
            Context.SaveChanges();

            Context.EventType.Add(newEventType);
            Context.SaveChanges();

            Context.EventType.First().Id.ShouldBe(1);

            dataDeleter.DeleteAllObjects();
        }

        [Test]
        public void Database_Data_Deleted()
        {
            //arrange
            var newEvent = new Event
            {
                Title = "Sample Event",
                Description = "Sample Event Description",
                StartDateTime = DateTime.Now,
                EndDateTime = DateTime.Now.AddHours(1),
                Category = new Category(),
                Registration = new Registration(),
                EventType = new EventType(),
                Status = new Status(),
                LocationInformation = "At some new location",
                LogoPath = "http://google/someimage",
            };

            Context.Events.Add(newEvent);
            Context.SaveChanges();

            DatabaseDataDeleter dataDeleter = new DatabaseDataDeleter(Context);

            //act
            dataDeleter.DeleteAllObjects();

            //assert
            Context.Events.Count().ShouldBe(0);
        }
    }
}
