using FluentValidation;

namespace G3L.Examples.DDD.Application.Visiting.Visit.Commands.SignOut
{
    public class SignOutCommandValidator : AbstractValidator<SignOutCommand>
    {
        public SignOutCommandValidator()
        {
            RuleFor(x => x.Email)
                .EmailAddress()
                .NotEmpty();
        }
    }
}