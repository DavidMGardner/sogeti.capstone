using System.Linq;
using NUnit.Framework;
using Shouldly;
using Sogeti.Capstone.Data.Model;

namespace Sogeti.Capstone.Data.IntegrationTests
{
    [TestFixture]
    public class CategoryDataIntegrationTests
    {
        private static readonly CapstoneContext Context = new CapstoneContext("Sogeti.Capstone.Data.Model.CapstoneContext");

        [TestFixtureSetUp]
        public void Init()
        {
            IntegrationTestDatabaseInitalizer.AssemblyInit(Context);
        }

        [Test]
        public void Add_Category_With_Defaults()
        {
            //arrange
            var newCategory = new Category()
            {
                Id = 1
            };

            //act
            Context.Category.Add(newCategory);
            Context.SaveChanges();

            //assert
            int rowCount = Context.Category.Count();
            rowCount.ShouldBeGreaterThan(0);
        }
    }
}