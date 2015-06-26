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
            var newRegistration = new Registration();

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
            var newRegistration = new Registration();

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
            var newRegistration = new Registration();

            //act
            Context.Registrations.Add(newRegistration);
            Context.SaveChanges();

            Context.Registrations.Remove(newRegistration);
            Context.SaveChanges();

            //assert
            int rowCount = Context.Registrations.Count();
            rowCount.ShouldBe(0);
        }
#endregion

    }
}