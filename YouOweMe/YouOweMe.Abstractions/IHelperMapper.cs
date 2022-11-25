using YouOweMe.DataView;
using YouOweMe.Entities;
using YouOweMe.Entities.ValueObjects;

namespace YouOweMe.Abstractions
{
    public interface IHelperMapper
    {
        PersonDataView PersonToPersonDataView(Person person);

        RegisterPerson PersonDataViewToRegisterPerson(PersonDataView personDataView);
    }
}
