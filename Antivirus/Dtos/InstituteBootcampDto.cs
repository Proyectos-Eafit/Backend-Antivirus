using System.ComponentModel.DataAnnotations;

namespace Antivirus.DTOs
{
    public class InstituteBootcampsReadDTO
    {
        public long Id { get; set; }
        public long? BootcampId { get; set; }
        public long? InstitutionId { get; set; }
    }

    public class InstituteBootcampsCreateDTO
    {
        [Required]
        public long BootcampId { get; set; }

        [Required]
        public long InstitutionId { get; set; }
    }
}