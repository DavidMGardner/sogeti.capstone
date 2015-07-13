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
                        Id = 0,
                        Title = "Current Title",
                        Description = "Mock Description",
                        StartDateTime = DateTime.Now,
                        EndDateTime = DateTime.Now.AddHours(1),
                        LocationInformation = "Mock Location",
                        LogoPath = "//MockPath",
                        RegistrationType = new RegistrationType(),
                        EventType = new EventType(),
                        Status = new Status()
                    });
            events.Add(new Event()
            {
                Id = 1,
                        Title = "Past Title",
                        Description = "Mock Description",
                        StartDateTime = DateTime.Now.AddDays(-2),
                        EndDateTime = DateTime.Now.AddDays(-1),
                        LocationInformation = "Mock Location",
                        LogoPath = "//MockPath",
                        RegistrationType = new RegistrationType(),
                        EventType = new EventType(),
                        Status = new Status()
                    });

            for (int i = 2; i < 25; i++)
            {
                events.Add(
                    new Event()
                    {
                        Id = i,
                        Title = "Sample Title " + i,
                        Description = "Sample Description that just continues for awhile. It has alot of words in order to represent the string in the proper format we want. Do you want to display this much information? Or stop just a hair earlier?",
                        StartDateTime = DateTime.Now.AddHours(i+1),
                        EndDateTime = DateTime.Now.AddDays(1).AddHours(i+1),
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
