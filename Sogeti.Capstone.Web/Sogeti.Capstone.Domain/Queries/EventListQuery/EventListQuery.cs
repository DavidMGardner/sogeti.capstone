using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShortBus;

namespace Sogeti.Capstone.Domain.Queries.EventListQuery
{
    public class EventListQuery : IAsyncRequest<EventListResult>
    {
        public EventListQuery() { }
    }

    public class EventListResult
    {
        public List<Event> Events { get; set; }
    }
}
