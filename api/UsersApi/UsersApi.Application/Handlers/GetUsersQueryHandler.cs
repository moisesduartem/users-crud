using AutoMapper;
using MediatR;
using UsersApi.Application.DTOs;
using UsersApi.Application.Queries;
using UsersApi.Domain.Repositories;

namespace UsersApi.Application.Handlers
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IEnumerable<UserDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public GetUsersQueryHandler(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserDTO>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllAsync(cancellationToken);

            var result = _mapper.Map<IEnumerable<UserDTO>>(users);

            return result;
        }
    }
}
