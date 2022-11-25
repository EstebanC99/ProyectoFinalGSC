using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace YouOweMe.DataView
{
    public class PersonDataView : DataView
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Lastname { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }
    }
}
