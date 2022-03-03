// See https://aka.ms/new-console-template for more information

using System.Text;
using RabbitMQ.Client;

Console.WriteLine("Hello, World!");


var factory = new ConnectionFactory() {HostName = "localhost"};
using (var connection = factory.CreateConnection())
{
    using (var channel = connection.CreateModel())
    {
        channel.QueueDeclare("Testing-queue", false, false, false);

        var message = "testing 12345";
        var body = Encoding.UTF8.GetBytes(message);

        channel.BasicPublish("", "hello", null, body);
    }
}



Console.ReadLine();