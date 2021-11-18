using G3L.Examples.NTier.APIv6;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Minimal Api", Version = "v1"}));

var connectionString = builder.Configuration.GetConnectionString("NTier-demo");
builder.Services.AddBusinessLayer(connectionString);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.RegisterVisitRoutes();
app.RegisterCompanyRoutes();
app.RegisterEmployeeRoutes();


app.Run();

