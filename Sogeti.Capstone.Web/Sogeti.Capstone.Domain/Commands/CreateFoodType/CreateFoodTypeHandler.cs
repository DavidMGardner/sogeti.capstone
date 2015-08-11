using ShortBus;
using Sogeti.Capstone.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moo.Extenders;

namespace Sogeti.Capstone.Domain.Commands.CreateFoodType
{
    public class CreateFoodTypeHandler : IAsyncRequestHandler<CreateFoodType, CreateFoodTypeResult>
    {
        private static readonly CapstoneContext Context =
             new Sogeti.Capstone.Data.Model.CapstoneContext("Sogeti.Capstone.Data.Model.CapstoneContext");

        public async Task<CreateFoodTypeResult> HandleAsync(CreateFoodType request)
        {
            var dataModel = request.MapTo<Sogeti.Capstone.Data.Model.FoodType>();
            var response = Context.FoodType.Add(dataModel);

            await Context.SaveChangesAsync();

            return new CreateFoodTypeResult { Id = response.Id };
        }
    }
}
