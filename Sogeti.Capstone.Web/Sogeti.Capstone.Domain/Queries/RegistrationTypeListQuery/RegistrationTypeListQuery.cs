using System.Collections.Generic;
using ShortBus;

namespace Sogeti.Capstone.Domain.Queries.RegistrationTypeListQuery
{
    public class RegistrationTypeListQuery : IAsyncRequest<RegistrationTypeListResult>
    {
        public RegistrationTypeListQuery() { }
    }

    public class RegistrationTypeListResult
    {
        public IEnumerable<RegistrationType> Categories { get; set; }
    }
}