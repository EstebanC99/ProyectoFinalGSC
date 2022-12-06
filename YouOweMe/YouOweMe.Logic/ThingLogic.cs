using YouOweMe.Abstractions;
using YouOweMe.DataView;
using YouOweMe.Entities;
using YouOweMe.Entities.Factories.Interfaces;
using YouOweMe.Entities.Services;
using YouOweMe.Extensions;
using YouOweMe.Repositories.Categories;
using YouOweMe.Repositories.Things;

namespace YouOweMe.Logic
{
    public class ThingLogic : BaseLogic<IThingRepository>, IThingBusinessService, IThingDomainService
    {
        private IThingFactory Factory { get; set; }

        private ICategoryRepository CategoryRepository { get; set; }

        public ThingLogic(IThingRepository repository,
                          IHelperMapper mapper,
                          IThingFactory factory,
                          ICategoryRepository categoryRepository)
            : base(repository, mapper)
        {
            this.Factory = factory;
            this.CategoryRepository = categoryRepository;
        }

        public List<ThingDataView> GetAll()
        {
            return this.Repository.GetAll().ConvertAll(t => this.Mapper.ThingToThingDataView(t));
        }

        public ThingDataView GetByID(int id)
        {
            var thing = this.Repository.GetByID(id);

            if (thing is null)
                throw new ValidationException("No se encontro la cosa buscada");

            return this.Mapper.ThingToThingDataView(thing);
        }

        public void Add(ThingDataView thingDataView)
        {
            var newThing = this.Factory.Crear();

            var category = this.CategoryRepository.GetByID(thingDataView.Category.ID.Value);

            if (category is null)
                throw new ValidationException("No se encontro la Categoria seleccionada");

            newThing.SetThing(this.Mapper.ThingDataViewToRegisterThing(thingDataView, category));

            this.Repository.Add(newThing);
        }

        public ThingDataView Modify(ThingDataView thingDataView)
        {
            var thing = this.Repository.GetByID(thingDataView.ID.Value);

            if (thing is null)
                throw new ValidationException("No se encontro la cosa buscada");

            var category = this.CategoryRepository.GetByID(thingDataView.Category.ID.Value);

            if (category is null)
                throw new ValidationException("No se encontro la Categoria elegida");

            thing.SetThing(this.Mapper.ThingDataViewToRegisterThing(thingDataView, category));

            this.Repository.Update(thing);

            return this.Mapper.ThingToThingDataView(thing);
        }

        public void Delete(int thingID)
        {
            var thing = this.Repository.GetByID(thingID);

            if (thing is null)
                throw new ValidationException("No se encontro la cosa buscada");

            this.Repository.Delete(thing);
        }

        public int? GetBorrowedAmount(Thing thing)
        {
            return this.Repository.GetBorrowedAmount(thing);
        }
    }
}
