using Antivirus.Data;
using Antivirus.DTOs;
using Antivirus.Models;
using Antivirus.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Antivirus.Services
{
    public class InstituteBootcampService : IInstituteBootcampService
    {
        private readonly AppDbContext _context;

        public InstituteBootcampService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<InstituteBootcampsReadDTO>> GetAllAsync()
        {
            var entities = await _context.InstituteBootcamps.ToListAsync();
            return entities.Select(e => new InstituteBootcampsReadDTO
            {
                Id = e.Id,
                BootcampId = e.BootcampId,
                InstitutionId = e.InstitutionId
            });
        }

        public async Task<InstituteBootcampsReadDTO?> GetByIdAsync(long id)
        {
            var entity = await _context.InstituteBootcamps.FindAsync(id);
            if (entity == null) return null;
            return new InstituteBootcampsReadDTO
            {
                Id = entity.Id,
                BootcampId = entity.BootcampId,
                InstitutionId = entity.InstitutionId
            };
        }

        public async Task<InstituteBootcampsReadDTO> CreateAsync(InstituteBootcampsCreateDTO dto)
        {
            var entity = new InstituteBootcamp
            {
                BootcampId = dto.BootcampId,
                InstitutionId = dto.InstitutionId
            };
            _context.InstituteBootcamps.Add(entity);
            await _context.SaveChangesAsync();
            return new InstituteBootcampsReadDTO
            {
                Id = entity.Id,
                BootcampId = entity.BootcampId,
                InstitutionId = entity.InstitutionId
            };
        }

        public async Task<bool> UpdateAsync(long id, InstituteBootcampsCreateDTO dto)
        {
            var entity = await _context.InstituteBootcamps.FindAsync(id);
            if (entity == null) return false;

            entity.BootcampId = dto.BootcampId;
            entity.InstitutionId = dto.InstitutionId;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var entity = await _context.InstituteBootcamps.FindAsync(id);
            if (entity == null) return false;

            _context.InstituteBootcamps.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}