using YouOweMe.Entities.Factories.Interfaces;

namespace YouOweMe.Entities.Factories
{
    public abstract class EntityFactory<TEntity> : IEntityFactory<TEntity>
        where TEntity: BaseEntity, new()
    {
        public TEntity Crear()
        {
            return new TEntity();
        }
    }
}
