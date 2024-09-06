
using Catalog.API.Products.GetProducts;

namespace Catalog.API.Products.GetProductByCategory
{
    public record GetProductByCategoryResponse(Product Product);

    public class GetProductByCategoryEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products/{category}", async (string category, ISender sender) =>
            {
                var result = sender.Send(new GetProductByCategoryQuery(category));
                var response = result.Adapt<GetProductByCategoryResponse>();

                return Results.Ok(response);
            }).WithName("GetProductByCategory")
             .WithDescription("Get Product By Category")
            .Produces<GetProductByCategoryResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Product By Category");
        }
    }
}
