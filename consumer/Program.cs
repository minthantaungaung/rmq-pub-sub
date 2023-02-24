using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

var factory = new ConnectionFactory { HostName = "localhost" };
using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

channel.QueueDeclare(
    queue: "Q1",
    durable: false,
    exclusive: false,
    arguments: null);

var Consumer = new EventingBasicConsumer(channel);
Consumer.Received += (sender, args) =>
{
    var body = args.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);

    Console.WriteLine($" Recieved :::::: {message}");
    Console.WriteLine("==========================================================");
};
channel.BasicConsume(
    queue: "Q1", autoAck: true, consumer: Consumer);

Console.ReadKey();

