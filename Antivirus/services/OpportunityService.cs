using AutoMapper;
using Antivirus.DTOs;
using Antivirus.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Antivirus.Data;

namespace Antivirus.Services
{
    public class OpportunityService : IOpportunityService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public OpportunityService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OpportunitiesReadDTO>> GetAllAsync()
        {
            var entities = await _context.Opportunities.ToListAsync();
            return _mapper.Map<IEnumerable<OpportunitiesReadDTO>>(entities);
        }

        public async Task<OpportunitiesReadDTO?> GetByIdAsync(long id)
        {
            var entity = await _context.Opportunities.FindAsync(id);
            return entity == null ? null : _mapper.Map<OpportunitiesReadDTO>(entity);
        }

        public async Task<OpportunitiesReadDTO> CreateAsync(OpportunitiesCreateDTO dto)
        {
            var entity = _mapper.Map<Opportunity>(dto);
            _context.Opportunities.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<OpportunitiesReadDTO>(entity);
        }

        public async Task<OpportunitiesReadDTO?> UpdateAsync(long id, OpportunitiesCreateDTO dto)
        {
            var entity = await _context.Opportunities.FindAsync(id);
            if (entity == null)
            {
                return null;
            }

            entity.Name = dto.Name;
            entity.Description = dto.Description;
            entity.AdicionalDates = dto.AdicionalDates;
            entity.Applications = dto.Applications;
            entity.ContactChannels = dto.ContactChannels;
            entity.Guide = dto.Guide;
            entity.Observations = dto.Observations;
            entity.Requirements = dto.Requirements;
            entity.CategoriesId = dto.CategoriesId;
            entity.StatusReviewId = dto.StatusReviewId;
            entity.OpportunityTypeId = dto.OpportunityTypeId;
            entity.ImageUrl = dto.ImageUrl;

            _context.Opportunities.Update(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<OpportunitiesReadDTO>(entity);
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var entity = await _context.Opportunities.FindAsync(id);
            if (entity == null)
            {
                return false;
            }
            _context.Opportunities.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}