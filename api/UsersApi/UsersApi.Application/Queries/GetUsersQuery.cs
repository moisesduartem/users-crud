using MediatR;
using UsersApi.Application.DTOs;

namespace UsersApi.Application.Queries
{
    public class GetUsersQuery : IRequest<IEnumerable<UserDTO>>
    {
    }
}
