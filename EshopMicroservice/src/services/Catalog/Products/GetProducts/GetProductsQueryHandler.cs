
namespace Catalog.Api.Products.CreateProduct;

internal class GetProductsQueryHandler(IDocumentSession documentSession)
    : IQueryHandler<GetProductsQuery, GetProductsResult>
{
    public async Task<GetProductsResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
    {
        var products = await documentSession.Query<Product>().ToListAsync(cancellationToken);
        return new(products);
    }
}

public record GetProductsQuery() : IQuery<GetProductsResult>;

public record GetProductsResult(IEnumerable<Product> Products);