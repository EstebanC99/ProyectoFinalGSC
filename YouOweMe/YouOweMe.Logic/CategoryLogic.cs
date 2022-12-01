using YouOweMe.Abstractions;
using YouOweMe.Entities.Factories.Interfaces;
using YouOweMe.Extensions;
using YouOweMe.Repositories.Categories;

namespace YouOweMe.Logic
{
    public class CategoryLogic : BaseLogic<ICategoryRepository>, ICategoryBusinessService
    {
        private ICategoryFactory Factory { get; set; }

        public CategoryLogic(ICategoryRepository repository,
                             IHelperMapper mapper,
                             ICategoryFactory factory)
            : base(repository, mapper)
        {
            this.Factory = factory;
        }

        public List<DataView.DataView> GetAll()
        {
            return this.Repository.GetAll().ConvertAll(c => this.Mapper.BaseEntityToDataView(c));
        }

        public DataView.DataView GetByID(int id)
        {
            var category = this.Repository.GetByID(id);

            if (category is null)
                throw new ValidationException("No se encontro la categoria buscada");

            return this.Mapper.BaseEntityToDataView(category);
        }

        public void Add(DataView.DataView category)
        {
            var newCategory = this.Factory.Crear();

            var categoryWithSameDescription = this.Repository.GetByDescription(category.Description);

            if (categoryWithSameDescription != null)
            {
                throw new ValidationException("Ya existe una categoria con la misma descripcion");
            }

            newCategory.SetCategory(this.Mapper.DataViewToValueObject(category));

            this.Repository.Add(newCategory);
        }

        public DataView.DataView Modify(DataView.DataView categoryDataView)
        {
            var category = this.Repository.GetByID(categoryDataView.ID.Value);

            if (category is null)
                throw new ValidationException("No se encontro la categoria buscada");

            var categoryWithSameDescription = this.Repository.GetByDescription(categoryDataView.Description);

            if (categoryWithSameDescription != null && categoryWithSameDescription.ID != category.ID)
                throw new ValidationException("La descripcion ingresada ya existe");

            category.SetCategory(this.Mapper.DataViewToValueObject(categoryDataView));

            this.Repository.Update(category);

            return this.Mapper.BaseEntityToDataView(category);
        }

        public void Delete(int categoryID)
        {
            var category = this.Repository.GetByID(categoryID);

            if (category is null)
                throw new ValidationException("No se encontro la categoria buscada");

            this.Repository.Delete(category);
        }
    }
}
