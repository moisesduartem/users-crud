using UsersApi.Domain.Enums;

namespace UsersApi.Application.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public Scholarity Scholarity { get; set; }
    }
}
