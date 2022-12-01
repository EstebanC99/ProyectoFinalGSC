using YouOweMe.Entities;

namespace YouOweMe.Repositories.Categories
{
    public interface ICategoryRepository: IBaseRepository
    {
        List<Category> GetAll();

        Category GetByID(int id);

        void Add(Category newCategory);

        void Update(Category category);

        void Delete(Category category);

        Category GetByDescription(string? description);
    }
}