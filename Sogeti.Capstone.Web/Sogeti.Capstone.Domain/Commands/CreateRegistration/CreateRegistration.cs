using ShortBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sogeti.Capstone.Domain.Commands.CreateRegistration
{
    public class CreateRegistration : IAsyncRequest<CreateRegistrationResult>
    {
        public string Title { get; set; }
        public DateTime RegisterDateTime { get; set; }

        public CreateRegistration()
        {

        }

        public CreateRegistration(string title, DateTime register)
        {
            Title = title;
            RegisterDateTime = register;
        }
    }

    public class CreateRegistrationResult
    {
        public int Id { get; set; }
    }
}
