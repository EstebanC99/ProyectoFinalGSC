using YouOweMe.Extensions;

namespace YouOweMe.Entities
{
    public class User : BaseEntity
    {
        public string? Email { get; private set; }

        public string? Password { get; private set; }

        public void ValidatePassword(string password)
        {
            if (string.IsNullOrEmpty(password))
                throw new ValidationException("La Password no puede ser nula");

            if (string.IsNullOrEmpty(this.Password) || !this.Password.Equals(password))
                throw new ValidationException("Password incorrecto!");
        }
    }
}
