using Antivirus.Data;
using Antivirus.DTOs;
using Antivirus.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Antivirus.Services
{
    public class InstitutionService : IInstitutionService
    {
        private readonly AppDbContext _context;

        public InstitutionService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<InstitutionsReadDTO>> GetAllAsync()
        {
            var institutions = await _context.Institutions.ToListAsync();
            return institutions.Select(inst => new InstitutionsReadDTO
            {
                Id = inst.Id,
                Name = inst.Name,
                Observations = inst.Observations,
                BienestarLink = inst.BienestarLink,
                CarerLink = inst.CarerLink,
                GeneralLink = inst.GeneralLink,
                ProccesLink = inst.ProccesLink,
                UbicationsInstitutionsId = inst.UbicationsInstitutionsId,
                Status = inst.Status
            });
        }

        public async Task<InstitutionsReadDTO?> GetByIdAsync(long id)
        {
            var inst = await _context.Institutions.FindAsync(id);
            if (inst == null) return null;
            return new InstitutionsReadDTO
            {
                Id = inst.Id,
                Name = inst.Name,
                Observations = inst.Observations,
                BienestarLink = inst.BienestarLink,
                CarerLink = inst.CarerLink,
                GeneralLink = inst.GeneralLink,
                ProccesLink = inst.ProccesLink,
                UbicationsInstitutionsId = inst.UbicationsInstitutionsId,
                Status = inst.Status
            };
        }

        public async Task<InstitutionsReadDTO> CreateAsync(InstitutionsCreateDTO dto)
        {
            var inst = new Institution
            {
                Name = dto.Name,
                Observations = dto.Observations,
                BienestarLink = dto.BienestarLink,
                CarerLink = dto.CarerLink,
                GeneralLink = dto.GeneralLink,
                ProccesLink = dto.ProccesLink,
                UbicationsInstitutionsId = dto.UbicationsInstitutionsId,
                Status = dto.Status // Ahora Status es bool, no hace falta comparar
            };
            _context.Institutions.Add(inst);
            await _context.SaveChangesAsync();
            return new InstitutionsReadDTO
            {
                Id = inst.Id,
                Name = inst.Name,
                Observations = inst.Observations,
                BienestarLink = inst.BienestarLink,
                CarerLink = inst.CarerLink,
                GeneralLink = inst.GeneralLink,
                ProccesLink = inst.ProccesLink,
                UbicationsInstitutionsId = inst.UbicationsInstitutionsId,
                Status = inst.Status
            };
        }

        public async Task<bool> UpdateAsync(long id, InstitutionsCreateDTO dto)
        {
            var inst = await _context.Institutions.FindAsync(id);
            if (inst == null) return false;

            inst.Name = dto.Name;
            inst.Observations = dto.Observations;
            inst.BienestarLink = dto.BienestarLink;
            inst.CarerLink = dto.CarerLink;
            inst.GeneralLink = dto.GeneralLink;
            inst.ProccesLink = dto.ProccesLink;
            inst.UbicationsInstitutionsId = dto.UbicationsInstitutionsId;
            inst.Status = dto.Status; // Ahora Status es bool

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var inst = await _context.Institutions.FindAsync(id);
            if (inst == null) return false;

            _context.Institutions.Remove(inst);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}