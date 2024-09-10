
using FluentValidation;

namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductCommand(string Name, List<string> Category,
        string Description, decimal Price, string ImageFile) : ICommand<CreateProductResult>;

    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {

                RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
                RuleFor(x => x.Category).NotEmpty().WithMessage("Category is required");
                RuleFor(x => x.ImageFile).NotEmpty().WithMessage("ImageFile is required");
                RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
        }

    }
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
