using System.ComponentModel.DataAnnotations;

namespace Antivirus.DTOs
{
    public class ServiceReadDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? ImageUrl { get; set; }
        public bool Status { get; set; }
    }

    public class ServiceCreateDTO
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        public string? ImageUrl { get; set; }
    }
}