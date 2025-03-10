using System.Collections.Generic;
using System.Threading.Tasks;
using Antivirus.Dtos;

namespace Antivirus.Services
{
    public interface IRoleService
    {
        Task<IEnumerable<RoleDto>> GetAllRolesAsync();
        Task<RoleDto> GetRoleByIdAsync(long id);
        Task<RoleCreateDto> CreateRoleAsync(RoleCreateDto roleDto);
        Task<RoleCreateDto> UpdateRoleAsync(long id, RoleCreateDto roleDto);
        Task DeleteRoleAsync(long id);
    }
}