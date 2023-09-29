using loja_games.Model;
using FluentValidation;

namespace loja_games.Validator
{
    public class ProdutoValidator : AbstractValidator<Produto>
    {

        public ProdutoValidator()
        {

            RuleFor(p => p.Nome)
                .NotEmpty();

            RuleFor(p => p.Descricao)
                .NotEmpty();

            RuleFor(p => p.Console)
                .NotEmpty();

            RuleFor(p => p.Preco)
                .NotNull()
                .GreaterThan(0)
                .PrecisionScale(20, 2, false);;

        }

    }
}
