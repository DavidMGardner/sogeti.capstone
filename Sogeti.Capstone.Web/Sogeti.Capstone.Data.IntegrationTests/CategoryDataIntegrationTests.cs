using System.Data.Entity;
using System.Linq;
using System.Data.SqlClient;
using NUnit.Framework;
using Shouldly;
using Sogeti.Capstone.Data.Model;

namespace Sogeti.Capstone.Data.IntegrationTests
{
    [TestFixture]
    public class CategoryDataIntegrationTests
    {
        private static readonly CapstoneContext Context =
            new CapstoneContext("Sogeti.Capstone.Data.Model.CapstoneContext");

        private RegistrationType _sampleRegistrationType;

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

            _sampleRegistrationType = new RegistrationType()
            {
                Title = "Sample Category"
            };
        }

        #endregion

        #region Tests

        [Test]
        public void Add_Category_With_Defaults()
        {
            //arrange
            var newCategory = new RegistrationType();

            //act
            Context.Category.Add(newCategory);
            Context.SaveChanges();

            //assert
            int rowCount = Context.Category.Count();
            rowCount.ShouldBeGreaterThan(0);
        }

        [Test]
        public void Delete_Category()
        {
            //arrange
            var newCategory = new RegistrationType();

            //act
            Context.Category.Add(newCategory);
            Context.SaveChanges();

            Context.Category.Remove(newCategory);
            Context.SaveChanges();

            //assert
            int rowCount = Context.Category.Count();
            rowCount.ShouldBe(0);
        }

        [Test]
        public void Should_Populate_ID()
        {
            // arrange
            var newCategory = new RegistrationType();

            // act
            Context.Category.Add(newCategory);
            Context.SaveChanges();

            // assert
            Context.Category.First().Id.ShouldBe(1);
        }

        [Test]
        public void Should_Not_Allow_Duplicate_ID()
        {
            // arrange
            Context.Category.Add(_sampleRegistrationType);
            Context.SaveChanges();

            RegistrationType duplicateRegistrationType = new RegistrationType
            {
                Id = 1,
                Title = "Unique Category"
            };

            // act
            Context.Category.Add(duplicateRegistrationType);
            Context.SaveChanges();
            RegistrationType correctedDuplicateRegistrationType = Context.Category.First(e => e.Title == "Unique Category");

            // assert
            correctedDuplicateRegistrationType.Id.ShouldNotBe(1);
        }


        [Test]
        public void Add_Category_With_Wrong_Input()
        {
            //assert
            Should.Throw<SqlException>(
                () =>
                {
                    Context.Database.ExecuteSqlCommand(
                    "INSERT INTO dbo.Categories (Title) VALUES (#4/20/2020#)");
                });
        }

        #endregion
    }
}