using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Antivirus.Models
{
    public class User
    {
        public long Id { get; set; }

        [StringLength(255)]
        public string? DateBirth { get; set; }

        [StringLength(255)]
        public string? Email { get; set; }

        [StringLength(255)]
        public string? LastName { get; set; }

        [StringLength(255)]
        public string? Name { get; set; }

        [StringLength(255)]
        public string? Password { get; set; }

        [JsonIgnore]
        public List<UserOpportunity>? UserOpportunities { get; set; }

        [JsonIgnore]
        public List<UserRole>? UserRoles { get; set; }

        [JsonIgnore]
        public List<UserBootcamp>? UsersBootcamps { get; set; }
    }
}