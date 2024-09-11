using Marten.Pagination;

namespace Catalog.API.Products.GetProducts
{
    public record GetPRoductsQuery(int? PageNumber = 1, int? PageSize = 10) : IQuery<GetProductsResult>;
    public record GetProductsResult(IEnumerable<Product> Products);
    public class GetProductsHandler(IDocumentSession session) : IQueryHandler<GetPRoductsQuery, GetProductsResult>
    {
        public async Task<GetProductsResult> Handle(GetPRoductsQuery query, CancellationToken cancellationToken)
        {
            var products = await session.Query<Product>().ToPagedListAsync(query.PageNumber ?? 1, query.PageSize ?? 10, cancellationToken);

            return new GetProductsResult(products);
        }
    }
}
