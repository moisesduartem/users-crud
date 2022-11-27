using FluentValidation;
using UsersApi.Application.Commands;

namespace UsersApi.Application.Validators
{
    public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserCommandValidator()
        {
            RuleFor(x => x.UserId).NotNull();
        }
    }
}
