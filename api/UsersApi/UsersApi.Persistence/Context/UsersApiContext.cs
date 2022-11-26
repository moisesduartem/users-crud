using Microsoft.EntityFrameworkCore;
using UsersApi.Domain.Entities;

namespace UsersApi.Persistence.Context
{
    public class UsersApiContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}
