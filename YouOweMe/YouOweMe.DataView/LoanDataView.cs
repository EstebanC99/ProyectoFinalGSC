namespace YouOweMe.DataView
{
    public class LoanDataView : DataView
    {
        public LoanDataView()
        {
            this.Thing = new ThingDataView();
            this.Person = new PersonDataView();
        }

        public ThingDataView Thing { get; set; }

        public PersonDataView Person { get; set; }

        public int BorrowedAmount { get; set; }

        public DateTime LoanDate { get; set; }

        public DateTime? ReturnDate { get; set; }
    }
}
