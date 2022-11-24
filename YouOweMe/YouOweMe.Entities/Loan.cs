namespace YouOweMe.Entities
{
    public class Loan : BaseEntity
    {
        public Thing Thing { get; private set; }

        public Person Person { get; private set; }

        public int CantidadPrestada { get; private set; }

        public DateTime FechaPrestamo { get; private set; }

        public DateTime? FechaDevolucion { get; private set; }
    }
}
