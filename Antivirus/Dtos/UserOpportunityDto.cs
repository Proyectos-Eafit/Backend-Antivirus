using System.ComponentModel.DataAnnotations;

namespace Antivirus.DTOs
{
    public class UserOpportunitiesReadDTO
    {
        public long Id { get; set; }
        public long? OpportunityId { get; set; }
        public long? UserId { get; set; }
    }

    public class UserOpportunitiesCreateDTO
    {
        [Required]
        public long OpportunityId { get; set; }

        [Required]
        public long UserId { get; set; }
    }
}