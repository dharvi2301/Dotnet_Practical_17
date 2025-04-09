using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Practical_17.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string? FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string? LastName { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Phone]
        public string? MobileNumber { get; set; }

        [Required]
        public string? Password { get; set; }

        [ForeignKey("Role")]
        public int RoleId { get; set; }

        public virtual Role? Role { get; set; }
    }
}
