using RabbitMQ.Client;
using System.Text;

bool running = true;

var factory = new ConnectionFactory() { HostName = "Localhost" };
var connection = factory.CreateConnection();
var channel = connection.CreateModel();

var messageBody = Encoding.UTF8.GetBytes("HelloWorld");

while (running)
{
	Console.WriteLine("Press Enter to send...");
	var key = Console.ReadKey().Key;
	if(key == ConsoleKey.Enter)
	{
		channel.BasicPublish(exchange: "FilterExchange",
		routingKey: "Filter.Points.Filter1",
		basicProperties: null,
		body: messageBody);
	}
	else
	{
		running = false;
	}

}

