using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Antivirus.Models
{
    public class Role
    {
        public long Id { get; set; }

        [StringLength(100)]
        public string? Name { get; set; }

        public bool Status { get; set; }

        [JsonIgnore]
        public List<UserRole>? UserRoles { get; set; }
    }
}