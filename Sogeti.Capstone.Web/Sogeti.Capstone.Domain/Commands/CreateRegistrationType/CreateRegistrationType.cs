using ShortBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sogeti.Capstone.Domain.Commands.CreateRegistrationType
{
    public class CreateRegistrationType : IAsyncRequest<CreateRegistrationTypeResult>
    {
        public string Title { get; set; }

        public CreateRegistrationType()
        {

        }

        public CreateRegistrationType(string title)
        {
            Title = title;
        }
    }

    public class CreateRegistrationTypeResult
    {
        public int Id { get; set; }
    }


}
