using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShortBus;

namespace Sogeti.Capstone.Domain.Queries.EventTypeListQuery
{
    public class EventTypeListQueryHandler : IAsyncRequestHandler<EventTypeListQuery, EventTypeListResult>
    {
        public Task<EventTypeListResult> HandleAsync(EventTypeListQuery request)
        {
            var response = new EventTypeListResult()
            {
                EventTypes = new List<EventType>()
                {
                    new EventType()
                    {
                        Id = 0,
                        Title = "Seminar"
                    },
                    new EventType()
                    {
                        Id = 1,
                        Title = "Social"
                    },
                    new EventType()
                    {
                        Id = 2,
                        Title = "Meeting"
                    },
                    new EventType()
                    {
                        Id = 3,
                        Title = "Training"
                    },
                    new EventType()
                    {
                        Id = 4,
                        Title = "Other"
                    }
                }
            };

            return Task.FromResult(response);
        }
    }
}
