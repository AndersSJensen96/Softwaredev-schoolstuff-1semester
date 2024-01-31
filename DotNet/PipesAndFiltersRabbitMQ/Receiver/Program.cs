using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

var factory = new ConnectionFactory() { HostName = "Localhost" };
var connection = factory.CreateConnection();
var channel = connection.CreateModel();

channel.QueueDeclare(queue: "ReceiverQueue",
					durable: true,
					exclusive: false,
					autoDelete: false,
					arguments: null);

channel.QueueBind(queue: "ReceiverQueue",
				exchange: "FilterExchange",
				routingKey: "Filter.Points.Receiver");

var consumer = new EventingBasicConsumer(channel);

consumer.Received += (model, ea) =>
{
	var body = ea.Body.ToArray();
	var message = Encoding.UTF8.GetString(body);
	Console.WriteLine(message);
};


channel.BasicConsume(queue: "ReceiverQueue",
					autoAck: true,
					consumer: consumer);

Console.WriteLine("Message Received at Endpoint");
Console.ReadLine();