namespace MuBus.Interfaces
{
    public interface IMessageHandler<TMessage> where TMessage : IMessage
    {
        Task Handle(TMessage message);
    }
}
