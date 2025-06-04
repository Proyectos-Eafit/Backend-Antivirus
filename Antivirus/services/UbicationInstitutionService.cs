using Antivirus.Data;
using Antivirus.DTOs;
using Antivirus.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Antivirus.Services
{
    public class UbicationInstitutionService : IUbicationInstitutionService
    {
        private readonly AppDbContext _context;

        public UbicationInstitutionService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UbicationInstitutionResponseDto>> GetAllAsync()
        {
            var ubications = await _context.UbicationInstitutions.ToListAsync();
            return ubications.Select(ubi => new UbicationInstitutionResponseDto
            {
                Id = ubi.Id,
                Address = ubi.Name, // Ajusta esto si tu modelo tiene Address, si no, usa Name como Address
                InstitutionId = 0   // Ajusta esto según tu modelo real
            });
        }

        public async Task<UbicationInstitutionResponseDto?> GetByIdAsync(long id)
        {
            var ubication = await _context.UbicationInstitutions.FindAsync(id);
            if (ubication == null) return null;
            return new UbicationInstitutionResponseDto
            {
                Id = ubication.Id,
                Address = ubication.Name, // Ajusta esto si tu modelo tiene Address
                InstitutionId = 0         // Ajusta esto según tu modelo real
            };
        }

        public async Task<UbicationInstitutionResponseDto> CreateAsync(UbicationInstitutionRequestDto ubicationDto)
        {
            var ubication = new UbicationInstitution
            {
                Name = ubicationDto.Address, // Ajusta esto si tu modelo tiene Address
                Status = true
            };
            _context.UbicationInstitutions.Add(ubication);
            await _context.SaveChangesAsync();
            return new UbicationInstitutionResponseDto
            {
                Id = ubication.Id,
                Address = ubication.Name, // Ajusta esto si tu modelo tiene Address
                InstitutionId = ubicationDto.InstitutionId
            };
        }

        public async Task<bool> UpdateAsync(long id, UbicationInstitutionRequestDto ubicationDto)
        {
            var ubication = await _context.UbicationInstitutions.FindAsync(id);
            if (ubication == null) return false;

            ubication.Name = ubicationDto.Address; // Ajusta esto si tu modelo tiene Address
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var ubication = await _context.UbicationInstitutions.FindAsync(id);
            if (ubication == null) return false;

            _context.UbicationInstitutions.Remove(ubication);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}