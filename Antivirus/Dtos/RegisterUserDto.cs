namespace Antivirus.DTOs
{
    public class RegisterUserDto
    {
        public long Id { get; set; }
        public string Name { get; set; } 
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string DateBirth { get; set; }
    }
}