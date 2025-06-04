using System.Collections.Generic;
using System.Threading.Tasks;
using Antivirus.DTOs;

namespace Antivirus.Services
{
    public interface IRoleService
    {
        Task<IEnumerable<RoleReadDTO>> GetAllRolesAsync();
        Task<RoleReadDTO?> GetRoleByIdAsync(long id);
        Task<RoleReadDTO> CreateRoleAsync(RoleCreateDTO roleDto);
        Task<RoleReadDTO?> UpdateRoleAsync(long id, RoleCreateDTO roleDto);
        Task<bool> DeleteRoleAsync(long id);
    }
}