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
    }
}