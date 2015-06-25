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

        [TestFixtureSetUp]
        public void Init()
        {
            IntegrationTestDatabaseInitalizer.AssemblyInit(Context);
        }

        [Test]
        public void Add_Registration_With_Defaults()
        {
            //arrange
            var newRegistration = new Registration()
            {
                Id = 1
            };

            //act
            Context.Registrations.Add(newRegistration);
            Context.SaveChanges();

            //assert
            int rowCount = Context.Registrations.Count();
            rowCount.ShouldBeGreaterThan(0);
        }

        [Test]
        public void Delete_Registration()
        {
            //arrange
            var newRegistration = new Registration
            {
                Id = 1
            };

            //act
            Context.Registrations.Add(newRegistration);
            Context.SaveChanges();

            DatabaseDataDeleter dataDeleter = new DatabaseDataDeleter(Context);
            dataDeleter.DeleteAllObjects();

            //assert
            int rowCount = Context.Registrations.Count();
            rowCount.ShouldBe(0);
        }
    }
}