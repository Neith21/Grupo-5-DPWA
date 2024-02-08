using FluentValidation;
using G5Inventory.Models;

namespace G5Inventory.Validations
{
    public class ProviderValidator : AbstractValidator<ProviderModel>
    {
        public ProviderValidator()
        {
            RuleFor(provider => provider.ProviderName)
                .NotNull().WithMessage("El nombre no debe estar vacio")
                .NotEmpty()
                .MinimumLength(3).WithMessage("Debe ingresar minimo 3 letras")
                .MaximumLength(75);

            RuleFor(provider => provider.Phone)
                .NotNull().WithMessage("El número no debe estar vacio")
                .NotEmpty()
                .MinimumLength(3).WithMessage("Debe ingresar minimo 3 numeros")
                .MaximumLength(25);

            RuleFor(provider => provider.Email)
                .NotNull().WithMessage("El Email no debe estar vacio")
                .NotEmpty()
                .MinimumLength(5).WithMessage("Debe ingresar minimo 3 letras")
                .MaximumLength(80);

            RuleFor(provider => provider.Delivery)
                .NotNull().WithMessage("El nombre no debe estar vacio")
                .NotEmpty()
                .MinimumLength(2).WithMessage("Debe ingresar minimo 2 letras")
                .MaximumLength(5);
        }
    }
}
