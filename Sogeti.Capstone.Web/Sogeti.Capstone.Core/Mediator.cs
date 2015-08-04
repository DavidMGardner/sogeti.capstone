using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using ShortBus;
using StructureMap;

namespace Sogeti.Capstone.Core
{
    public interface IMediator
    {
        Task<TResponseData> RequestAsync<TResponseData>(IAsyncRequest<TResponseData> query);
        Task NotifyAsync<TNotification>(TNotification notification);
    }

    public class Mediator : IMediator
    {
        readonly IContainer _container;

        public Mediator(IContainer container)
        {
            _container = container;
        }

        public Task<TResponseData> RequestAsync<TResponseData>(IAsyncRequest<TResponseData> query)
        {
            var plan = new MediatorPlan<TResponseData>(typeof(IAsyncRequestHandler<,>), "HandleAsync", query.GetType(), _container);

            return plan.InvokeAsync(query);
        }

        public Task NotifyAsync<TNotification>(TNotification notification)
        {
            var handlers = _container.GetAllInstances<IAsyncNotificationHandler<TNotification>>();

            return Task.WhenAll(handlers.Select(x => x.HandleAsync(notification)));
        }

        class MediatorPlan<TResult>
        {
            readonly MethodInfo HandleMethod;
            readonly Func<object> HandlerInstanceBuilder;

            public MediatorPlan(Type handlerTypeTemplate, string handlerMethodName, Type messageType, IContainer container)
            {
                var handlerType = handlerTypeTemplate.MakeGenericType(messageType, typeof(TResult));

                HandleMethod = GetHandlerMethod(handlerType, handlerMethodName, messageType);

                HandlerInstanceBuilder = () => container.GetInstance(handlerType);
            }

            MethodInfo GetHandlerMethod(Type handlerType, string handlerMethodName, Type messageType)
            {
                return handlerType
                    .GetMethod(handlerMethodName,
                        BindingFlags.Public | BindingFlags.Instance | BindingFlags.InvokeMethod,
                        null, CallingConventions.HasThis,
                        new[] { messageType },
                        null);
            }

            public Task<TResult> InvokeAsync(object message)
            {
                return (Task<TResult>)HandleMethod.Invoke(HandlerInstanceBuilder(), new[] { message });
            }
        }
    }
}
