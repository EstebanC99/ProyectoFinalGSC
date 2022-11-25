namespace YouOweMe.Entities.Factories.Interfaces
{
    public interface IEntityFactory<TEntity> where TEntity : BaseEntity
    {
        TEntity Crear();
    }
}