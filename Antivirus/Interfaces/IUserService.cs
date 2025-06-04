// filepath: /home/anthony-munoz/Escritorio/taller1/Geny/Backend-Antivirus/Antivirus/Interfaces/IUserService.cs
using Antivirus.DTOs;

namespace Antivirus.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UsersReadDTO>> GetAllUsersAsync();
        Task<UsersReadDTO> GetUserByIdAsync(long id);
        Task<UsersReadDTO> CreateUserAsync(UsersCreateDTO userDto);
        Task<UsersReadDTO> UpdateUserAsync(long id, UsersCreateDTO userDto);
        Task<bool> DeleteUserAsync(long id);
    }
}