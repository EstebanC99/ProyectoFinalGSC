namespace YouOweMe.Entities.ValueObjects
{
    public class RegisterLoan : ValueObject
    {
        public Thing? Thing { get; set; }

        public Person? Person { get; set; }

        public int BorrowedAmount { get; set; }
    }
}
