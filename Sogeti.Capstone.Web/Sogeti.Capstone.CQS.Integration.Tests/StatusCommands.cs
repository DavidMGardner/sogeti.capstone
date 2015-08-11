using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Sogeti.Capstone.Core;
using Sogeti.Capstone.Data.Model;
using Sogeti.Capstone.Domain.Commands.CreateStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shouldly;

namespace Sogeti.Capstone.CQS.Integration.Tests
{
    [TestClass]
    class StatusCommands
    {
        private static readonly CapstoneContext Context =
           new CapstoneContext("Sogeti.Capstone.Data.Model.CapstoneContext");

        [TestFixtureSetUp]
        public void Init()
        {
            IntegrationTestDatabaseInitalizer.AssemblyInit(Context);
        }

        [Test]
        public async Task CreateStatusCommand()
        {
            // Arrange
            var container = Bootstrap.Startup();
            var mediator = new Mediator(container);

            // Act
            var result = await mediator.RequestAsync(new CreateStatus
            {
                Title = "TestTitle"
            });

            // Assert
            result.Id.ShouldBeGreaterThan(0);
        }
    }
}
