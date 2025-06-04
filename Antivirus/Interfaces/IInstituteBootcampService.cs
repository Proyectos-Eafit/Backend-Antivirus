using Antivirus.DTOs;

namespace Antivirus.Services.Interfaces
{
    public interface IInstituteBootcampService
    {
        Task<IEnumerable<InstituteBootcampsReadDTO>> GetAllAsync();
        Task<InstituteBootcampsReadDTO?> GetByIdAsync(long id);
        Task<InstituteBootcampsReadDTO> CreateAsync(InstituteBootcampsCreateDTO dto);
        Task<bool> UpdateAsync(long id, InstituteBootcampsCreateDTO dto);
        Task<bool> DeleteAsync(long id);
    }
}