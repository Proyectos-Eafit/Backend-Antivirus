using System.Collections.Generic;
using System.Threading.Tasks;
using Antivirus.DTOs;

namespace Antivirus.Services
{
    public interface IBootcampService
    {
        Task<IEnumerable<BootcampReadDTO>> GetAllAsync();
        Task<BootcampReadDTO> GetByIdAsync(long id);
        Task CreateAsync(BootcampCreateDTO dto);
        Task<BootcampReadDTO> UpdateAsync(long id, BootcampCreateDTO dto);
        Task<bool> DeleteAsync(long id);
    }
}