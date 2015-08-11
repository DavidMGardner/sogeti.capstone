using ShortBus;
using Sogeti.Capstone.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moo.Extenders;

namespace Sogeti.Capstone.Domain.Commands.CreateStatus
{
    public class CreateStatusHandler : IAsyncRequestHandler<CreateStatus, CreateStatusResult>
    {
        private static readonly CapstoneContext Context =
        new Sogeti.Capstone.Data.Model.CapstoneContext("Sogeti.Capstone.Data.Model.CapstoneContext");

        public async Task<CreateStatusResult> HandleAsync(CreateStatus request)
        {
            var dataModel = request.MapTo<Sogeti.Capstone.Data.Model.Status>();
            var response = Context.Statuses.Add(dataModel);

            await Context.SaveChangesAsync();

            return new CreateStatusResult { Id = response.Id };
        }
    }
}
