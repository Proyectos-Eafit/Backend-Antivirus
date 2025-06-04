// filepath: /home/anthony-munoz/Escritorio/taller1/Geny/Backend-Antivirus/Antivirus/Interfaces/IUserBootcampService.cs
using Antivirus.DTOs;

namespace Antivirus.Services
{
    public interface IUserBootcampService
    {
        Task<IEnumerable<UsersBootcampsReadDTO>> GetAllAsync();
        Task<UsersBootcampsReadDTO?> GetByIdAsync(long id);
        Task<UsersBootcampsReadDTO> CreateAsync(UsersBootcampsCreateDTO dto);
        Task<bool> UpdateAsync(long id, UsersBootcampsCreateDTO dto);
        Task<bool> DeleteAsync(long id);
    }
}