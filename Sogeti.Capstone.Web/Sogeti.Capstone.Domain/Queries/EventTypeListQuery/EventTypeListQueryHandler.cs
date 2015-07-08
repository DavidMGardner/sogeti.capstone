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
                        Title = "Conference"
                    },

                    new EventType()
                    {
                        Title = "Social"
                    }
                }
            };

            return Task.FromResult(response);
        }
    }
}
