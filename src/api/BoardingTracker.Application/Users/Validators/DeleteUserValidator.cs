using BoardingTracker.Application.Users.Commands.DeleteUser;
using FluentValidation;

namespace BoardingTracker.Application.Users.Validators
{
    public class DeleteUserValidator : AbstractValidator<DeleteUserRequest>
    {
        public DeleteUserValidator()
        {
            RuleFor(user => user.Id).NotNull().NotEmpty();
        }
    }
}
