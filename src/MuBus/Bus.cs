using MuBus.Interfaces;

namespace MuBus
{
    public class Bus : IBus
    {
        private Dictionary<Type, List<object>> _handlers;

        public Bus()
        {
            _handlers = new Dictionary<Type, List<object>>();
        }

        public async Task SendMessage<TMessage>(TMessage message) where TMessage : IMessage
        {
            var typeMessage = typeof(TMessage);

            if (_handlers.TryGetValue(typeMessage, out var handlers))
            {
               foreach (var handler in handlers) 
                {
                    await ((IMessageHandler<TMessage>)handler).Handle(message);
                }
            }
        }

        public void RegisterHandler<TMessage>(IMessageHandler<TMessage> messageHandler) where TMessage : IMessage
        {
            var typeMessage = typeof(TMessage);

            if (_handlers.ContainsKey(typeMessage))
                _handlers[typeMessage].Add(messageHandler);
            else
                _handlers[typeMessage] = new List<object> { messageHandler };
        }

        
    }
}
