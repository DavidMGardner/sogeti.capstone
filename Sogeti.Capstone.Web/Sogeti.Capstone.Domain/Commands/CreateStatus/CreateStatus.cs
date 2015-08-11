using ShortBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sogeti.Capstone.Domain.Commands.CreateStatus
{
    public class CreateStatus : IAsyncRequest<CreateStatusResult>
    {
        public string Title { get; set; }

        public CreateStatus()
        {

        }

        public CreateStatus(string title)
        {
            Title = title;
        }
    }

    public class CreateStatusResult
    {
        public int Id { get; set; }
    }
}
