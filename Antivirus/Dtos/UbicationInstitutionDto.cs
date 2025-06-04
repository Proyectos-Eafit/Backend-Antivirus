using System.ComponentModel.DataAnnotations;

namespace Antivirus.DTOs
{
    // DTOs existentes
    public class UbicationsInstitutionsReadDTO
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public bool Status { get; set; }
    }

    public class UbicationsInstitutionsCreateDTO
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    }

    // DTOs requeridos por el controlador
    public class UbicationInstitutionRequestDto
    {
        [Required]
        public string Address { get; set; }

        [Required]
        public long InstitutionId { get; set; }
    }

    public class UbicationInstitutionResponseDto
    {
        public long Id { get; set; }
        public string Address { get; set; }
        public long InstitutionId { get; set; }
    }
}