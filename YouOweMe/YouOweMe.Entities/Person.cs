using YouOweMe.Entities.ValueObjects;
using YouOweMe.Extensions;

namespace YouOweMe.Entities
{
    public class Person : BaseEntity
    {
        public string Name { get; private set; }

        public string Lastname { get; private set; }

        public string? Email { get; private set; }

        public string? Phone { get; private set; }

        public void SetPerson(RegisterPerson registerPerson)
        {
            this.ValidateName(registerPerson.Name);
            this.ValidateLastname(registerPerson.Lastname);
            this.ValidateContactField(registerPerson.Email, registerPerson.Phone);

            this.Name = registerPerson.Name;
            this.Lastname = registerPerson.Lastname;
            this.Email = registerPerson.Email;
            this.Phone = registerPerson.Phone;
        }

        private void ValidateName(string? name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ValidationException("El nombre es requerido");
            }
        }

        private void ValidateLastname(string? lastname)
        {
            if (string.IsNullOrEmpty(lastname))
            {
                throw new ValidationException("El apellido es requerido");
            }
        }

        private void ValidateContactField(string? email, string? phone)
        {
            if (string.IsNullOrEmpty(email) && string.IsNullOrEmpty(phone))
            {
                throw new ValidationException("Se requiere al menos un medio de contacto (mail o telefono)");
            }
        }
    }
}
