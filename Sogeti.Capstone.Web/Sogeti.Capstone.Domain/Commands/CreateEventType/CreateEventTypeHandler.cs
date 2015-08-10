using ShortBus;
using Sogeti.Capstone.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moo.Extenders;

namespace Sogeti.Capstone.Domain.Commands.CreateEventType
{
    public class CreateEventTypeHandler : IAsyncRequestHandler<CreateEventType, CreateEventTypeResult>
    {
        private static readonly CapstoneContext Context =
            new Sogeti.Capstone.Data.Model.CapstoneContext("Sogeti.Capstone.Data.Model.CapstoneContext");

        public async Task<CreateEventTypeResult> HandleAsync(CreateEventType request)
        {
            var dataModel = request.MapTo<Sogeti.Capstone.Data.Model.EventType>();
            var response = Context.EventType.Add(dataModel);

            await Context.SaveChangesAsync();

            return new CreateEventTypeResult { Id = response.Id };
        }
    }
}
