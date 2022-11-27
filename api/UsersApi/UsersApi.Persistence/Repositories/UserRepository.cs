using Microsoft.EntityFrameworkCore;
using UsersApi.Domain.Entities;
using UsersApi.Domain.Repositories;
using UsersApi.Persistence.Context;

namespace UsersApi.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UsersApiContext _context;

        public UserRepository(UsersApiContext context)
        {
            _context = context;
        }

        public async Task DeleteOneAsync(int userId, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstAsync(x => x.Id == userId, cancellationToken);

            _context.Remove(user);
        }

        public Task<User?> FindByEmailAsync(string email, CancellationToken cancellationToken)
        {
            return _context.Users.AsNoTracking().FirstOrDefaultAsync(
                x => x.Email.ToLower() == email.ToLower(), 
                cancellationToken
           );
        }

        public Task<User?> FindByIdAsync(int userId, CancellationToken cancellationToken)
        {
            return _context.Users.AsNoTracking().FirstOrDefaultAsync(
                x => x.Id == userId,
                cancellationToken
           );
        }

        public async Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Users.AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task InsertOneAsync(User user, CancellationToken cancellationToken)
        {
            await _context.Users.AddAsync(user);
        }
    }
}
