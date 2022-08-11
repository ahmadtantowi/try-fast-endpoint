using FluentValidation;

namespace TryFastEndpoint.Features.User;

public class GetUserValidator : Validator<GetUserRequest>
{
    public GetUserValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty();
    }
}
