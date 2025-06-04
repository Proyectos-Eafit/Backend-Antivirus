using Antivirus.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Antivirus.Services
{
    public interface IOpportunityService
    {
        Task<IEnumerable<OpportunitiesReadDTO>> GetAllAsync();
        Task<OpportunitiesReadDTO?> GetByIdAsync(long id);
        Task<OpportunitiesReadDTO> CreateAsync(OpportunitiesCreateDTO dto);
        Task<OpportunitiesReadDTO?> UpdateAsync(long id, OpportunitiesCreateDTO dto);
        Task<bool> DeleteAsync(long id);
    }
}