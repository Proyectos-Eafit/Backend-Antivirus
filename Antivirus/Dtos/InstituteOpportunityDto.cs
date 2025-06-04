using System.ComponentModel.DataAnnotations;

namespace Antivirus.DTOs
{
    public class InstituteOpportunitiesReadDTO
    {
        public long Id { get; set; }
        public long? InstitutionId { get; set; }
        public long? OpportunityId { get; set; }
    }

    public class InstituteOpportunitiesCreateDTO
    {
        [Required]
        public long InstitutionId { get; set; }

        [Required]
        public long OpportunityId { get; set; }
    }
}