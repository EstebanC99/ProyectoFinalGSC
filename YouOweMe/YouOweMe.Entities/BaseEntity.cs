namespace YouOweMe.Entities
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {

        }

        public int ID { get; protected set; }

        public string? Description { get; protected set; }
    }
}