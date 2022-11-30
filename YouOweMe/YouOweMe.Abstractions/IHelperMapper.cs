using YouOweMe.DataView;
using YouOweMe.Entities;
using YouOweMe.Entities.ValueObjects;

namespace YouOweMe.Abstractions
{
    public interface IHelperMapper
    {
        DataView.DataView BaseEntityToDataView(BaseEntity baseEntity);

        ValueObject DataViewToValueObject(DataView.DataView baseDataView);

        PersonDataView PersonToPersonDataView(Person person);

        RegisterPerson PersonDataViewToRegisterPerson(PersonDataView personDataView);
    }
}
