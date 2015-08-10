using ShortBus;
using Sogeti.Capstone.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moo.Extenders;

namespace Sogeti.Capstone.Domain.Commands.CreateRegistrationType
{
    public class CreateRegistrationTypeHandler : IAsyncRequestHandler<CreateRegistrationType, CreateRegistrationTypeResult>
    {
        private static readonly CapstoneContext Context =
            new Sogeti.Capstone.Data.Model.CapstoneContext("Sogeti.Capstone.Data.Model.CapstoneContext");

        public async Task<CreateRegistrationTypeResult> HandleAsync(CreateRegistrationType request)
        {
            var dataModel = request.MapTo<Sogeti.Capstone.Data.Model.RegistrationType>();
            var response = Context.Category.Add(dataModel);

            await Context.SaveChangesAsync();

            return new CreateRegistrationTypeResult { Id = response.Id };
        }
    }
}
