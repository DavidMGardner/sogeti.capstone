using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using ShortBus;
using StructureMap;
using StructureMap.Graph;

namespace Sogeti.Capstone.CQS.Integration.Tests
{
    public static class Bootstrap
    {
        public static Container Startup()
        {
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
                init.Policies.SetAllProperties(x => x.OfType<Sogeti.Capstone.Core.IMediator>());
            });

            return container;
        }
    }
}
