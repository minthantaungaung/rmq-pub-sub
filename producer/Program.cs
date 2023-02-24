using Newtonsoft.Json;
using producer;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json.Serialization;

HttpClient req = new();

var factory = new ConnectionFactory { HostName = "localhost" };
using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

channel.QueueDeclare( queue: "Q1", durable: false, exclusive: false,    arguments: null);

var rsp = await req.GetAsync("https://jsonplaceholder.typicode.com/users");
var s = await rsp.Content.ReadAsStringAsync();

var dataListToRun = JsonConvert.DeserializeObject<List<Root>>(s);
var byteList = dataListToRun.Select(JsonConvert.SerializeObject).Select(json => Encoding.UTF8.GetBytes(json));
var i = 0;
foreach (var item in byteList)
{
    Console.WriteLine($"Sending.................");
    channel.BasicPublish(exchange:"", routingKey:"Q1",basicProperties: null, body:item);
    Console.WriteLine($"Published message no: {i++}");
    await Task.Delay(4000);
}
Console.WriteLine($"All done {dataListToRun.Count()}");


