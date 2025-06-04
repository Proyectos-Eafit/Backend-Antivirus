using System.ComponentModel.DataAnnotations;

namespace Antivirus.Models
{
    public class UserRole
    {
        [Key]
        public long Id { get; set; }
        public long UserId { get; set; }
        public long RoleId { get; set; }
    }
}