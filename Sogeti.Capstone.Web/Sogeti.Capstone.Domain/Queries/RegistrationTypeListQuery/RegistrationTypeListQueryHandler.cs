using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShortBus;

namespace Sogeti.Capstone.Domain.Queries.RegistrationTypeListQuery
{
    public class RegistrationTypeListQueryHandler : IAsyncRequestHandler<RegistrationTypeListQuery, RegistrationTypeListResult>
    {
        public Task<RegistrationTypeListResult> HandleAsync(RegistrationTypeListQuery request)
        {
            var response = new RegistrationTypeListResult()
            {
                Categories = new List<RegistrationType>()
                {
                    new RegistrationType()
                    {
                        Id = 0,
                        Title = "Attendee"
                    },
                    new RegistrationType()
                    {
                        Id = 1,
                        Title = "Speaker"
                    },
                    new RegistrationType()
                    {
                        Id = 2,
                        Title = "Sponsor"
                    }
                }
            };

            return Task.FromResult(response);
        }
    }
}
