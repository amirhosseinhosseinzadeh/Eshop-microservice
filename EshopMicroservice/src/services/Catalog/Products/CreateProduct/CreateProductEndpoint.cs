using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Products.CreateProduct;

public class CreateProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/products",
            async ([FromBody] CreateProductRequest createRequestProduct, [FromServices] ISender sender) =>
        {
            var command = createRequestProduct.Adapt<CreateProductCommand>();
            var result = await sender.Send<CreateProductResult>(command);
            var response = result.Adapt<CreateProductResponse>();
            return Results.Created($"/products/{response.Id}",response);
        })
            .WithName("CreateProduct")
            .Produces<CreateProductResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Create Product")
            .WithDescription("Desc");
    }
}

public record CreateProductRequest(
    string Name,
    List<string> Categories,
    string Description,
    string ImageFile,
    decimal Price
    );

public record CreateProductResponse(Guid Id);
