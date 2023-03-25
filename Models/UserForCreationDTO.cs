using System.ComponentModel.DataAnnotations;

namespace FoodsConnected.Models
{
    public class UserForCreationDTO
    {
        [Required(ErrorMessage = "You Should Provide a name")]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(50)]
        public string? Email { get; set; }

        [MaxLength(15)]
        public string? PhoneNumber { get; set; }
    }
}
