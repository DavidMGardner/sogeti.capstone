using System.Linq;
using NUnit.Framework;
using Shouldly;
using Sogeti.Capstone.Data.Model;

namespace Sogeti.Capstone.Data.IntegrationTests
{
    [TestFixture]
    public class StatusDataIntegrationTests
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
        public void Add_Status_With_Defaults()
        {
            //arrange
            var newStatus = new Status()
            {
                Id = 1
            };

            //act
            Context.Statuses.Add(newStatus);
            Context.SaveChanges();

            //assert
            int rowCount = Context.Statuses.Count();
            rowCount.ShouldBeGreaterThan(0);
        }

        [Test]
        public void Delete_Status()
        {
            //arrange
            var newStatus = new Status
            {
                Id = 1
            };

            //act
            Context.Statuses.Add(newStatus);
            Context.SaveChanges();

            Context.Statuses.Remove(newStatus);
            Context.SaveChanges();

            //assert
            int rowCount = Context.Statuses.Count();
            rowCount.ShouldBe(0);
        }
    }
}