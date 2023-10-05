using loja_games.Model;
using FluentValidation;

namespace loja_games.Validator
{
    public class CategoriaValidator : AbstractValidator<Categoria>
    {
        public CategoriaValidator() {

            RuleFor(p => p.Tipo)
                .NotEmpty();
        }
    }
}
