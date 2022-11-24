using YouOweMe.Extensions;

namespace YouOweMe.Entities
{
    public class User : BaseEntity
    {
        public string Email { get; private set; }

        public string Password { get; private set; }

        public void ValidatePassword(string password)
        {
            if (!this.Password.Equals(password))
                throw new ValidationException("Password incorrecto!");
        }
    }
}
