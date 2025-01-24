namespace Catalog.Api.Products.UpdateProduct;

public class UpdateProductCommandHandler(IDocumentSession documentSession)
    : ICommandHandler<UpdateProductCommand, UpdateProductCommandResult>
{
    public async Task<UpdateProductCommandResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        var product = documentSession.Query<Product>().FirstOrDefault(x => x.Id == command.Id)
            ?? throw new ProductNotFoundException();
        product = command.Adapt<Product>();
        documentSession.Update(product);
        await documentSession.SaveChangesAsync(cancellationToken);
        return new(true);
    }
}

public record UpdateProductCommand(
    Guid Id,
    string Name,
    List<string> Categories,
    string Description,
    string ImageFile,
    decimal Price
) : ICommand<UpdateProductCommandResult>;

public record UpdateProductCommandResult(bool Success);
