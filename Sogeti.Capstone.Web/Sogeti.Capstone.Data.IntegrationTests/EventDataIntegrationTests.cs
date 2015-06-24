using System;
using System.Data.Entity;
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
                Id = 1,
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
    }
}
