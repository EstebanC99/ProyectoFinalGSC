namespace YouOweMe.Entities
{
    public class Loan : BaseEntity
    {
        public Thing? Thing { get; private set; }

        public Person? Person { get; private set; }

        public int BorrowedAmount { get; private set; }

        public DateTime LoanDate { get; private set; }

        public DateTime? ReturnDate { get; private set; }
    }
}
