using BoardingTracker.Application.Users.Commands.CreateUser;
using FluentValidation;

namespace BoardingTracker.Application.Users.Validators
{
    public class CreateUserValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserValidator()
        {
            RuleFor(user => user.Email).NotEmpty().NotNull().MaximumLength(50);
            RuleFor(user => user.Password).NotEmpty().NotNull().MaximumLength(100);
            RuleFor(user => user.Role).NotEmpty().NotNull().MaximumLength(20);
        }
    }
}
