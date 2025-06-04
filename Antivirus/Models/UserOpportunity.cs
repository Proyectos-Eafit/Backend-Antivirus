using System.ComponentModel.DataAnnotations;

namespace Antivirus.Models
{
    public class UserOpportunity
    {
        public long Id { get; set; }
        public long? OpportunityId { get; set; }
        public long? UserId { get; set; }
    }
}