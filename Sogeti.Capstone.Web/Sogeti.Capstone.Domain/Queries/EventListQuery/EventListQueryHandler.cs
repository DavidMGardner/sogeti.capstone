using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShortBus;

namespace Sogeti.Capstone.Domain.Queries.EventListQuery
{
    public class EventListQueryHandler : IAsyncRequestHandler<EventListQuery, EventListResult>
    {
        public Task<EventListResult> HandleAsync(EventListQuery request)
        {
            var response = new EventListResult
            {
                Events = new List<Event>
                {
                    new Event()
                    {
                        Title = "Mock Title",
                        Description = "Mock Description",
                        StartDateTime = DateTime.Now,
                        EndDateTime = DateTime.Now.AddDays(1),
                        LocationInformation = "Mock Location",
                        LogoPath = "//MockPath",
                        RegistrationType = new RegistrationType(),
                        EventType = new EventType(),
                        Status = new Status()
                    },
                    new Event()
                    {
                        Title = "Mock Title",
                        Description = "Mock Description",
                        StartDateTime = DateTime.Now.AddDays(-2),
                        EndDateTime = DateTime.Now.AddDays(-1),
                        LocationInformation = "Mock Location",
                        LogoPath = "//MockPath",
                        RegistrationType = new RegistrationType(),
                        EventType = new EventType(),
                        Status = new Status()
                    }
                }
            };

            return Task.FromResult(response);
        }
    }
}
