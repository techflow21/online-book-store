namespace RabbitMQSystem
{
    public interface IMessageManager
    {
        void SendMessage<T>(T message);
        string ReceiveMessage();
    }
}