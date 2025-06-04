using System.ComponentModel.DataAnnotations;

namespace Antivirus.DTOs
{
    public class UsersBootcampsReadDTO
    {
        public long Id { get; set; }
        public long? BootcampId { get; set; }
        public long? UserId { get; set; }
    }

    public class UsersBootcampsCreateDTO
    {
        [Required]
        public long BootcampId { get; set; }

        [Required]
        public long UserId { get; set; }
    }
}