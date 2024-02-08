using FluentValidation;
using G5Inventory.Models;

namespace G5Inventory.Validations
{
    public class ProductValidator : AbstractValidator<ProductModel>
    {
        public ProductValidator()
        {
            RuleFor(product => product.ProductName)
				.NotEmpty()
				.NotNull()
                .MaximumLength(75);
            RuleFor(product => product.Price)
                .IsInEnum()
                .NotEmpty()
                .NotNull();
            RuleFor(product => product.IdCategory)
				.IsInEnum()
				.NotEmpty()
                .NotNull();
            RuleFor(product => product.IdProvider)
				.IsInEnum()
				.NotEmpty()
                .NotNull();
            RuleFor(product => product.Expiration)
				.NotEmpty()
				.NotNull();
			RuleFor(product => product.Stock)
				.IsInEnum()
				.NotEmpty()
				.NotNull();
		}
    }
}
