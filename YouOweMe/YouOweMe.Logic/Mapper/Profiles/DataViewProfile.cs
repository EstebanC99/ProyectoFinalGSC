using AutoMapper;
using YouOweMe.Entities;
using YouOweMe.Entities.ValueObjects;

namespace YouOweMe.Logic.Mapper.Profiles
{
    public class DataViewProfile : Profile
    {
        public DataViewProfile()
        {
            this.CreateMap<BaseEntity, DataView.DataView>();
            this.CreateMap<DataView.DataView, ValueObject>();
        }
    }
}
