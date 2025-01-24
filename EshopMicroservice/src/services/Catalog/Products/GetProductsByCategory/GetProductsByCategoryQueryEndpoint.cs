using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Products.GetProductsByCategory;

public class GetProductsByCategoryQueryEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/{category}",
            async ([AsParameters] GetProductsByCategoryRequest request, [FromServices] ISender sender) =>
        {
            var query = request.Adapt<GetProductsByCategoryQuery>();
            var queryResult = await sender.Send(query);
            return Results.Ok(queryResult);
        });
    }
}

public record GetProductsByCategoryRequest(string Category);