namespace Catalog.Api.Products.GetProductById;

public class GetProductByIdQueryHandler(IDocumentSession documentSession)
    : IQueryHandler<GetProductByIdQuery, GetProductByIdQueryResult>
{
    public async Task<GetProductByIdQueryResult> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await documentSession.Query<Product>().FirstOrDefaultAsync(x => x.Id == request.Id);
        if (product is null)
        {
            throw new ProductNotFoundException();
        }
        return new(product);
    }
}

public record GetProductByIdQuery(Guid Id) : IQuery<GetProductByIdQueryResult>;

public record GetProductByIdQueryResult(Product? Product);