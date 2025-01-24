using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Products.GetProductById;

public class GetProductByIdQueryEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/{id:guid}",
            async ([AsParameters] GetProductByIdRequest request, [FromServices] ISender sender) =>
        {
            var query = request.Adapt<GetProductByIdQuery>();
            var queryResult = await sender.Send(query);
            return Results.Json(queryResult, statusCode: StatusCodes.Status200OK);
        });
    }
}

public record GetProductByIdRequest(Guid Id);
