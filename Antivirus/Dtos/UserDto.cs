using System.ComponentModel.DataAnnotations;

namespace Antivirus.DTOs
{
    public class UsersReadDTO
    {
        public long Id { get; set; }
        public string? DateBirth { get; set; }
        public string? Email { get; set; }
        public string? LastName { get; set; }
        public string? Name { get; set; }
    }

    public class UsersCreateDTO
    {
        [Required]
        [StringLength(255)]
        public string? DateBirth { get; set; }

        [Required]
        [StringLength(255)]
        public string Email { get; set; }

        [Required]
        [StringLength(255)]
        public string LastName { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string Password { get; set; }
    }

 
    public class RegisterDTO
    {
        [Required]
        [StringLength(255)]
        public string Email { get; set; }

        [Required]
        [StringLength(255)]
        public string Password { get; set; }
    }
}