using YouOweMe.Extensions;

namespace YouOweMe.Entities
{
    public class Loan : BaseEntity
    {
        public Thing? Thing { get; private set; }

        public Person? Person { get; private set; }

        public int BorrowedAmount { get; private set; }

        public DateTime LoanDate { get; private set; }

        public DateTime? ReturnDate { get; private set; }

        public Loan() { }

        public Loan(Thing thing, Person person, int borrowedAmount) : this()
        {
            if (thing is null)
                throw new ValidationException("Debe seleccionar una cosa");

            if (person is null)
                throw new ValidationException("Debe elegir una persona");

            if (borrowedAmount <= 0)
                throw new ValidationException("La cantidad prestada debe ser mayor a cero");

            this.Thing = thing;
            this.Person = person;
            this.BorrowedAmount = borrowedAmount;
            this.LoanDate = DateTime.Now;
        }

        public void Close()
        {
            this.ReturnDate = DateTime.Now;
        }
    }
}
