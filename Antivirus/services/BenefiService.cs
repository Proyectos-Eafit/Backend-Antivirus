using Antivirus.DTOs;
using Antivirus.Models;
using Microsoft.EntityFrameworkCore;
using Antivirus.Data;

namespace Antivirus.Services
{
    public class BenefitService : IBenefitService
    {
        private readonly AppDbContext _context;

        public BenefitService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BenefitsReadDTO>> GetAllAsync()
        {
            return await _context.Benefits
                .Select(b => new BenefitsReadDTO
                {
                    Id = b.Id,
                    Name = b.Name,
                    Description = b.Description,
                    ImageUrl = b.ImageUrl,
                    Status = b.Status
                })
                .ToListAsync();
        }

        public async Task<BenefitsReadDTO?> GetByIdAsync(long id)
        {
            var benefit = await _context.Benefits.FindAsync(id);
            if (benefit == null) return null;

            return new BenefitsReadDTO
            {
                Id = benefit.Id,
                Name = benefit.Name,
                Description = benefit.Description,
                ImageUrl = benefit.ImageUrl,
                Status = benefit.Status
            };
        }

        public async Task<BenefitsReadDTO> CreateAsync(BenefitsCreateDTO dto)
        {
            var benefit = new Benefit
            {
                Name = dto.Name,
                Description = dto.Description,
                ImageUrl = dto.ImageUrl,
                Status = true // O el valor por defecto que prefieras
            };

            _context.Benefits.Add(benefit);
            await _context.SaveChangesAsync();

            return new BenefitsReadDTO
            {
                Id = benefit.Id,
                Name = benefit.Name,
                Description = benefit.Description,
                ImageUrl = benefit.ImageUrl,
                Status = benefit.Status
            };
        }

        public async Task<BenefitsReadDTO?> UpdateAsync(long id, BenefitsCreateDTO dto)
        {
            var benefit = await _context.Benefits.FindAsync(id);
            if (benefit == null) return null;

            benefit.Name = dto.Name;
            benefit.Description = dto.Description;
            benefit.ImageUrl = dto.ImageUrl;

            await _context.SaveChangesAsync();

            return new BenefitsReadDTO
            {
                Id = benefit.Id,
                Name = benefit.Name,
                Description = benefit.Description,
                ImageUrl = benefit.ImageUrl,
                Status = benefit.Status
            };
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var benefit = await _context.Benefits.FindAsync(id);
            if (benefit == null) return false;

            _context.Benefits.Remove(benefit);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}