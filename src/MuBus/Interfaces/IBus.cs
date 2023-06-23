namespace MuBus.Interfaces
{
    public interface IBus
    {
        Task SendMessage<TMessage>(TMessage message) where TMessage : IMessage;
        void RegisterHandler<TMessage>(IMessageHandler<TMessage> messageHandler) where TMessage : IMessage;
    }
}
