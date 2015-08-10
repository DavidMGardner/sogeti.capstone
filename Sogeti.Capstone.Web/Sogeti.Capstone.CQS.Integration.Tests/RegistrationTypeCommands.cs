using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Shouldly;
using Sogeti.Capstone.Core;
using Sogeti.Capstone.Domain.Commands.CreateRegistrationType;
using Sogeti.Capstone.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sogeti.Capstone.CQS.Integration.Tests
{
    [TestClass]
    class RegistrationTypeCommands
    {
        private static readonly CapstoneContext Context =
               new CapstoneContext("Sogeti.Capstone.Data.Model.CapstoneContext");

        [TestFixtureSetUp]
        public void Init()
        {
            IntegrationTestDatabaseInitalizer.AssemblyInit(Context);
        }

        [Test]
        public async Task CreateRegistrationTypeCommand()
        {
            //Arrange
            var container = Bootstrap.Startup();
            var mediator = new Mediator(container);

            //Act
            var result = await mediator.RequestAsync(new CreateRegistrationType
             {
                 Title = "TestTitle"
             });

            //Assert
            result.Id.ShouldBeGreaterThan(0);
        }
    }
}
