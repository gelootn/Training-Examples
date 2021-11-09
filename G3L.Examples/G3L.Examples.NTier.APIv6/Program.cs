using G3L.Examples.NTier.BLL.Infrastructure;
using G3L.Examples.NTier.BLL.Models.Company;
using G3L.Examples.NTier.BLL.Models.Employee;
using G3L.Examples.NTier.BLL.Models.Visit;
using G3L.Examples.NTier.BLL.Services;
using G3L.Examples.NTier.Framework.Models;
using Microsoft.AspNetCore.Mvc;

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

var visitEndpoint = "/api/visit";
var companyEndpoint = "/api/company";
var jsonContentType = "application/json";

app.MapGet($"{visitEndpoint}/open", async ([FromServices] IVisitService visitService) => Results.Ok(await visitService.GetOpenVisits()))
    .Produces<Response<VisitModel>>(StatusCodes.Status200OK)
    .WithTags("Visits");

app.MapGet($"{visitEndpoint}", async ([FromServices] IVisitService visitService) => Results.Ok(await visitService.GetVisits()))
    .Produces<Response<VisitModel>>(StatusCodes.Status200OK)
    .WithTags("Visits");

app.MapPost($"{visitEndpoint}/signin", async ([FromServices] IVisitService visitService, [FromBody] StartVisitModel startVisit) =>
{
    await visitService.RegisterVisit(startVisit);
    return Results.Ok();
})
    .Accepts<StartVisitModel>(jsonContentType)
    .WithTags("Visits");

app.MapPost($"{visitEndpoint}/signout", async ([FromServices] IVisitService visitService, [FromBody] StopVisitModel stopVisit) =>
{
    await visitService.CloseVisit(stopVisit);
    return Results.Ok();
})
    .Accepts<StopVisitModel>(jsonContentType)
    .Produces(StatusCodes.Status200OK)
    .Produces(StatusCodes.Status404NotFound)
    .WithTags("Visits");


app.MapGet($"{companyEndpoint}", async ([FromServices] ICompanyService service) => Results.Ok(await service.Get()))
    .Produces<Response<CompanyModel>>(StatusCodes.Status200OK)
    .WithTags("Companies");

app.MapPost($"{companyEndpoint}", ([FromServices] ICompanyService service, [FromBody] CompanyModel company) => {
    service.Add(company);
    Results.Ok();
})
    .Accepts<CompanyModel>(jsonContentType)
    .Produces(StatusCodes.Status200OK)
    .WithTags("Companies");

app.MapPut($"{companyEndpoint}/" + "{id}", ([FromServices] ICompanyService service, [FromRoute] int id, [FromBody] CompanyModel company) =>
{
    service.Update(company);
    Results.Ok();
})
    .Accepts<CompanyModel>(jsonContentType)
    .Produces(StatusCodes.Status200OK)
    .WithTags("Companies");

app.MapDelete ($"{companyEndpoint}/" + "{id}", ([FromServices] ICompanyService service, [FromRoute] int id) =>
{
    service.Delete(id);
    Results.Ok();
})
    .Accepts<CompanyModel>(jsonContentType)
    .Produces(StatusCodes.Status200OK)
    .WithTags("Companies");

app.MapPost($"{companyEndpoint}/" + "{id}/employee", ([FromServices] ICompanyService service, [FromRoute] int id, EmployeeModel employee) =>
{
    service.AddEmployeeToCompany(employee, id);
})
    .Accepts<EmployeeModel>(jsonContentType)
    .Produces(StatusCodes.Status200OK)
    .WithTags("Companies");

app.MapPut($"{companyEndpoint}/" + "{id}/employee", ([FromServices] ICompanyService service, [FromRoute] int id, EmployeeModel employee) =>
{
    service.UpdateEmployee(employee);
})
    .Accepts<EmployeeModel>(jsonContentType)
    .Produces(StatusCodes.Status200OK)
    .WithTags("Companies");

app.MapDelete($"{companyEndpoint}/" + "{id}/employee/{employeeId}", ([FromServices] ICompanyService service, [FromRoute] int id, [FromRoute] int employeeId) =>
{
    service.RemoveEmployee(employeeId);
})
    .Accepts<EmployeeModel>(jsonContentType)
    .Produces(StatusCodes.Status200OK)
    .WithTags("Companies");

app.Run();

