using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShortBus;
using Sogeti.Capstone.Domain.Queries.EventListQuery;

namespace Sogeti.Capstone.Domain.Queries.EventTypeListQuery
{
    public class EventTypeListQuery : IAsyncRequest<EventTypeListResult>
    {
        public EventTypeListQuery() {}
    }

    public class EventTypeListResult
    {
        public List<EventType> EventTypes { get; set; } 
    }
}
