namespace YouOweMe.Entities
{
    public class Person : BaseEntity
    {
        public string Nombre { get; private set; }

        public string Apellido { get; private set; }

        public string Mail { get; private set; }

        public string Telefono { get; private set; }
    }
}
