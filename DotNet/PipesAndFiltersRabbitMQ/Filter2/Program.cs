using Filter2;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

var factory = new ConnectionFactory() { HostName = "Localhost" };
var connection = factory.CreateConnection();
var channel = connection.CreateModel();
var filter = new Filter();
var message = "";

channel.QueueDeclare(queue: "Filter2Queue",
					durable: true,
					exclusive: false,
					autoDelete: false,
					arguments: null);

channel.QueueBind(
	queue: "Filter2Queue",
	exchange:"FilterExchange",
	routingKey:"Filter.Points.Filter2"
	);

var consumer = new EventingBasicConsumer(channel);

consumer.Received += (model, ea) =>
{
	var body = ea.Body.ToArray();
	message = Encoding.UTF8.GetString(body);
	message = filter.MessageTransform(message);
	Console.WriteLine(message);

	var messageBody = Encoding.UTF8.GetBytes(message);

	channel.BasicPublish(exchange: "FilterExchange",
		routingKey: "Filter.Points.Receiver",
		basicProperties: null,
		body: messageBody);

};


channel.BasicConsume(queue: "Filter2Queue",
					autoAck: true,
					consumer: consumer);


Console.WriteLine("Message Transformed and Published");
Console.ReadLine();