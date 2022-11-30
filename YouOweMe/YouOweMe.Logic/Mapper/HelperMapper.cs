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

        #region BaseDataView Mapping

        public DataView.DataView BaseEntityToDataView(BaseEntity baseEntity)
        {
            return this.Mapper.Map<BaseEntity, DataView.DataView>(baseEntity);
        }

        public ValueObject DataViewToValueObject(DataView.DataView baseDataView)
        {
            return this.Mapper.Map<DataView.DataView, ValueObject>(baseDataView);
        }

        #endregion

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
