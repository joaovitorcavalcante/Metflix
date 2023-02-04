using FluentValidation;

namespace Metflix.Application.Categories.Commands.CreateCategory
{
    public class CreateCategoryValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryValidator()
        {
            RuleFor(x => x.Name)
                .Length(5, 30)
                .WithMessage("O título deve possuir entre 5 e 30 caracteres.");

            RuleFor(x => x.Description)
                .MaximumLength(255)
                .WithMessage("A descrição deve ter no máximo 255 caracteres.");
        }
    }
}
