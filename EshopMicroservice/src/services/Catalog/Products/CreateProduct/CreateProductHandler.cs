namespace Catalog.Api.Products.CreateProduct;

internal class CreateProductCommandHandler(IDocumentSession documentSession) : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = request.Adapt<Product>();
        documentSession.Store(product);
        await documentSession.SaveChangesAsync(cancellationToken);
        return new CreateProductResult(product.Id);
    }
}

public record CreateProductCommand(
    string Name,
    List<string> Categories,
    string Description,
    string ImageFile,
    decimal Price
    ) : ICommand<CreateProductResult>;

public record CreateProductResult(Guid Id);
