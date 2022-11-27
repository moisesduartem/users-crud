using ErrorOr;
using MediatR;
using Microsoft.Extensions.Logging;
using UsersApi.Application.Commands;
using UsersApi.Domain.Entities;
using UsersApi.Domain.Repositories;

namespace UsersApi.Application.Handlers
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, ErrorOr<Updated>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CreateUserCommandHandler> _logger;

        public UpdateUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork, ILogger<CreateUserCommandHandler> logger)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<ErrorOr<Updated>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userRepository.FindByIdAsync(request.Id, cancellationToken);

                if (user == null)
                {
                    return Error.NotFound();
                }

                var data = new User(
                    request.Id,
                    request.FirstName,
                    request.LastName,
                    request.Email,
                    request.BirthDate,
                    request.Scholarity
                );

                _userRepository.UpdateOne(data);

                _unitOfWork.Commit();

                return Result.Updated;
            } catch (Exception ex)
            {
                _logger.LogCritical(ex, "An error occurred while attempted to create a new user");
                _unitOfWork.Dispose();

                return Error.Failure(ex.Message);
            }
        }
    }
}
