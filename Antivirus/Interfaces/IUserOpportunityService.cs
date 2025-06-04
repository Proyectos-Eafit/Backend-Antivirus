// filepath: /home/anthony-munoz/Escritorio/taller1/Geny/Backend-Antivirus/Antivirus/Interfaces/IUserOpportunityService.cs
using Antivirus.DTOs;

namespace Antivirus.Services
{
    public interface IUserOpportunityService
    {
        Task<IEnumerable<UserOpportunitiesReadDTO>> GetAllAsync();
        Task<UserOpportunitiesReadDTO?> GetByIdAsync(long id);
        Task<UserOpportunitiesReadDTO> CreateAsync(UserOpportunitiesCreateDTO dto);
        Task<UserOpportunitiesReadDTO?> UpdateAsync(long id, UserOpportunitiesCreateDTO dto);
        Task<bool> DeleteAsync(long id);
    }
}