using YouOweMe.Abstractions;
using YouOweMe.Repositories;

namespace YouOweMe.Logic
{
    public abstract class BaseLogic<TRepository> : IBaseBusinessService
        where TRepository : IBaseRepository
    {
        protected TRepository Repository { get; set; }

        protected IHelperMapper Mapper { get; set; }

        public BaseLogic(TRepository repository,
                         IHelperMapper mapper)
        {
            this.Repository = repository;
            this.Mapper = mapper;
        }
    }
}
