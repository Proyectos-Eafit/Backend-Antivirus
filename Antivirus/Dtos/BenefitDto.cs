using System.ComponentModel.DataAnnotations;

namespace Antivirus.DTOs
{
    public class BenefitsReadDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? ImageUrl { get; set; }
        public bool Status { get; set; }
    }

    public class BenefitsCreateDTO
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