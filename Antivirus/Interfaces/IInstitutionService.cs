using System.Collections.Generic;
using System.Threading.Tasks;
using Antivirus.DTOs;

namespace Antivirus.Services
{
    public interface IInstitutionService
    {
        Task<IEnumerable<InstitutionsReadDTO>> GetAllAsync();
        Task<InstitutionsReadDTO?> GetByIdAsync(long id);
        Task<InstitutionsReadDTO> CreateAsync(InstitutionsCreateDTO institutionDto);
        Task<bool> UpdateAsync(long id, InstitutionsCreateDTO institutionDto);
        Task<bool> DeleteAsync(long id);
    }
}