using System;
using System.Runtime.Remoting.Contexts;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Shouldly;
using Sogeti.Capstone.Core;
using Sogeti.Capstone.Data.Model;
using Sogeti.Capstone.Domain.Commands.CreateEvent;


namespace Sogeti.Capstone.CQS.Integration.Tests
{
    [TestClass]
    public class EventCommands
    {
        private static readonly CapstoneContext Context =
           new CapstoneContext("Sogeti.Capstone.Data.Model.CapstoneContext");
        
        [TestFixtureSetUp]
        public void Init()
        {
            IntegrationTestDatabaseInitalizer.AssemblyInit(Context);
        }
        
        [Test]
        public async Task CreateEventCommand()
        {
            // Arrange
            var container = Bootstrap.Startup();
            var mediator = new Mediator(container);

            // Act
            var result = await mediator.RequestAsync(new CreateEvent
            {
                Description = "TestDescription",
                EndDateTime = DateTime.Now,
                StartDateTime = DateTime.Now,
                LocationInformation = "LocationInformation",
                LogoPath = "LogoPath",
                Title = "Title"
            });
            
            //Assert
            result.Id.ShouldBeGreaterThan(0);
        }
    }
}
