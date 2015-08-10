using ShortBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sogeti.Capstone.Domain.Commands.CreateEventType
{
    public class CreateEventType : IAsyncRequest<CreateEventTypeResult>
    {
        public string Title { get; set; }

        public CreateEventType()
        {
            
        }

        public CreateEventType(string title)
        {
            Title = title;
        }
    }

    public class CreateEventTypeResult
    {
        public int Id { get; set; }
    }
}
