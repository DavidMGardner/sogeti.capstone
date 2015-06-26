using System.Linq;
using NUnit.Framework;
using Shouldly;
using Sogeti.Capstone.Data.Model;

namespace Sogeti.Capstone.Data.IntegrationTests
{
    [TestFixture]
    public class EventTypeDataIntegrationTests
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
        public void Add_EventType_With_Defaults()
        {
            //arrange
            var newEventType = new EventType();

            //act
            Context.EventType.Add(newEventType);
            Context.SaveChanges();

            //assert
            int rowCount = Context.EventType.Count();
            rowCount.ShouldBeGreaterThan(0);
        }

        [Test]
        public void Should_Populate_ID()
        {
            // arrange
            var newEventType = new EventType();

            // act
            Context.EventType.Add(newEventType);
            Context.SaveChanges();

            // assert
            Context.EventType.First().Id.ShouldBe(1);
        }

        [Test]
        public void Delete_EventType()
        {
            //arrange
            var newEventType = new EventType();

            //act
            Context.EventType.Add(newEventType);
            Context.SaveChanges();

            Context.EventType.Remove(newEventType);
            Context.SaveChanges();

            //assert
            int rowCount = Context.EventType.Count();
            rowCount.ShouldBe(0);
        }

        #endregion
    }
}