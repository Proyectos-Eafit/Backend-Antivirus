using Antivirus.Data;
using Antivirus.Models;
using Antivirus.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Antivirus.Services
{
    public class BootcampService : IBootcampService
    {
        private readonly AppDbContext _context;

        public BootcampService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BootcampReadDTO>> GetAllAsync()
        {
            return await _context.Bootcamps
                .Select(b => new BootcampReadDTO
                {
                    Id = b.Id,
                    Name = b.Name,
                    Description = b.Description,
                    ImageUrl = b.ImageUrl,
                    Status = b.Status
                })
                .ToListAsync();
        }

        public async Task<BootcampReadDTO> GetByIdAsync(long id)
        {
            var bootcamp = await _context.Bootcamps.FindAsync(id);
            if (bootcamp == null) return null;

            return new BootcampReadDTO
            {
                Id = bootcamp.Id,
                Name = bootcamp.Name,
                Description = bootcamp.Description,
                ImageUrl = bootcamp.ImageUrl,
                Status = bootcamp.Status
            };
        }

        public async Task CreateAsync(BootcampCreateDTO dto)
        {
            var bootcamp = new Bootcamp
            {
                Name = dto.Name,
                Description = dto.Description,
                ImageUrl = dto.ImageUrl,
                Status = dto.Status
            };
            _context.Bootcamps.Add(bootcamp);
            await _context.SaveChangesAsync();
        }

        public async Task<BootcampReadDTO> UpdateAsync(long id, BootcampCreateDTO dto)
        {
            var bootcamp = await _context.Bootcamps.FindAsync(id);
            if (bootcamp == null) return null;

            bootcamp.Name = dto.Name;
            bootcamp.Description = dto.Description;
            bootcamp.ImageUrl = dto.ImageUrl;
            bootcamp.Status = dto.Status;

            await _context.SaveChangesAsync();

            return new BootcampReadDTO
            {
                Id = bootcamp.Id,
                Name = bootcamp.Name,
                Description = bootcamp.Description,
                ImageUrl = bootcamp.ImageUrl,
                Status = bootcamp.Status
            };
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var bootcamp = await _context.Bootcamps.FindAsync(id);
            if (bootcamp == null) return false;

            _context.Bootcamps.Remove(bootcamp);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}