using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moo.Extenders;
using ShortBus;
using Sogeti.Capstone.Data.Model;

namespace Sogeti.Capstone.Domain.Commands.CreateEvent
{
    public class CreateEventHandler : IAsyncRequestHandler<CreateEvent, CreateEventResult>
    {
        private static readonly CapstoneContext Context =
         new Sogeti.Capstone.Data.Model.CapstoneContext("Sogeti.Capstone.Data.Model.CapstoneContext");

        
        public async Task<CreateEventResult> HandleAsync(CreateEvent request)
        {
            //var dataModel = request.MapTo<Sogeti.Capstone.Data.Model.Event>();
            //var repsonse = Context.Events.Add(dataModel);

            //await Context.SaveChangesAsync(); 

            //return new CreateEventResult { Id = repsonse.Id};

            return new CreateEventResult { Id = 1 };
        }
    }
}
