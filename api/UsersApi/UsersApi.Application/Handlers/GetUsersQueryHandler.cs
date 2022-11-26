using AutoMapper;
using MediatR;
using UsersApi.Application.DTOs;
using UsersApi.Application.Queries;
using UsersApi.Domain.Entities;

namespace UsersApi.Application.Handlers
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IEnumerable<UserDTO>>
    {
        private readonly IMapper _mapper;

        public GetUsersQueryHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Task<IEnumerable<UserDTO>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = new List<User>();

            var result = _mapper.Map<IEnumerable<UserDTO>>(users);

            return Task.FromResult(result);
        }
    }
}
