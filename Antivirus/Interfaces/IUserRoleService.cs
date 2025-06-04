using System.Collections.Generic;
using System.Threading.Tasks;
using Antivirus.DTOs;

namespace Antivirus.Services
{
    public interface IUserRoleService
    {
        Task<IEnumerable<UserRolesReadDTO>> GetAllAsync();
        Task<UserRolesReadDTO?> GetByIdAsync(long userId, long roleId);
        Task CreateAsync(UserRolesCreateDTO dto);
        Task UpdateAsync(long userId, long roleId, UserRolesCreateDTO dto);
        Task DeleteAsync(long userId, long roleId);
    }
}