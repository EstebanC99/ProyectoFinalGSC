using System.ComponentModel.DataAnnotations;

namespace YouOweMe.DataView
{
    public class UserDataView : DataView
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

    }
}