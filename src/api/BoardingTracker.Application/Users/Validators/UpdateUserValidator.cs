using BoardingTracker.Application.Users.Commands.UpdateUser;
using FluentValidation;

namespace BoardingTracker.Application.Users.Validators
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserRequest>
    {
        public UpdateUserValidator()
        {
            RuleFor(user => user.Id).NotNull().NotEmpty();
            RuleFor(user => user.Email).NotEmpty().NotNull().MaximumLength(50);
            RuleFor(user => user.Password).NotEmpty().NotNull().MaximumLength(100);
            RuleFor(user => user.Role).NotEmpty().NotNull().MaximumLength(20);
        }
    }
}
