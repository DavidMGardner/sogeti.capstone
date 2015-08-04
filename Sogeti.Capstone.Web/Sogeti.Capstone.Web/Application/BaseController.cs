using System.Threading.Tasks;
using System.Web.Mvc;
using ShortBus;
using StructureMap;
using IMediator = Sogeti.Capstone.Core.IMediator;

namespace Sogeti.Capstone.Web.Application
{
    public class BaseController : Controller
    {
        public IMediator Mediator { get; set; }

        protected async Task<T> QueryAsync<T>(IAsyncRequest<T> query)
        {
            var result = await Mediator.RequestAsync(query);

            return result;
        }

        protected async Task<T> CommandAsync<T>(IAsyncRequest<T> command)
        {
            var result = await Mediator.RequestAsync(command);

            return result;
        }
    }
}