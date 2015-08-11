using ShortBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sogeti.Capstone.Domain.Commands.CreateFoodType
{
    public class CreateFoodType : IAsyncRequest<CreateFoodTypeResult>
    {
        public string Title { get; set; }

        public CreateFoodType()
        {

        }

        public CreateFoodType(string title)
        {
            Title = title;
        }
    }

    public class CreateFoodTypeResult
    {
        public int Id { get; set; }
    }
}
