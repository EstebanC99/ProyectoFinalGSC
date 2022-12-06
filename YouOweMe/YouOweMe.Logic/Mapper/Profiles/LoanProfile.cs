using AutoMapper;
using YouOweMe.DataView;
using YouOweMe.Entities;

namespace YouOweMe.Logic.Mapper.Profiles
{
    public class LoanProfile : Profile
    {
        public LoanProfile()
        {
            this.CreateMap<Loan, LoanDataView>()
                .ForMember(l => l.Thing, y => y.MapFrom(src => src.Thing))
                .ForMember(l => l.Person, y => y.MapFrom(src => src.Person));
        }
    }
}
