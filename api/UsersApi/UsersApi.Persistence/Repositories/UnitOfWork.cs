using UsersApi.Domain.Repositories;
using UsersApi.Persistence.Context;

namespace UsersApi.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UsersApiContext _context;

        public UnitOfWork(UsersApiContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.DisposeAsync();
        }
    }
}
