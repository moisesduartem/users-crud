using UsersApi.Domain.Entities;

namespace UsersApi.Domain.Repositories
{
    public interface IUserRepository
    {
        Task DeleteOneAsync(int userId, CancellationToken cancellationToken);
        Task<User?> FindByEmailAsync(string email, CancellationToken cancellationToken);
        Task<User?> FindByIdAsync(int userId, CancellationToken cancellationToken);
        Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken);
        Task InsertOneAsync(User user, CancellationToken cancellationToken);
    }
}
