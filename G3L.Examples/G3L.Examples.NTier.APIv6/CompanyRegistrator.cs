namespace G3L.Examples.NTier.APIv6
{
    internal static class CompanyRegistrator
    {
        internal static void RegisterCompanyRoutes(this WebApplication app)
        {
            app.MapGet("/api/company", async ([FromServices] ICompanyService service) => Results.Ok(await service.Get()))
                .Produces<Response<CompanyModel>>(StatusCodes.Status200OK)
                .WithTags("Companies");

            app.MapPost("/api/company", ([FromServices] ICompanyService service, [FromBody] CompanyModel company) => {
                service.Add(company);
                Results.Ok();
            })
                .Accepts<CompanyModel>("application/json")
                .Produces(StatusCodes.Status200OK)
                .WithTags("Companies");

            app.MapPut("/api/company/{id}", ([FromServices] ICompanyService service, [FromRoute] int id, [FromBody] CompanyModel company) =>
            {
                service.Update(company);
                Results.Ok();
            })
                .Accepts<CompanyModel>("application/json")
                .Produces(StatusCodes.Status200OK)
                .WithTags("Companies");

            app.MapDelete("/api/company/{id}", ([FromServices] ICompanyService service, [FromRoute] int id) =>
            {
                service.Delete(id);
                Results.Ok();
            })
                .Accepts<CompanyModel>("application/json")
                .Produces(StatusCodes.Status200OK)
                .WithTags("Companies");
        }

        internal static void RegisterEmployeeRoutes(this WebApplication app)
        {
            app.MapPost("/api/company/{id}/employee", ([FromServices] ICompanyService service, [FromRoute] int id, EmployeeModel employee) =>
            {
                service.AddEmployeeToCompany(employee, id);
            })
                .Accepts<EmployeeModel>("application/json")
                .Produces(StatusCodes.Status200OK)
                .WithTags("Companies");

            app.MapPut("/api/company/{id}/employee", ([FromServices] ICompanyService service, [FromRoute] int id, EmployeeModel employee) =>
            {
                service.UpdateEmployee(employee);
            })
                .Accepts<EmployeeModel>("application/json")
                .Produces(StatusCodes.Status200OK)
                .WithTags("Companies");

            app.MapDelete("/api/company/{id}/employee/{employeeId}", ([FromServices] ICompanyService service, [FromRoute] int id, [FromRoute] int employeeId) =>
            {
                service.RemoveEmployee(employeeId);
            })
                .Accepts<EmployeeModel>("application/json")
                .Produces(StatusCodes.Status200OK)
                .WithTags("Companies");
        }
    }
}
