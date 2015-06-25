using System;
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
        private static readonly CapstoneContext Context = new CapstoneContext("Sogeti.Capstone.Data.Model.CapstoneContext");

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

        [TearDown]
        public void TestDispose()
        {
            Context.RemoveAllDbSetDataDatabase();
        }

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
                Registration = new Registration(),
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
                Registration = new Registration(),
                EventType = new EventType(),
                Status = new Status(),
                LocationInformation = "At some new location",
                LogoPath = "http://google/someimage",
            };

            Context.Events.Add(newEvent);
            Context.SaveChanges();

            Event oldEvent = Context.Events.First(e => e.Title == "Sample Event");
            oldEvent.Title = "New Title";
            var oldId = oldEvent.Id;

            //act
            Context.Entry(oldEvent).State = EntityState.Modified;
            Context.SaveChanges();

            //assert
            Event modifiedEvent = Context.Events.Find(oldId);
            modifiedEvent.Title.ShouldBe("New Title");
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
                Registration = new Registration(),
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
    }
}
