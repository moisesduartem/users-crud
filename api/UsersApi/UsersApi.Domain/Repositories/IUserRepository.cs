using UsersApi.Domain.Entities;

namespace UsersApi.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken);
        Task InsertOneAsync(User user, CancellationToken cancellationToken);
    }
}
