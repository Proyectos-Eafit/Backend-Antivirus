using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Antivirus.Models
{
    public class Institution
    {
        public long Id { get; set; }

        [StringLength(100)]
        public string? Name { get; set; }

        [StringLength(1000)]
        public string? Observations { get; set; }

        public string? BienestarLink { get; set; }
        public string? CarerLink { get; set; }
        public string? GeneralLink { get; set; }
        public string? ProccesLink { get; set; }
        public long? UbicationsInstitutionsId { get; set; }
        public bool Status { get; set; }

        [JsonIgnore]
        public List<InstituteBootcamp>? InstituteBootcamps { get; set; }

        [JsonIgnore]
        public List<InstituteOpportunity>? InstituteOpportunities { get; set; }
    }
}