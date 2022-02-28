
using Dapper_Demo.Queries;
using Microsoft.Extensions.Configuration;


var config = new ConfigurationBuilder()
    .AddJsonFile("appSettings.json")
    .Build();

var connectionString = config.GetConnectionString("demo");
Console.WriteLine(connectionString);

var basic = new BasicQueries(connectionString);

var result = await basic.GetCustomers();
Console.WriteLine(result.Count());

var invoices = await basic.GetInvoices();



Console.WriteLine("All Done! Press enter to exit");
Console.ReadLine();