using ErrorOr;
using MediatR;
using UsersApi.Domain.Enums;

namespace UsersApi.Application.Commands
{
    public class CreateUserCommand : IRequest<ErrorOr<Created>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public Scholarity Scholarity { get; set; }
    }
}
