using YouOweMe.Entities;

namespace YouOweMe.Repositories.Categories
{
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        public CategoryRepository(IYouOweMeContext context) : base(context)
        {

        }

        public List<Category> GetAll()
        {
            return this.Context.Categories.ToList();
        }

        public Category GetByID(int id)
        {
            return this.Context.Categories.FirstOrDefault(p => p.ID == id);
        }

        public void Add(Category newCategory)
        {
            this.Context.Categories.Add(newCategory);

            this.Context.SaveChanges();
        }

        public void Update(Category category)
        {
            this.Context.Categories.Update(category);

            this.Context.SaveChanges();
        }

        public void Delete(Category category)
        {
            this.Context.Categories.Remove(category);

            this.Context.SaveChanges();
        }

        public Category GetByDescription(string? description)
        {
            if (string.IsNullOrEmpty(description))
                return null;

            return this.Context.Categories.FirstOrDefault(c => c.Description.ToLower().Equals(description.ToLower()));
        }
    }
}
