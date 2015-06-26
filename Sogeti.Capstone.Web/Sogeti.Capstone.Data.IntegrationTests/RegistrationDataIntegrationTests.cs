using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using NUnit.Framework;
using Shouldly;
using Sogeti.Capstone.Data.Model;

namespace Sogeti.Capstone.Data.IntegrationTests
{
    [TestFixture]
    public class RegistrationDataIntegrationTests
    {
        private static readonly CapstoneContext Context = new CapstoneContext("Sogeti.Capstone.Data.Model.CapstoneContext");

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
        public void Add_Registration_With_Defaults()
        {
            //arrange
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
            var newRegistration = new Registration()
            {
                Event = newEvent,
                EventType = new EventType(),
                RegisterDateTime = DateTime.Now,
                Title = "A title",
            };

            //act
            Context.Registrations.Add(newRegistration);
            Context.SaveChanges();

            //assert
            int rowCount = Context.Registrations.Count();
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
            Context.Events.Add(newEvent);
            var newRegistration = new Registration()
            {
                Event = newEvent,
                EventType = new EventType(),
                RegisterDateTime = DateTime.Now,
                Title = "A title",
            };

            // act
            Context.Registrations.Add(newRegistration);
            Context.SaveChanges();

            // assert
            Context.Registrations.First().Id.ShouldBe(1);
        }

        [Test]
        public void Delete_Registration()
        {
            //arrange
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
            var newRegistration = new Registration()
            {
                Event = newEvent,
                EventType = new EventType(),
                RegisterDateTime = DateTime.Now,
                Title = "A title",
            };

            //act
            Context.Registrations.Add(newRegistration);
            Context.SaveChanges();

            Context.Registrations.Remove(newRegistration);
            Context.SaveChanges();

            //assert
            int rowCount = Context.Registrations.Count();
            rowCount.ShouldBe(0);
        }

        [Test]
        public void Update_Registration_From_Defaults()
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

            var newRegistration = new Registration()
            {
                Event = newEvent,
                EventType = new EventType(),
                RegisterDateTime = DateTime.Now,
                Title = "A title",
            };

            //act
            Context.Registrations.Add(newRegistration);
            Context.SaveChanges();

            Registration oldRegistration = Context.Registrations.First(r => r.Title == "A title");
            var oldId = oldRegistration.Id;

            oldRegistration.Title =  "New Title";
            oldRegistration.RegisterDateTime = new DateTime(2015, 4, 28);

            Context.Entry(oldRegistration).State = EntityState.Modified;
            Context.SaveChanges();

            //assert
            Registration modifiedRegistration = Context.Registrations.Find(oldId);
            modifiedRegistration.Title.ShouldBe("New Title");
            modifiedRegistration.RegisterDateTime.ShouldBe(new DateTime(2015, 4, 28));
        }
#endregion

    }
}