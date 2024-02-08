using G5Inventory.Models;
using FluentValidation;

namespace G5Inventory.Validatios
{
    public class CategoryValidator : AbstractValidator<CategoryModel>
    {
        public CategoryValidator()
        {
            RuleFor(cateogry => cateogry.CategoryName)
                .NotNull().WithMessage("Debe ingresar un nombre de categoría.")
                .NotEmpty().WithMessage("Debe ingresar un nombre de categoría.")
                .MinimumLength(3).WithMessage("Ingrese al menos 3 carácreres.")
                .MaximumLength(60).WithMessage("El nombre no debe superar los 60 carácteres.");

            RuleFor(cateogry => cateogry.CategoryInfo)
                .NotNull().WithMessage("Debe ingresar información de la categoría.")
                .NotEmpty().WithMessage("Debe ingresar detalles sobre la categoría.")
                .MinimumLength(1).WithMessage("Ingrese al menos 3 carácreres.")
                .MaximumLength(60).WithMessage("La información debe resumirse en 60 carácteres.");

            RuleFor(cateogry => cateogry.CategoryCode)
                .NotNull()
                .NotEmpty().WithMessage("Es necesario el código de la categoría.")
                .MinimumLength(5).WithMessage("El código debe ser de 6 carácteres")
                .MaximumLength(5).WithMessage("El código debe ser de 6 carácteres");

            RuleFor(cateogry => cateogry.CategoryStatus)
                .NotNull()
                .NotEmpty()
                .MinimumLength(2).WithMessage("Ingrese al menos 2 carácteres")
                .MaximumLength(10).WithMessage("El estado no debe superar los 10 carácteres.");

        }
    }
}