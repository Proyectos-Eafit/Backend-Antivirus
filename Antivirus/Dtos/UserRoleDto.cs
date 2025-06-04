using System.ComponentModel.DataAnnotations;

namespace Antivirus.DTOs
{
    public class UserRolesReadDTO
    {
        public long UserId { get; set; }
        public long RoleId { get; set; }
    }

    public class UserRolesCreateDTO
    {
        [Required]
        public long UserId { get; set; }

        [Required]
        public long RoleId { get; set; }
    }
}