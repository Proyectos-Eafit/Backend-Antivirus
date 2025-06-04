using System.Collections.Generic;
using System.Threading.Tasks;
using Antivirus.DTOs;

namespace Antivirus.Services
{
    public interface IBenefitService
    {
        Task<IEnumerable<BenefitsReadDTO>> GetAllAsync();
        Task<BenefitsReadDTO?> GetByIdAsync(long id);
        Task<BenefitsReadDTO> CreateAsync(BenefitsCreateDTO dto);
        Task<BenefitsReadDTO?> UpdateAsync(long id, BenefitsCreateDTO dto);
        Task<bool> DeleteAsync(long id);
    }
}