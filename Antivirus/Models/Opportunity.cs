using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Antivirus.Models
{
    public class Opportunity
    {
        public long Id { get; set; }

        [StringLength(100)]
        public string? Name { get; set; }

        [StringLength(1000)]
        public string? Description { get; set; }

        public string? AdicionalDates { get; set; }
        public string? Applications { get; set; }
        public string? ContactChannels { get; set; }
        public string? Guide { get; set; }
        public string? Observations { get; set; }
        public string? Requirements { get; set; }
        public long? CategoriesId { get; set; }
        public long? StatusReviewId { get; set; }
        public long? OpportunityTypeId { get; set; }
        public string? ImageUrl { get; set; }
        public bool Status { get; set; }

        [JsonIgnore]
        public List<InstituteOpportunity>? InstituteOpportunities { get; set; }

        [JsonIgnore]
        public List<UserOpportunity>? UserOpportunities { get; set; }
    }
}