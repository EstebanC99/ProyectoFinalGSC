using YouOweMe.Entities;

namespace YouOweMe.Repositories.Persons
{
    public class PersonRepository : IPersonRepository
    {
        private IYouOweMeContext Context { get; set; }

        public PersonRepository(IYouOweMeContext context)
        {
            this.Context = context;
        }

        public List<Person> GetAll()
        {
            return this.Context.Persons.ToList();
        }

        public Person GetByID(int id)
        {
            return this.Context.Persons.FirstOrDefault(p => p.ID == id);
        }

        public void Add(Person newPerson)
        {
            this.Context.Persons.Add(newPerson);

            this.Context.SaveChanges();
        }

        public void Update(Person person)
        {
            this.Context.Persons.Update(person);

            this.Context.SaveChanges();
        }

        public void Delete(Person person)
        {
            this.Context.Persons.Remove(person);

            this.Context.SaveChanges();
        }
    }
}
