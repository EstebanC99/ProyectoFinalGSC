using YouOweMe.Abstractions;
using YouOweMe.DataView;
using YouOweMe.Entities.Factories.Interfaces;
using YouOweMe.Extensions;
using YouOweMe.Repositories.Persons;

namespace YouOweMe.Logic
{
    public class PersonLogic : IPersonBusinessService
    {
        private IPersonRepository Repository { get; set; }

        private IHelperMapper Mapper { get; set; }

        private IPersonFactory Factory { get; set; }

        public PersonLogic(IPersonRepository repository, 
                           IHelperMapper mapper,
                           IPersonFactory factory)
        {
            this.Repository = repository;
            this.Mapper = mapper;
            this.Factory = factory;
        }

        public List<PersonDataView> GetAll()
        {
            return this.Repository.GetAll().ConvertAll(p => this.Mapper.PersonToPersonDataView(p));
        }

        public PersonDataView GetByID(int id)
        {
            var person = this.Repository.GetByID(id);

            if (person is null)
                throw new ValidationException("No se encontro la persona buscada");

            return this.Mapper.PersonToPersonDataView(person);
        }

        public void Add(PersonDataView person)
        {
            var newPerson = this.Factory.Crear();

            newPerson.SetPerson(this.Mapper.PersonDataViewToRegisterPerson(person));

            this.Repository.Add(newPerson);
        }

        public PersonDataView Modify(PersonDataView personDataView)
        {
            var person = this.Repository.GetByID(personDataView.ID);

            if (person is null)
                throw new ValidationException("No se encontro la persona buscada");

            person.SetPerson(this.Mapper.PersonDataViewToRegisterPerson(personDataView));

            this.Repository.Update(person);

            return this.Mapper.PersonToPersonDataView(person);
        }

        public void Delete(int personID)
        {
            var person = this.Repository.GetByID(personID);

            if (person is null)
                throw new ValidationException("No se encontro la persona buscada");

            this.Repository.Delete(person);
        }
    }
}
