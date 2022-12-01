using System.ComponentModel.DataAnnotations;

namespace YouOweMe.DataView
{
    public class ThingDataView : DataView
    {
        public ThingDataView()
        {
            this.Category = new DataView();
        }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Debe ingresar un Nombre")]
        public string? Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Debe ingresar un Nombre")]
        public string? Color { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Ingrese un valor")]
        [Range(0, 100, ErrorMessage = "Ingrese un numero entre 0 y 100")]
        public int Quantity { get; set; }

        [Required]
        public DataView? Category { get; set; }
    }
}
