namespace G3L.Examples.NTier.APIv6;

internal static class VisitRegistrator
{

    internal static void RegisterVisitRoutes(this WebApplication app)
    {
        app.MapGet($"/api/visit/open", async ([FromServices] IVisitService visitService) => Results.Ok(await visitService.GetOpenVisits()))
            .Produces<Response<VisitModel>>(StatusCodes.Status200OK)
            .WithTags("Visits");

        app.MapGet($"/api/visit", async ([FromServices] IVisitService visitService) => Results.Ok(await visitService.GetVisits()))
            .Produces<Response<VisitModel>>(StatusCodes.Status200OK)
            .WithTags("Visits");


        app.MapPost($"/api/visit/signin", async ([FromServices] IVisitService visitService, [FromBody] StartVisitModel startVisit) =>
        {
            await visitService.RegisterVisit(startVisit);
            return Results.Ok();
        })
            .Accepts<StartVisitModel>("application/json")
            .Produces(StatusCodes.Status201Created)
            .WithTags("Visits");

        app.MapPost($"/api/visit/signout", async ([FromServices] IVisitService visitService, [FromBody] StopVisitModel stopVisit) =>
        {
            await visitService.CloseVisit(stopVisit);
            return Results.Ok();
        })
            .Accepts<StopVisitModel>("application/json")
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithTags("Visits");
    }
}

