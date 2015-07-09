using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            var events = new List<Event>();
            events.Add(new Event()
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
                    });
            events.Add(new Event()
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
                    });

            for (int i = 0; i < 25; i++)
            {
                events.Add(
                    new Event()
                    {
                        Title = "Sample Title",
                        Description = "Sample Description",
                        StartDateTime = DateTime.Now,
                        EndDateTime = DateTime.Now.AddDays(1),
                        LocationInformation = "Sample Location",
                        LogoPath = "//SamplePath",
                        RegistrationType = new RegistrationType(),
                        EventType = new EventType(),
                        Status = new Status()
                    });
            }
            var response = new EventListResult
            {
                Events = events
            };

            return Task.FromResult(response);
        }
    }
}
