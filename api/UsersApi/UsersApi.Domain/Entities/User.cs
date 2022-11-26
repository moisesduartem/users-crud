using System.ComponentModel.DataAnnotations;
using UsersApi.Domain.Enums;

namespace UsersApi.Domain.Entities
{
    public sealed class User : Entity
    {
        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public Scholarity Scholarity { get; private set; }

        public User(string firstName, string lastName, string email, DateTime birthDate, Scholarity scholarity = Scholarity.Primary)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            BirthDate = birthDate;
            Scholarity = scholarity;

            Validate();
        }

        public override void Validate()
        {
            if (string.IsNullOrEmpty(FirstName) || string.IsNullOrEmpty(LastName))
                IsValid = false;

            var birthDateIsAfterToday = BirthDate.CompareTo(DateTime.Now) > 0;

            if (birthDateIsAfterToday)
                IsValid = false;

            var emailValidator = new EmailAddressAttribute();

            if (!emailValidator.IsValid(Email))
                IsValid = false;
        }
    }
}
