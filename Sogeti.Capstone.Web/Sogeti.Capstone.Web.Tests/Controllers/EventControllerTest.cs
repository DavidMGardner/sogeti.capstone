using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using NUnit.Framework;
using Shouldly;
using Sogeti.Capstone.Web.Application;
using Sogeti.Capstone.Web.Controllers;
using Sogeti.Capstone.Web.ViewModel;
using StructureMap;
using StructureMap.Graph;
using ShortBus;

namespace Sogeti.Capstone.Web.Tests.Controllers
{
    [TestFixture]
    public class EventControllerTest
    {
        [TestFixtureSetUp]
        public void Init()
        {
            ObjectFactory.Initialize(init =>
            {
                init.Scan(x =>
                {
                    x.AssemblyContainingType(typeof(IAsyncRequestHandler<,>));
                    x.AssemblyContainingType(typeof(IAsyncRequest<>));

                    x.LookForRegistries();

                    x.Assembly("Sogeti.Capstone.Domain");

                    x.WithDefaultConventions();
                    x.TheCallingAssembly();
                    x.AddAllTypesOf(typeof(IAsyncRequest<>));
                    x.AddAllTypesOf(typeof(IAsyncRequestHandler<,>));
                    x.AddAllTypesOf(typeof(INotificationHandler<>));
                    x.AddAllTypesOf(typeof(IAsyncNotificationHandler<>));
                });
                init.Policies.SetAllProperties(x => x.OfType<Application.IMediator>());
                //init.Policies.FillAllPropertiesOfType<Sogeti.Capstone.Web.Application.IMediator>().Use<Sogeti.Capstone.Web.Application.Mediator>();
            });

            var controllerFactory = new StructureMapControllerFactory(ObjectFactory.Container);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }

        [Test]
        public async void Index()
        {
            // Arrange
            //var controller = new EventsController();

            //// Act
            //var res = (await controller.Index());
            //var result = (await controller.Index()) as ViewResult;
            //var product = (IEnumerable<EventViewModel>)result.ViewData.Model;

            //// Assert
            //product.First().Title.ShouldBe("Mock Title");
        }
    }
}
