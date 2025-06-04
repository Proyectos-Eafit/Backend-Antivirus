using System.ComponentModel.DataAnnotations;

namespace Antivirus.Models
{
    public class InstituteBootcamp
    {
        public long Id { get; set; }
        public long? BootcampId { get; set; }
        public long? InstitutionId { get; set; }
    }
}