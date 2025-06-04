using Antivirus.Data;
using Antivirus.DTOs;
using Antivirus.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Antivirus.Services
{
    public class InstitutionOpportunityService : IInstitutionOpportunityService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public InstitutionOpportunityService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<InstituteOpportunitiesReadDTO>> GetAllAsync()
        {
            var entities = await _context.InstituteOpportunities.ToListAsync();
            return _mapper.Map<IEnumerable<InstituteOpportunitiesReadDTO>>(entities);
        }

        public async Task<InstituteOpportunitiesReadDTO?> GetByIdAsync(long id)
        {
            var entity = await _context.InstituteOpportunities.FindAsync(id);
            return entity == null ? null : _mapper.Map<InstituteOpportunitiesReadDTO>(entity);
        }

        public async Task<InstituteOpportunitiesReadDTO> CreateAsync(InstituteOpportunitiesCreateDTO dto)
        {
            var entity = _mapper.Map<InstituteOpportunity>(dto);
            _context.InstituteOpportunities.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<InstituteOpportunitiesReadDTO>(entity);
        }

        public async Task<bool> UpdateAsync(long id, InstituteOpportunitiesCreateDTO dto)
        {
            var entity = await _context.InstituteOpportunities.FindAsync(id);
            if (entity == null) return false;

            _mapper.Map(dto, entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var entity = await _context.InstituteOpportunities.FindAsync(id);
            if (entity == null) return false;

            _context.InstituteOpportunities.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}