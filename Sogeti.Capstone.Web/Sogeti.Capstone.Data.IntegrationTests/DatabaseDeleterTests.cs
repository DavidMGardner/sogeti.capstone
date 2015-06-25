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
        private static readonly CapstoneContext Context =
            new CapstoneContext("Sogeti.Capstone.Data.Model.CapstoneContext");

        #region SetUp

        [TestFixtureSetUp]
        public void Init()
        {
            IntegrationTestDatabaseInitalizer.AssemblyInit(Context);
        }

        [SetUp]
        public void TestInit()
        {
            Context.RemoveAllDbSetDataDatabase();
        }

        #endregion

        #region Tests

        [Test]
        public void Database_Tables_Deleted()
        {
            //arrange

            //act
            Context.RemoveAllDbSetDataDatabase();

            //assert
            Context.Database.ShouldBeOfType<Database>();
        }

        [Test]
        public void Database_Delete_PendingAdd()
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

            //act
            Context.Events.Add(newEvent);
            Context.SaveChanges();

            Context.RemoveDbSetDataDatabase(Context.Events);

            //assert
            Context.Events.Count().ShouldBe(0);
        }


        [Test]
        public void AutoIncrement_Reset()
        {
            //arrange
            var newEventType = new EventType()
            {
            };

            //act
            Context.EventType.Add(newEventType);
            Context.EventType.Add(newEventType);
            Context.EventType.Add(newEventType);
            Context.SaveChanges();

            Context.RemoveDbSetDataDatabase(Context.EventType);

            Context.EventType.Add(newEventType);
            Context.SaveChanges();

            //assert
            Context.EventType.Count().ShouldBe(1);
            Context.EventType.First().Id.ShouldBe(1);
        }

        [Test]
        public async void Database_Data_Deleted()
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

            //act
            Context.Events.Add(newEvent);
            Context.SaveChanges();

            Context.RemoveAllDbSetDataDatabase();

            //assert
            Context.Events.Count().ShouldBe(0);
        }

        #endregion
    }
}