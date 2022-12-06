using YouOweMe.Entities;

namespace YouOweMe.Repositories.Things
{
    public interface IThingRepository: IBaseRepository
    {
        List<Thing> GetAll();

        Thing GetByID(int id);

        void Add(Thing newThing);

        void Update(Thing thing);

        void Delete(Thing thing);

        int? GetBorrowedAmount(Thing thing);
    }
}