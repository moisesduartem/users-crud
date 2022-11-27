using MediatR;
using Microsoft.Extensions.Logging;
using UsersApi.Application.Commands;
using UsersApi.Domain.Entities;
using UsersApi.Domain.Repositories;

namespace UsersApi.Application.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
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

        public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
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
                await Task.WhenAll(
                    _userRepository.InsertOneAsync(user, cancellationToken),
                    _unitOfWork.Commit()
                );
            } catch (Exception ex)
            {
                _logger.LogCritical(ex, "An error occurred while attempted to create a new user");
                _unitOfWork.Dispose();
            }

            return Unit.Value;
        }
    }
}
