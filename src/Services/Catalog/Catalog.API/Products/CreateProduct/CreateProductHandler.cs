
namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductCommand(string Name, List<string> Category,
        string Description, decimal Price, string ImageFile) : ICommand<CreateProductResult>;
    public record CreateProductResult(Guid Id);
    public class CreateProductHandler(IDocumentSession session) : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            //Create the product entity from the command object
            var product = new Product
            {
                Name = command.Name,
                Category = command.Category,
                Description = command.Description,
                Price = command.Price,
                ImageFile = command.ImageFile

            };

            //ToDo
            //Save the object to the database
            session.Store(product);
            await session.SaveChangesAsync(cancellationToken);

            //Return TResponse result
            return new CreateProductResult(product.Id);
        }
    }
}
