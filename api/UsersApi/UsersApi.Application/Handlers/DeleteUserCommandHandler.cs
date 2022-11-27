using ErrorOr;
using MediatR;
using Microsoft.Extensions.Logging;
using UsersApi.Application.Commands;
using UsersApi.Domain.Repositories;

namespace UsersApi.Application.Handlers
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, ErrorOr<Deleted>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CreateUserCommandHandler> _logger;

        public DeleteUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork, ILogger<CreateUserCommandHandler> logger)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<ErrorOr<Deleted>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingUser = await _userRepository.FindByIdAsync(request.UserId, cancellationToken);

                if (existingUser is null)
                {
                    return Error.NotFound();
                }

                await _userRepository.DeleteOneAsync(request.UserId, cancellationToken);

                _unitOfWork.Commit();

                return Result.Deleted;
            } catch (Exception ex)
            {
                _logger.LogCritical(ex, "An error occurred while attempted to delete user");
                _unitOfWork.Dispose();

                return Error.Failure();
            }

        }
    }
}
