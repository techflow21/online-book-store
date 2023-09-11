using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace RabbitMQSystem
{
    public class MessageManager : IMessageManager
    {
        private readonly ConnectionFactory _factory;

        public MessageManager()
        {
            _factory = new ConnectionFactory { HostName = "localhost" };
        }

        public void SendMessage<T>(T message)
        {
            var connection = _factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare("orders");

            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);

            channel.BasicPublish(exchange: "", routingKey: "orders", body: body);
        }


        public string ReceiveMessage()
        {
            string messageReceived = "";
            var connection = _factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare("orders");

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, eventArgs) =>
            {
                var body = eventArgs.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                messageReceived = message;
            };

            channel.BasicConsume(queue: "orders", autoAck: true, consumer: consumer);
            return messageReceived;
        }
    }
}
