using ErrorOr;
using MediatR;

namespace UsersApi.Application.Commands
{
    public class DeleteUserCommand : IRequest<ErrorOr<Deleted>>
    {
        public int UserId { get; set; }
    }
}
