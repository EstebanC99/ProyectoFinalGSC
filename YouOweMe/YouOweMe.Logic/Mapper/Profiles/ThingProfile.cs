using AutoMapper;
using YouOweMe.DataView;
using YouOweMe.Entities;
using YouOweMe.Entities.ValueObjects;

namespace YouOweMe.Logic.Mapper.Profiles
{
    public class ThingProfile : Profile
    {
        public ThingProfile()
        {
            this.CreateMap<Thing, ThingDataView>().ForMember(c => c.Category, y => y.MapFrom(src => src.Category));
            this.CreateMap<ThingDataView, RegisterThing>().ForMember(t => t.Category, y => y.Ignore());
        }
    }
}
