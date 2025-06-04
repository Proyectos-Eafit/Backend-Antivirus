using System.ComponentModel.DataAnnotations;

namespace Antivirus.DTOs
{
    public class RoleReadDTO
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public bool Status { get; set; }
    }

    public class RoleCreateDTO
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    }
}