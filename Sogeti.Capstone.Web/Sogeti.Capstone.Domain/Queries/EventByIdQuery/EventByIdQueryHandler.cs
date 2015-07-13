using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moo.Extenders;
using ShortBus;
using Sogeti.Capstone.Data.Model;
using Sogeti.Capstone.Domain.Queries.EventListQuery;

namespace Sogeti.Capstone.Domain.Queries.EventByIdQuery
{
    public class EventByIdQueryHandler : IAsyncRequestHandler<EventByIdQuery, EventByIdResult>
    {
        private void SimpleTest()
        {
            var output = this.HandleAsync(new EventByIdQuery("1"));
        }
        
        public async Task<EventByIdResult> HandleAsync(EventByIdQuery request)
        {
            int id = Convert.ToInt32(request.Id);

            //CapstoneContext context = new CapstoneContext("Sogeti.Capstone.Data.Model.CapstoneContext");
            var eventListQueryHandler = new EventListQueryHandler().HandleAsync(new EventListQuery.EventListQuery());
            IEnumerable<Event> events = eventListQueryHandler.Result.Events;

            var result = events.First(e => e.Id == id);
            //var result = await context.Events.FindAsync(id);

            //var outResult = new EventByIdResult
            //{
            //    Event = result.MapTo<Event>()
            //};

            //var response = new EventByIdResult
            //{
            //    Event = new Event()
            //    {
            //        Title = "Mock Title",
            //        Description = "Mock Description"
            //    }
            //};
            var response = new EventByIdResult()
            {
                Event = result
            };

            return response;
        }
    }
}
