using AutoMapper;
using YouOweMe.DataView;
using YouOweMe.Entities;
using YouOweMe.Entities.ValueObjects;

namespace YouOweMe.Logic.Mapper.Profiles
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            this.CreateMap<Person, PersonDataView>();
            this.CreateMap<PersonDataView, RegisterPerson>();
        }
    }
}
