using YouOweMe.DataView;

namespace YouOweMe.Abstractions
{
    public interface IPersonBusinessService: IBaseBusinessService
    {
        public List<PersonDataView> GetAll();

        public PersonDataView GetByID(int id);

        void Add(PersonDataView person);

        PersonDataView Modify(PersonDataView personDataView);

        void Delete(int personID);
    }
}
