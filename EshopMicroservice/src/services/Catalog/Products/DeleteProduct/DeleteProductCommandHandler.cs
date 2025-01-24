
namespace Catalog.Api.Products.DeleteProduct;

public class DeleteProductCommandHandler(IDocumentSession documentSession) : ICommandHandler<DeleteProductCommand, DeleteProductCommandResult>
{
    public async Task<DeleteProductCommandResult> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
    {
        var document = await documentSession.Query<Product>().FirstOrDefaultAsync(x => x.Id == command.Id);
        if (document is null)
            throw new ProductNotFoundException();
        documentSession.Delete(document);
        await documentSession.SaveChangesAsync(cancellationToken);
        return new(true);
    }
}

public record DeleteProductCommand(Guid Id) : ICommand<DeleteProductCommandResult>;

public record DeleteProductCommandResult(bool Success);
