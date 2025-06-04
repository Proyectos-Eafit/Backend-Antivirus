using AutoMapper;
using Antivirus.DTOs;
using Antivirus.Models;
using Microsoft.EntityFrameworkCore;
using Antivirus.Data;

namespace Antivirus.Services
{
    public class UserOpportunityService : IUserOpportunityService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UserOpportunityService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserOpportunitiesReadDTO>> GetAllAsync()
        {
            var entities = await _context.UserOpportunities.ToListAsync();
            return _mapper.Map<IEnumerable<UserOpportunitiesReadDTO>>(entities);
        }

        public async Task<UserOpportunitiesReadDTO?> GetByIdAsync(long id)
        {
            var entity = await _context.UserOpportunities.FindAsync(id);
            return entity == null ? null : _mapper.Map<UserOpportunitiesReadDTO>(entity);
        }

        public async Task<UserOpportunitiesReadDTO> CreateAsync(UserOpportunitiesCreateDTO dto)
        {
            var entity = _mapper.Map<UserOpportunity>(dto);
            _context.UserOpportunities.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<UserOpportunitiesReadDTO>(entity);
        }

        public async Task<UserOpportunitiesReadDTO?> UpdateAsync(long id, UserOpportunitiesCreateDTO dto)
        {
            var entity = await _context.UserOpportunities.FindAsync(id);
            if (entity == null)
            {
                return null;
            }

            entity.OpportunityId = dto.OpportunityId;
            entity.UserId = dto.UserId;

            _context.UserOpportunities.Update(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<UserOpportunitiesReadDTO>(entity);
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var entity = await _context.UserOpportunities.FindAsync(id);
            if (entity == null)
            {
                return false;
            }
            _context.UserOpportunities.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}