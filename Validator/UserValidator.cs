using loja_games.Model;
using FluentValidation;

namespace loja_games.Validator
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.Nome)
                .NotEmpty()
                .MaximumLength(255);

            RuleFor(u => u.Usuario)
                .NotEmpty()
                .EmailAddress();

            RuleFor(u => u.Senha)
                .NotEmpty()
                .MinimumLength(8);

            RuleFor(u => u.Foto)
                .MaximumLength(5000);
            
            RuleFor(u => u.DataNascimento)
                .LessThanOrEqualTo(u => DateTime.Today.AddYears(-18));
        }

    }
}