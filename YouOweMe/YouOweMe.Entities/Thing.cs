namespace YouOweMe.Entities
{
    public class Thing : BaseEntity
    {
        public string? Nombre { get; private set; }

        public string? Color { get; private set; }

        public int Cantidad { get; private set; }

        public Category Category { get; private set; }
    }
}
