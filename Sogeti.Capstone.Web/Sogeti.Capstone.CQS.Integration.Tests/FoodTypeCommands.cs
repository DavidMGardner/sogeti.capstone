using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Sogeti.Capstone.Core;
using Sogeti.Capstone.Data.Model;
using Sogeti.Capstone.Domain.Commands.CreateFoodType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shouldly;

namespace Sogeti.Capstone.CQS.Integration.Tests
{
    [TestClass]
    public class FoodTypeCommands
    {
        private static readonly CapstoneContext Context =
           new CapstoneContext("Sogeti.Capstone.Data.Model.CapstoneContext");

        [TestFixtureSetUp]
        public void Init()
        {
            IntegrationTestDatabaseInitalizer.AssemblyInit(Context);
        }

        [Test]
        public async Task CreateFoodTypeCommand()
        {
            // Arrange
            var container = Bootstrap.Startup();
            var mediator = new Mediator(container);

            // Act
            var result = await mediator.RequestAsync(new CreateFoodType
            {
                Title = "TestTitle"
            });

            // Assert
            result.Id.ShouldBeGreaterThan(0);
        }
    }
}
