using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Products.DeleteProduct;

public class DeleteProductCommandEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/products/{id:guid}", 
            async ([AsParameters] DeleteProductRequest request, [FromServices] ISender sender) =>
        {
            var command = request.Adapt<DeleteProductCommand>();
            var commandReult = await sender.Send(command);
            return Results.Ok(commandReult);
        });
    }
}

public record DeleteProductRequest(Guid Id);