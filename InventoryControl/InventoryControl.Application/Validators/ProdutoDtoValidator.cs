using FluentValidation;
using InventoryControl.Application.DTOs;

namespace InventoryControl.Application.Validators;

public class ProdutoDtoValidator : AbstractValidator<ProdutoDto>
{
    public ProdutoDtoValidator()
    {
        RuleFor(x => x.Nome).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Preco).GreaterThan(0m);
    }
}
