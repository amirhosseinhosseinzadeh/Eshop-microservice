
namespace Catalog.Api.Products.GetProductsByCategory;

public class GetProductsByCategoryQueryHandler(IDocumentSession documentSession) : IQueryHandler<GetProductsByCategoryQuery, GetProductsByCategoryQueryResult>
{
    public async Task<GetProductsByCategoryQueryResult> Handle(GetProductsByCategoryQuery request, CancellationToken cancellationToken)
    {
        var products = await documentSession.Query<Product>()
            .Where(x => x.Categories.Contains(request.Category))
            .ToListAsync();
        if (products.Count is 0)
            throw new ProductNotFoundException();
        return new(products);
    }
}

public record GetProductsByCategoryQueryResult(IEnumerable<Product> Products);

public record GetProductsByCategoryQuery(string Category) : IQuery<GetProductsByCategoryQueryResult>;