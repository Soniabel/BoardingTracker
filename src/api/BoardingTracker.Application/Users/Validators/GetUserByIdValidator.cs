using BoardingTracker.Application.Users.Queries.GetUserById;
using FluentValidation;

namespace BoardingTracker.Application.Users.Validators
{
    public class GetUserByIdValidator : AbstractValidator<GetUserByIdRequest>
    {
        public GetUserByIdValidator()
        {
            RuleFor(user => user.Id).NotNull().NotEmpty();
        }
    }
}
