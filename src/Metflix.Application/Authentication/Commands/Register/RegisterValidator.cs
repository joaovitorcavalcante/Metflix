using FluentValidation;

namespace Metflix.Application.Authentication.Commands.Register
{
    public class RegisterValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterValidator() 
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Nome é obrigatório");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email esta inválido");
            RuleFor(x => x.Password).MinimumLength(8).WithMessage("Senha deve contem pelo menos 8 caracteres");
        }
    }
}
