using PipesAndFiltersRabbitMQ;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

var factory = new ConnectionFactory() { HostName = "Localhost" };
var connection = factory.CreateConnection();
var channel = connection.CreateModel();
var filter = new Filter();
var message = "";

channel.ExchangeDeclare(exchange: "FilterExchange", type: ExchangeType.Direct);

channel.QueueDeclare(queue: "FilterQueue",
					durable: true,
					exclusive: false,
					autoDelete: false,
					arguments: null);

channel.QueueBind(
	queue:"FilterQueue",
	exchange:"FilterExchange",
	routingKey:"Filter.Points.Filter1"
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
		routingKey: "Filter.Points.Filter2",
		basicProperties: null,
		body: messageBody);

};


channel.BasicConsume(queue: "FilterQueue",
					autoAck: true,
					consumer: consumer);




Console.WriteLine("Message Transformed and Published");
Console.ReadLine();

