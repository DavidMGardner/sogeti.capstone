using ShortBus;
using Sogeti.Capstone.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moo.Extenders;

namespace Sogeti.Capstone.Domain.Commands.CreateRegistration
{
    public class CreateRegistrationHandler : IAsyncRequestHandler<CreateRegistration, CreateRegistrationResult>
    {
        private static readonly CapstoneContext Context =
             new Sogeti.Capstone.Data.Model.CapstoneContext("Sogeti.Capstone.Data.Model.CapstoneContext");

        public async Task<CreateRegistrationResult> HandleAsync(CreateRegistration request)
        {
            var dataModel = request.MapTo<Sogeti.Capstone.Data.Model.Registration>();
            var response = Context.Registrations.Add(dataModel);

            await Context.SaveChangesAsync();

            return new CreateRegistrationResult { Id = response.Id };
        }
        
    }
}
