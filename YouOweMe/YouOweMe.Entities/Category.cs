using YouOweMe.Entities.ValueObjects;
using YouOweMe.Extensions;

namespace YouOweMe.Entities
{
    public class Category : BaseEntity
    {
        public void SetCategory(ValueObject registerCategory)
        {
            if (string.IsNullOrEmpty(registerCategory.Description))
            {
                throw new ValidationException("La descripcion es requerida en la Categoria");
            }

            this.Description = registerCategory.Description;
        }
    }
}
