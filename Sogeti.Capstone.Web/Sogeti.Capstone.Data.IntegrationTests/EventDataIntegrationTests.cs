using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using NUnit.Framework;
using Shouldly;
using Sogeti.Capstone.Data.Model;

namespace Sogeti.Capstone.Data.IntegrationTests
{
    [TestFixture]
    public class EventDataIntegrationTests
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
        public void Add_Event_With_Defaults()
        {
            // arrange
            var newEvent = new Event
            {
                Title = "Sample Event",
                Description = "Sample Event Description",
                StartDateTime = DateTime.Now,
                EndDateTime = DateTime.Now.AddHours(1),
                Category = new Category(),
                Registrations = new List<Registration>(),
                EventType = new EventType(),
                Status = new Status(),
                LocationInformation = "At some new location",
                LogoPath = "http://google/someimage",
            };

            // act
            Context.Events.Add(newEvent);
            Context.SaveChanges();

            //assert
            int rowCount = Context.Events.Count();
            rowCount.ShouldBeGreaterThan(0);
        }

        [Test]
        public void Should_Populate_ID()
        {
            // arrange
            var newEvent = new Event
            {
                Title = "Sample Event",
                Description = "Sample Event Description",
                StartDateTime = DateTime.Now,
                EndDateTime = DateTime.Now.AddHours(1),
                Category = new Category(),
                Registrations = new List<Registration>(),
                EventType = new EventType(),
                Status = new Status(),
                LocationInformation = "At some new location",
                LogoPath = "http://google/someimage",
            };

            // act
            Context.Events.Add(newEvent);
            Context.SaveChanges();

            //assert
            Context.Events.First().Id.ShouldBe(1);
        }

        [Test]
        public void Add_Event_With_ForeignKeys()
        {
            // arrange
            var newEventType = new EventType();

            Context.EventType.Add(newEventType);
            Context.SaveChanges();

            var newEvent = new Event
            {
                Title = "Sample Event",
                Description = "Sample Event Description",
                StartDateTime = DateTime.Now,
                EndDateTime = DateTime.Now.AddHours(1),
                Category = new Category(),
                Registrations = new List<Registration>(),
                EventType = newEventType,
                Status = new Status(),
                LocationInformation = "At some new location",
                LogoPath = "http://google/someimage",
            };

            // act
            Context.Events.Add(newEvent);
            Context.SaveChanges();

            //assert
            Context.Events.Count().ShouldBeGreaterThan(0);
            Context.Events.Find(1).ShouldBe(newEvent);
            Context.Events.Find(1).EventType.ShouldBe(newEventType);
        }

        [Test]
        public void Update_Event_From_Defaults()
        {
            // arrange
            var newEvent = new Event
            {
                Title = "Sample Event",
                Description = "Sample Event Description",
                StartDateTime = DateTime.Now,
                EndDateTime = DateTime.Now.AddHours(1),
                Category = new Category(),
                Registrations = new List<Registration>(),
                EventType = new EventType(),
                Status = new Status(),
                LocationInformation = "At some new location",
                LogoPath = "http://google/someimage",
            };

            Context.Events.Add(newEvent);
            Context.SaveChanges();

            Event oldEvent = Context.Events.First(e => e.Title == "Sample Event");
            oldEvent.Title = "New Title";
            oldEvent.Description = "New Description";
            oldEvent.StartDateTime = new DateTime(2015, 4, 28);
            oldEvent.EndDateTime = new DateTime(2015, 4, 28);
            oldEvent.LocationInformation = "none";
            oldEvent.LogoPath = "http://fake/image";

            var oldId = oldEvent.Id;

            //act
            Context.Entry(oldEvent).State = EntityState.Modified;
            Context.SaveChanges();

            //assert
            Event modifiedEvent = Context.Events.Find(oldId);
            modifiedEvent.Title.ShouldBe("New Title");
            modifiedEvent.Description.ShouldBe("New Description");
            modifiedEvent.StartDateTime.ShouldBe(new DateTime(2015, 4, 28));
            modifiedEvent.EndDateTime.ShouldBe(new DateTime(2015, 4, 28));
            modifiedEvent.LocationInformation.ShouldBe("none");
            modifiedEvent.LogoPath.ShouldBe("http://fake/image");
        }

        [Test]
        public void Delete_Event_From_Defaults()
        {
            // arrange
            var newEvent = new Event
            {
                Title = "Sample Event",
                Description = "Sample Event Description",
                StartDateTime = DateTime.Now,
                EndDateTime = DateTime.Now.AddHours(1),
                Category = new Category(),
                Registrations = new List<Registration>(),
                EventType = new EventType(),
                Status = new Status(),
                LocationInformation = "At some new location",
                LogoPath = "http://google/someimage",
            };

            // act
            Context.Events.Add(newEvent);
            Context.SaveChanges();

            //act
            Context.Events.Remove(newEvent);
            Context.SaveChanges();

            //assert
            Context.Events.Count().ShouldBe(0);
        }

        #endregion
    }
}