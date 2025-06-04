using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Antivirus.DTOs;
using Antivirus.Models;
using Antivirus.Data;

namespace Antivirus.Services
{
    public class RoleService : IRoleService
    {
        private readonly AppDbContext _context;

        public RoleService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RoleReadDTO>> GetAllRolesAsync()
        {
            var roles = await _context.Roles.ToListAsync();
            return roles.Select(r => new RoleReadDTO
            {
                Id = r.Id,
                Name = r.Name,
                Status = r.Status
            });
        }

        public async Task<RoleReadDTO?> GetRoleByIdAsync(long id)
        {
            var role = await _context.Roles.FindAsync(id);
            if (role == null) return null;
            return new RoleReadDTO
            {
                Id = role.Id,
                Name = role.Name,
                Status = role.Status
            };
        }

        public async Task<RoleReadDTO> CreateRoleAsync(RoleCreateDTO roleDto)
        {
            var role = new Role
            {
                Name = roleDto.Name,
                Status = true // O el valor por defecto que prefieras
            };
            _context.Roles.Add(role);
            await _context.SaveChangesAsync();
            return new RoleReadDTO
            {
                Id = role.Id,
                Name = role.Name,
                Status = role.Status
            };
        }

        public async Task<RoleReadDTO?> UpdateRoleAsync(long id, RoleCreateDTO roleDto)
        {
            var role = await _context.Roles.FindAsync(id);
            if (role == null) return null;

            role.Name = roleDto.Name;
            await _context.SaveChangesAsync();

            return new RoleReadDTO
            {
                Id = role.Id,
                Name = role.Name,
                Status = role.Status
            };
        }

        public async Task<bool> DeleteRoleAsync(long id)
        {
            var role = await _context.Roles.FindAsync(id);
            if (role == null) return false;

            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}