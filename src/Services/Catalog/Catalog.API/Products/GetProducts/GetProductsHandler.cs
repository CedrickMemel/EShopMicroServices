namespace Catalog.API.Products.GetProducts
{
    public record GetPRoductsQuery() : IQuery<GetProductsResult>;
    public record GetProductsResult(IEnumerable<Product> Products);
    public class GetProductsHandler(IDocumentSession session, ILogger<GetProductsHandler> logger) : IQueryHandler<GetPRoductsQuery, GetProductsResult>
    {
        public async Task<GetProductsResult> Handle(GetPRoductsQuery query, CancellationToken cancellationToken)
        {
            logger.LogInformation("GetProductsHandler.handle call with {@Query}", query);

            var products = await session.Query<Product>().ToListAsync(cancellationToken);

            return new GetProductsResult(products);
        }
    }
}
