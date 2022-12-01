using YouOweMe.Entities;

namespace YouOweMe.Repositories.Persons
{
    public interface IPersonRepository: IBaseRepository
    {
        List<Person> GetAll();

        Person GetByID(int id);

        void Add(Person newPerson);

        void Update(Person person);

        void Delete(Person person);
    }
}