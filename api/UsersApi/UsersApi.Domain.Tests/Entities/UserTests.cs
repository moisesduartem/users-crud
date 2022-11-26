using Moq;
using UsersApi.Domain.Entities;
using Xunit;

namespace UsersApi.Domain.Tests.Entities
{
    public class UserTests
    {
        [Fact]
        public void Validate_CorrectFields_ShouldBeValid()
        {
            User sut = new("FirstName", "LastName", "user@email.com", DateTime.Now.AddYears(-25));

            Assert.True(sut.IsValid);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Validate_NullOrEmptyFirstName_ShouldNotBeValid(string firstName)
        {
            User sut = new (firstName, "LastName", "user@email.com", DateTime.Now.AddYears(-25));

            Assert.False(sut.IsValid);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Validate_NullOrEmptyLastName_ShouldNotBeValid(string lastName)
        {
            User sut = new("FirstName", lastName, "user@email.com", DateTime.Now.AddYears(-25));

            Assert.False(sut.IsValid);
        }
        
        [Theory]
        [InlineData(null)]
        [InlineData("user")]
        [InlineData(" ")]
        [InlineData("")]
        public void Validate_InvalidEmail_ShouldNotBeValid(string email)
        {
            User sut = new("FirstName", "LastName", email, DateTime.Now.AddYears(-25));

            Assert.False(sut.IsValid);
        }

        [Fact]
        public void Validate_BirthDateInFuture_ShouldNotBeValid()
        {
            DateTime birthDate = DateTime.Now.AddDays(1);

            User sut = new("FirstName", "LastName", "user@email.com", birthDate);

            Assert.False(sut.IsValid);
        }
    }
}
