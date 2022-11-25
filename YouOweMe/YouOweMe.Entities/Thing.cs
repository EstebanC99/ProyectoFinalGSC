namespace YouOweMe.Entities
{
    public class Thing : BaseEntity
    {
        public string? Name { get; private set; }

        public string? Color { get; private set; }

        public int Quantity { get; private set; }

        public Category? Category { get; private set; }
    }
}
