using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ShortBus;
using ShortBus.StructureMap;
using Sogeti.Capstone.Web.Application;
using StructureMap;
using StructureMap.AutoMocking;
using StructureMap.Graph;
using IDependencyResolver = ShortBus.IDependencyResolver;

namespace Sogeti.Capstone.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //ObjectFactory.Initialize(init =>
            //{
            //    init.Scan(x =>
            //    {
            //        x.AssemblyContainingType(typeof(IAsyncRequestHandler<,>));
            //        x.AssemblyContainingType(typeof(IAsyncRequest<>));

            //        x.LookForRegistries();

            //        x.Assembly("Sogeti.Capstone.Domain");

            //        x.WithDefaultConventions();
            //        x.TheCallingAssembly();
            //        x.AddAllTypesOf(typeof(IAsyncRequest<>));
            //        x.AddAllTypesOf(typeof(IAsyncRequestHandler<,>));
            //        x.AddAllTypesOf(typeof(INotificationHandler<>));
            //        x.AddAllTypesOf(typeof(IAsyncNotificationHandler<>));
            //    });
            //    init.Policies.SetAllProperties(x => x.OfType<Application.IMediator>());
            //    //init.Policies.FillAllPropertiesOfType<Sogeti.Capstone.Web.Application.IMediator>().Use<Sogeti.Capstone.Web.Application.Mediator>();
            //});
            var container = new Container(init =>
            {
                init.Scan(scanner =>
                {
                    scanner.AssemblyContainingType(typeof(IAsyncRequestHandler<,>));
                    scanner.AssemblyContainingType(typeof(IAsyncRequest<>));

                    scanner.LookForRegistries();

                    scanner.Assembly("Sogeti.Capstone.Domain");

                    scanner.WithDefaultConventions();
                    scanner.TheCallingAssembly();
                    scanner.AddAllTypesOf(typeof(IAsyncRequest<>));
                    scanner.AddAllTypesOf(typeof(IAsyncRequestHandler<,>));
                    scanner.AddAllTypesOf(typeof(INotificationHandler<>));
                    scanner.AddAllTypesOf(typeof(IAsyncNotificationHandler<>));
                });
                init.Policies.SetAllProperties(x => x.OfType<Application.IMediator>());
            });

            //var controllerFactory = new StructureMapControllerFactory(ObjectFactory.Container);
            var controllerFactory = new StructureMapControllerFactory(container);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
            
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
