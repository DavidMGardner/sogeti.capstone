using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Data.SqlClient;
using NUnit.Framework;
using Shouldly;
using Sogeti.Capstone.Data.Model;
using EntityState = System.Data.Entity.EntityState;

namespace Sogeti.Capstone.Data.IntegrationTests
{
    [TestFixture]
    public class EventDataIntegrationTests
    {
        private static readonly CapstoneContext Context =
            new CapstoneContext("Sogeti.Capstone.Data.Model.CapstoneContext");

        private Event _sampleEvent;
        
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

            _sampleEvent = new Event
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
        }

        #endregion

        #region Tests

        [Test]
        public void Add_Event_With_Defaults()
        {
            // arrange

            // act
            Context.Events.Add(_sampleEvent);
            Context.SaveChanges();

            //assert
            int rowCount = Context.Events.Count();
            rowCount.ShouldBeGreaterThan(0);
        }

        [Test]
        public void Should_Populate_ID()
        {
            // arrange

            // act
            Context.Events.Add(_sampleEvent);
            Context.SaveChanges();

            //assert
            Context.Events.First().Id.ShouldBe(1);
        }

        [Test]
        public void Should_Not_Allow_Nulls()
        {
            // arrange
            Event defaultEvent = new Event();

            // act
            Context.Events.Add(defaultEvent);

            Should.Throw<DbUpdateException>(
                () =>
                {
                   Context.SaveChanges();
                });

            //clean up
            Context.Events.Local.Clear();
        }

        [Test]
        public void Should_Not_Allow_Duplicate_ID()
        {
            // arrange
            Context.Events.Add(_sampleEvent);
            Context.SaveChanges();

            Event duplicatEvent = new Event
            {
                Id = 1,
                Title = "Unique Event",
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
            Context.Events.Add(duplicatEvent);
            Context.SaveChanges();
            Event correctedDuplicateEvent = Context.Events.First(e => e.Title == "Unique Event");

            // assert
            correctedDuplicateEvent.Id.ShouldNotBe(1);
        }

        [Test]
        public void Add_Event_With_ForeignKeys()
        {
            // arrange
            var newEventType = new EventType()
            {
                Title = "new event"
            };

            Context.EventType.Add(newEventType);
            Context.SaveChanges();

            _sampleEvent.EventType = newEventType;

            // act
            Context.Events.Add(_sampleEvent);
            Context.SaveChanges();

            //assert
            Context.Events.Count().ShouldBeGreaterThan(0);
            Context.Events.Find(1).ShouldBe(_sampleEvent);
            Context.Events.Find(1).EventType.ShouldBe(newEventType);
        }

        [Test]
        public void Update_Event_From_Defaults()
        {
            // arrange
            Context.Events.Add(_sampleEvent);
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
            modifiedEvent.ShouldSatisfyAllConditions(
             () => modifiedEvent.Title.ShouldBe("New Title"),
             () => modifiedEvent.Description.ShouldBe("New Description"),
             () => modifiedEvent.StartDateTime.ShouldBe(new DateTime(2015, 4, 28)),
             () => modifiedEvent.EndDateTime.ShouldBe(new DateTime(2015, 4, 28)),
             () => modifiedEvent.LocationInformation.ShouldBe("none"),
             () => modifiedEvent.LogoPath.ShouldBe("http://fake/image")
            )
            ;
        }

        [Test]
        public void Delete_Event_From_Defaults()
        {
            // arrange

            // act
            Context.Events.Add(_sampleEvent);
            Context.SaveChanges();

            //act
            Context.Events.Remove(_sampleEvent);
            Context.SaveChanges();

            //assert
            Context.Events.Count().ShouldBe(0);
        }

        [Test]
        public void Add_Event_With_Existing_FK()
        {
            //arrange
            var newEventType = new EventType();

            Context.EventType.Add(newEventType);
            Context.SaveChanges();

            _sampleEvent.EventType = newEventType;

            //act
            Context.Events.Add(_sampleEvent);
            Context.SaveChanges();

            //assert
            Context.Events.Find(1).EventType.Id.ShouldBe(1);
        }

        [Test]
        public void Add_Event_With_Nonexistent_FK()
        {
            //arrange
            var newEventType = new EventType()
            {
                Title = "EventType Title"
            };

            _sampleEvent.EventType = newEventType;

            //act
            Context.Events.Add(_sampleEvent);
            Context.SaveChanges();

            //assert
            Context.EventType.ShouldContain(newEventType);
        }

        [Test]
        public void Add_Event_With_Wrong_Input()
        {
            //assert
            Should.Throw<SqlException>(
                () =>
                {
                    Context.Database.ExecuteSqlCommand(
                    "INSERT INTO dbo.Events (Title, StartDateTime, EndDateTime, Description, LogoPath," +
                    "LocationInformation, Category_Id, EventType_Id, Status_Id) VALUES (1," +
                    "'Not a DateTime', 'Really not a DateTime', 2, 4/20/2020," +
                    "3, 'FK_Cat', 'FK_EventType', 'FK_Status')");
                });

        }

        #endregion
    }
}