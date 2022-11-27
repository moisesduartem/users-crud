using Microsoft.EntityFrameworkCore;
using UsersApi.Domain.Entities;

namespace UsersApi.Persistence.Context
{
    public class UsersApiContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Server=localhost;Database=UsersApi;Trusted_Connection=True;");
        }
    }
}
