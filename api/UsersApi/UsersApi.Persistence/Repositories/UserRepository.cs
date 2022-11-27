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

        public async Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Users.AsNoTracking().ToListAsync(cancellationToken);
        }
    }
}
