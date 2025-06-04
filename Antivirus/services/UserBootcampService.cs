using Antivirus.Data;
using Antivirus.DTOs;
using Antivirus.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Antivirus.Services
{
    public class UserBootcampService : IUserBootcampService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UserBootcampService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UsersBootcampsReadDTO>> GetAllAsync()
        {
            var entities = await _context.UserBootcamps.ToListAsync();
            return _mapper.Map<IEnumerable<UsersBootcampsReadDTO>>(entities);
        }

        public async Task<UsersBootcampsReadDTO?> GetByIdAsync(long id)
        {
            var entity = await _context.UserBootcamps.FindAsync(id);
            return entity == null ? null : _mapper.Map<UsersBootcampsReadDTO>(entity);
        }

        public async Task<UsersBootcampsReadDTO> CreateAsync(UsersBootcampsCreateDTO dto)
        {
            var entity = _mapper.Map<UserBootcamp>(dto);
            _context.UserBootcamps.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<UsersBootcampsReadDTO>(entity);
        }

        public async Task<bool> UpdateAsync(long id, UsersBootcampsCreateDTO dto)
        {
            var entity = await _context.UserBootcamps.FindAsync(id);
            if (entity == null) return false;

            _mapper.Map(dto, entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var entity = await _context.UserBootcamps.FindAsync(id);
            if (entity == null) return false;

            _context.UserBootcamps.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}