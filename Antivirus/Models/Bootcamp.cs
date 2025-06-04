using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Antivirus.Models
{
    public class Bootcamp
    {
        public long Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        public string? ImageUrl { get; set; }
        public bool Status { get; set; }

        [JsonIgnore]
        public List<InstituteBootcamp>? InstituteBootcamps { get; set; }

        [JsonIgnore]
        public List<UserBootcamp>? UsersBootcamps { get; set; }
    }
}