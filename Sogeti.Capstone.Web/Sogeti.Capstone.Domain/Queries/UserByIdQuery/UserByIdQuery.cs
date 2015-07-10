using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShortBus;
using Sogeti.Capstone.Domain.Queries.RegistrationTypeListQuery;

namespace Sogeti.Capstone.Domain.Queries.UserByIdQuery
{
    public class UserByIdQuery : IAsyncRequest<UserByIdResult>
    {
        public string Id { get; set; }

        public UserByIdQuery(string id)
        {
            Id = id;
        }
    }

    public class UserByIdResult
    {
        public User User { get; set; }
    }
}
