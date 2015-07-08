using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moo.Extenders;
using ShortBus;
using Sogeti.Capstone.Data.Model;

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

            CapstoneContext context = new CapstoneContext("Sogeti.Capstone.Data.Model.CapstoneContext");

            var result = await context.Events.FindAsync(id);

            var outResult = new EventByIdResult
            {
                Event = result.MapTo<Event>()
            };

            return outResult;
        }
    }
}
