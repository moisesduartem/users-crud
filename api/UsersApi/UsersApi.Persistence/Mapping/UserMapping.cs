using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UsersApi.Domain.Entities;

namespace UsersApi.Persistence.Mapping
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(nameof(User));

            builder.HasKey(x => x.Id);
            
            builder.Property(x => x.FirstName).IsRequired();
            builder.Property(x => x.LastName).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.BirthDate).IsRequired();
            builder.Property(x => x.Scholarity).IsRequired();

            builder.HasIndex(x => x.Email, "IX_User_Email").IsUnique();
        }
    }
}
