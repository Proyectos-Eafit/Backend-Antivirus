using System.ComponentModel.DataAnnotations;

namespace Antivirus.Models
{
    public class InstituteOpportunity
    {
        public long Id { get; set; }
        public long? InstitutionId { get; set; }
        public long? OpportunityId { get; set; }
    }
}