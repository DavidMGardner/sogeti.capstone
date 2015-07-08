using ShortBus;
using Sogeti.Capstone.Domain.Queries.EventListQuery;

namespace Sogeti.Capstone.Domain.Queries.EventByIdQuery
{
    public class EventByIdQuery : IAsyncRequest<EventByIdResult>
    {
        public string Id { get; set; }

        public EventByIdQuery(string id)
        {
            Id = id;
        }
    }

    public class EventByIdResult
    {
        public Event Event { get; set; }
    }
}
