using ErrorOr;
using MediatR;
using Microsoft.Extensions.Logging;
using UsersApi.Application.Commands;
using UsersApi.Domain.Entities;
using UsersApi.Domain.Repositories;

namespace UsersApi.Application.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ErrorOr<Created>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CreateUserCommandHandler> _logger;

        public CreateUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork, ILogger<CreateUserCommandHandler> logger)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<ErrorOr<Created>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User(
                request.FirstName, 
                request.LastName, 
                request.Email, 
                request.BirthDate,
                request.Scholarity
            );

            try
            {
                var existingUser = await _userRepository.FindByEmailAsync(request.Email, cancellationToken);

                if (existingUser != null)
                {
                    return Error.Validation("Email is already in use");
                }

                await _userRepository.InsertOneAsync(user, cancellationToken);

                _unitOfWork.Commit();

                return Result.Created;
            } catch (Exception ex)
            {
                _logger.LogCritical(ex, "An error occurred while attempted to create a new user");
                _unitOfWork.Dispose();

                return Error.Failure(ex.Message);
            }
        }
    }
}
