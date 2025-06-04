// filepath: /home/anthony-munoz/Escritorio/taller1/Geny/Backend-Antivirus/Antivirus/Interfaces/IServiceService.cs
using Antivirus.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Antivirus.Services
{
    public interface IServiceService
    {
        Task<IEnumerable<ServiceReadDTO>> GetAllAsync();
        Task<ServiceReadDTO> GetByIdAsync(long id);
        Task<ServiceReadDTO> CreateAsync(ServiceCreateDTO dto);
        Task<ServiceReadDTO> UpdateAsync(long id, ServiceCreateDTO dto);
        Task<bool> DeleteAsync(long id);
    }
}