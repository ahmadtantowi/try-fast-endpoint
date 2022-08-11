using FluentValidation;

namespace TryFastEndpoint.Features.Auth.UserPassword;

public class UserPasswordValidator : Validator<UserPasswordRequest>
{
    public UserPasswordValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(50);

        RuleFor(x => x.Password).NotEmpty();
    }
}
