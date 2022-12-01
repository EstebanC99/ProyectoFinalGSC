using YouOweMe.DataView;

namespace YouOweMe.Abstractions
{
    public interface IThingBusinessService : IBaseBusinessService
    {
        List<ThingDataView> GetAll();

        ThingDataView GetByID(int id);

        void Add(ThingDataView thingDataView);

        ThingDataView Modify(ThingDataView thingDataView);

        void Delete(int thingID);
    }
}
