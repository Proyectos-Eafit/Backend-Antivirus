using Antivirus.DTOs;
using Antivirus.Models;
using Antivirus.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Antivirus.Services
{
    public class ServiceService : IServiceService
    {
        private readonly AppDbContext _context;

        public ServiceService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ServiceReadDTO>> GetAllAsync()
        {
            return await _context.Services
                .Select(s => new ServiceReadDTO
                {
                    Id = s.Id,
                    Name = s.Name,
                    Description = s.Description,
                    ImageUrl = s.ImageUrl,
                    Status = s.Status
                })
                .ToListAsync();
        }

        public async Task<ServiceReadDTO?> GetByIdAsync(long id)
        {
            var service = await _context.Services.FindAsync(id);
            if (service == null) return null;

            return new ServiceReadDTO
            {
                Id = service.Id,
                Name = service.Name,
                Description = service.Description,
                ImageUrl = service.ImageUrl,
                Status = service.Status
            };
        }

        public async Task<ServiceReadDTO> CreateAsync(ServiceCreateDTO dto)
        {
            var service = new Service
            {
                Name = dto.Name,
                Description = dto.Description,
                ImageUrl = dto.ImageUrl,
                Status = true // O el valor por defecto que prefieras
            };

            _context.Services.Add(service);
            await _context.SaveChangesAsync();

            return new ServiceReadDTO
            {
                Id = service.Id,
                Name = service.Name,
                Description = service.Description,
                ImageUrl = service.ImageUrl,
                Status = service.Status
            };
        }

        public async Task<ServiceReadDTO?> UpdateAsync(long id, ServiceCreateDTO dto)
        {
            var service = await _context.Services.FindAsync(id);
            if (service == null) return null;

            service.Name = dto.Name;
            service.Description = dto.Description;
            service.ImageUrl = dto.ImageUrl;

            await _context.SaveChangesAsync();

            return new ServiceReadDTO
            {
                Id = service.Id,
                Name = service.Name,
                Description = service.Description,
                ImageUrl = service.ImageUrl,
                Status = service.Status
            };
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var service = await _context.Services.FindAsync(id);
            if (service == null) return false;

            _context.Services.Remove(service);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}