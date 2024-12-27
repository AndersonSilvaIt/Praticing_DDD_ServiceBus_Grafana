using FluentValidation;
using ProductManager.Application.Commands;

namespace ProductManager.Application.Validators
{
	public class CreateProductCommandValidator: AbstractValidator<CreateProductCommand>
	{
		public CreateProductCommandValidator()
		{
			RuleFor(c => c.Name)
				.NotEmpty().WithMessage("O nome do produto é obrigatório.")
				.MaximumLength(100).WithMessage("O nome do produto deve ter no máximo 100 caracteres.");

			RuleFor(c => c.Price)
				.GreaterThan(0).WithMessage("O preço do produto deve ser maior que zero.");

			RuleFor(c => c.StockAmount)
				.GreaterThanOrEqualTo(0).WithMessage("A quantidade em estoque não pode ser negativa.");
		}
	}
}