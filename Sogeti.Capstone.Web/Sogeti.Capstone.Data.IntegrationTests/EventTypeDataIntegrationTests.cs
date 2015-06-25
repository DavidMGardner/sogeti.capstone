using System.Linq;
using NUnit.Framework;
using Shouldly;
using Sogeti.Capstone.Data.Model;

namespace Sogeti.Capstone.Data.IntegrationTests
{
    [TestFixture]
    public class EventTypeDataIntegrationTests
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
        public void Add_EventType_With_Defaults()
        {
            //arrange
            var newEventType = new EventType()
            {
                Id = 1
            };

            //act
            Context.EventType.Add(newEventType);
            Context.SaveChanges();

            //assert
            int rowCount = Context.EventType.Count();
            rowCount.ShouldBeGreaterThan(0);
        }
    }
}