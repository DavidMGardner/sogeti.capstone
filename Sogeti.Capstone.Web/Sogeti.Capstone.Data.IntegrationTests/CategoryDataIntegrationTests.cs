using System.Data.Entity;
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

        //[Test]
        //public void Update_Category()
        //{
        //    //arrange
        //    var oldCategory = Context.Category.First(e => e.Id == 1);
        //    oldCategory.Id = 999;

        //    //act
        //    Context.Entry(oldCategory).State = EntityState.Modified;
        //    Context.SaveChanges();

        //    //assert
        //    var modifiedCategory = Context.Category.Find(999);
        //    modifiedCategory.Id.ShouldBe(999);
        //}

        [Test]
        public void Delete_Category()
        {
            //arrange
            var newCategory = new Category
            {
                Id = 1
            };

            //act
            Context.Category.Add(newCategory);
            Context.SaveChanges();

            DatabaseDataDeleter dataDeleter = new DatabaseDataDeleter(Context);
            dataDeleter.DeleteAllObjects();

            //assert
            int rowCount = Context.Category.Count();
            rowCount.ShouldBe(0);
        }
    }
}