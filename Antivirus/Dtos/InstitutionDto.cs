using System.ComponentModel.DataAnnotations;

namespace Antivirus.DTOs
{
    public class InstitutionsReadDTO
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Observations { get; set; }
        public string? BienestarLink { get; set; }
        public string? CarerLink { get; set; }
        public string? GeneralLink { get; set; }
        public string? ProccesLink { get; set; }
        public long? UbicationsInstitutionsId { get; set; }
        public bool Status { get; set; }
    }

    public class InstitutionsCreateDTO
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(1000)]
        public string? Observations { get; set; }

        public string? BienestarLink { get; set; }
        public string? CarerLink { get; set; }
        public string? GeneralLink { get; set; }
        public string? ProccesLink { get; set; }
        public bool Status { get; set; }
        public long? UbicationsInstitutionsId { get; set; }
    }
}