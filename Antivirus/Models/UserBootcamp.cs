using System.ComponentModel.DataAnnotations;

namespace Antivirus.Models
{
    public class UserBootcamp
    {
        public long Id { get; set; }
        public long? BootcampId { get; set; }
        public long? UserId { get; set; }
    }
}