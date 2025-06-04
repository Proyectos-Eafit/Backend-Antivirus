using Microsoft.EntityFrameworkCore;
using Antivirus.DTOs;
using Antivirus.Models;
using Antivirus.Data;
using AutoMapper;

namespace Antivirus.Services
{
    public class UserRoleService : IUserRoleService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UserRoleService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserRolesReadDTO>> GetAllAsync()
        {
            var userRoles = await _context.UserRoles.ToListAsync();
            return _mapper.Map<IEnumerable<UserRolesReadDTO>>(userRoles);
        }

        public async Task<UserRolesReadDTO?> GetByIdAsync(long userId, long roleId)
        {
            var userRole = await _context.UserRoles.FindAsync(userId, roleId);
            return userRole != null ? _mapper.Map<UserRolesReadDTO>(userRole) : null;
        }

        public async Task CreateAsync(UserRolesCreateDTO dto)
        {
            var userRole = _mapper.Map<UserRole>(dto);
            _context.UserRoles.Add(userRole);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(long userId, long roleId, UserRolesCreateDTO dto)
        {
            var existingUserRole = await _context.UserRoles.FindAsync(userId, roleId);
            if (existingUserRole != null)
            {
                _mapper.Map(dto, existingUserRole);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(long userId, long roleId)
        {
            var userRole = await _context.UserRoles.FindAsync(userId, roleId);
            if (userRole != null)
            {
                _context.UserRoles.Remove(userRole);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> HasUsersAssignedAsync(long roleId)
        {
            return await _context.UserRoles.AnyAsync(ur => ur.RoleId == roleId);
        }
    }
}