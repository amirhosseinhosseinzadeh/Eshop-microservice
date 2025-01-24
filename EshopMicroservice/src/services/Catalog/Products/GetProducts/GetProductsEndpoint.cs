using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Products.CreateProduct;

public class GetProductsEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products", async ([FromServices] ISender sender) =>
        {
            var queryResult = await sender.Send(new GetProductsQuery());
            return Results.Json(queryResult.Products, statusCode: StatusCodes.Status200OK);
        });
    }
}
