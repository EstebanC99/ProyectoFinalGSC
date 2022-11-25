namespace YouOweMe.Entities.ValueObjects
{
    public class RegisterPerson : ValueObject
    {
        public string Name { get; set; }

        public string Lastname { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }
    }
}
