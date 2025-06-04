using System.ComponentModel.DataAnnotations;

namespace Antivirus.Models
{
    public class Benefit
    {
        public long Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        public string? ImageUrl { get; set; }
        public bool Status { get; set; }
    }
}