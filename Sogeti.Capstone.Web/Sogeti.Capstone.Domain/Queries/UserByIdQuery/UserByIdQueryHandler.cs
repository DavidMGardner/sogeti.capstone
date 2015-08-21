using System;
using System.Threading.Tasks;
using ShortBus;

namespace Sogeti.Capstone.Domain.Queries.UserByIdQuery
{
    public class UserByIdQueryHandler : IAsyncRequestHandler<UserByIdQuery, UserByIdResult>
    {
        public Task<UserByIdResult> HandleAsync(UserByIdQuery request)
        {
            int id = Convert.ToInt32(request.Id);

            var response = new UserByIdResult()
            {
                User = new User()
                {
                    EmailAddress = "fake@email.com",
                    AdditionalInfo = "Mock additional info",
                    AddressLineOne = "address line a",
                    AddressLineTwo = "address line b",
                    BranchName = "this branch",
                    City = "mock city",
                    CompanyName = "mock company",
                    FirstName = "Gordon",
                    LastName = "Freeman",
                    FoodPreference = new FoodType()
                }
            };

            return Task.FromResult(response);
        }
    }
}
