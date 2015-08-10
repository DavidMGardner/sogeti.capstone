using System;
using System.Runtime.Remoting.Contexts;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Shouldly;
using Sogeti.Capstone.Core;
using Sogeti.Capstone.Data.Model;
using Sogeti.Capstone.Domain.Commands.CreateEventType;

namespace Sogeti.Capstone.CQS.Integration.Tests
{
    [TestClass]
    public class EventTypeCommands
    {
        private static readonly CapstoneContext Context =
           new CapstoneContext("Sogeti.Capstone.Data.Model.CapstoneContext");

        [TestFixtureSetUp]
        public void Init()
        {
            IntegrationTestDatabaseInitalizer.AssemblyInit(Context);
        }

        [Test]
        public async Task CreateEventTypeCommand()
        {
            // Arrange
            var container = Bootstrap.Startup();
            var mediator = new Mediator(container);

            // Act
            var result = await mediator.RequestAsync(new CreateEventType
            {
                Title = "TestTitle"
            });

            // Assert
            result.Id.ShouldBeGreaterThan(0);
        }
    }
}
