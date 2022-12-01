using YouOweMe.Entities.ValueObjects;
using YouOweMe.Extensions;

namespace YouOweMe.Entities
{
    public class Thing : BaseEntity
    {
        public string? Name { get; private set; }

        public string? Color { get; private set; }

        public int Quantity { get; private set; }

        public Category? Category { get; private set; }

        public void SetThing(RegisterThing registerThing)
        {
            if (string.IsNullOrEmpty(registerThing.Name))
                throw new ValidationException("El Nombre es requerido!");

            if (registerThing.Quantity == default)
                throw new ValidationException("La cantidad debe ser mayor a cero!");

            if (string.IsNullOrEmpty(registerThing.Description))
                throw new ValidationException("Debe ingresar una descripcion!");
            
            if (registerThing.Category is null)
                throw new ValidationException("Debe elegir una categoria!");

            this.Name = registerThing.Name;
            this.Description = registerThing.Description;
            this.Color = registerThing.Color;
            this.Quantity = registerThing.Quantity;
            this.Category = registerThing.Category;
        }
    }
}
