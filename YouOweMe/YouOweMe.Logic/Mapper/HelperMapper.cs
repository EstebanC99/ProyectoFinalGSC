using AutoMapper;
using YouOweMe.Abstractions;
using YouOweMe.DataView;
using YouOweMe.Entities;
using YouOweMe.Entities.ValueObjects;

namespace YouOweMe.Logic.Mapper
{
    public class HelperMapper : IHelperMapper
    {
        private readonly IMapper Mapper;

        public HelperMapper(IMapper mapper)
        {
            Mapper = mapper;
        }

        #region Person Mapping

        public PersonDataView PersonToPersonDataView(Person person)
        {
            return this.Mapper.Map<Person, PersonDataView>(person);
        }

        public RegisterPerson PersonDataViewToRegisterPerson(PersonDataView personDataView)
        {
            return this.Mapper.Map<PersonDataView, RegisterPerson>(personDataView);
        }

        #endregion
    }
}
