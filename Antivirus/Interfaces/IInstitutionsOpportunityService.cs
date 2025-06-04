using Antivirus.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Antivirus.Services
{
    public interface IInstitutionOpportunityService
    {
        Task<IEnumerable<InstituteOpportunitiesReadDTO>> GetAllAsync();
        Task<InstituteOpportunitiesReadDTO?> GetByIdAsync(long id);
        Task<InstituteOpportunitiesReadDTO> CreateAsync(InstituteOpportunitiesCreateDTO dto);
        Task<bool> UpdateAsync(long id, InstituteOpportunitiesCreateDTO dto);
        Task<bool> DeleteAsync(long id);
    }
}