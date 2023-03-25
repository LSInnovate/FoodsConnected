using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FoodsConnected.Contexts.UserInfo.Entities
{
    public class UserEntity
    {
        public UserEntity(string name)
        {
            Name = name;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string? Email { get; set; }

        [MaxLength(15)]
        public string? PhoneNumber { get; set; }
    }
}
