namespace Catalog.API.Products.GetProducts
{
    public record GetPRoductsQuery() : IQuery<GetProductsResult>;
    public record GetProductsResult(IEnumerable<Product> Products);
    public class GetProductsHandler(IDocumentSession session) : IQueryHandler<GetPRoductsQuery, GetProductsResult>
    {
        public async Task<GetProductsResult> Handle(GetPRoductsQuery query, CancellationToken cancellationToken)
        {
            var products = await session.Query<Product>().ToListAsync(cancellationToken);

            return new GetProductsResult(products);
        }
    }
}
