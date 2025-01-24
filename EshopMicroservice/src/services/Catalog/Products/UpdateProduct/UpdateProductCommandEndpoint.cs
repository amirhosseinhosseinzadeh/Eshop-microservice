using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Products.UpdateProduct;

public class UpdateProductCommandEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/products", async ([FromBody] UpdateProductRequest request, [FromServices] ISender sender) =>
        {
            var command = request.Adapt<UpdateProductCommand>();
            var updateResult = await sender.Send(command);
            return Results.Ok(updateResult);
        });
    }
}


public record UpdateProductRequest(
    Guid Id,
    string Name,
    List<string> Categories,
    string Description,
    string ImageFile,
    decimal Price
);