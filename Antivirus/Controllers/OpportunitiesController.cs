using Antivirus.DTOs;
using Antivirus.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Antivirus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OpportunitiesController : ControllerBase
    {
        private readonly IOpportunityService _service;

        public OpportunitiesController(IOpportunityService service)
        {
            _service = service;
        }

        // GET: api/Opportunities
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<OpportunitiesReadDTO>>> GetAll()
        {
            var opportunities = await _service.GetAllAsync();
            return Ok(opportunities);
        }

        // GET: api/Opportunities/{id}
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<OpportunitiesReadDTO>> GetById(long id)
        {
            var opportunity = await _service.GetByIdAsync(id);
            if (opportunity == null)
            {
                return NotFound();
            }
            return Ok(opportunity);
        }

        // POST: api/Opportunities
        [HttpPost]
        public async Task<ActionResult<OpportunitiesReadDTO>> Create(OpportunitiesCreateDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdOpportunity = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = createdOpportunity.Id }, createdOpportunity);
        }

        // PUT: api/Opportunities/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<OpportunitiesReadDTO>> Update(long id, OpportunitiesCreateDTO dto)
        {
            var updatedOpportunity = await _service.UpdateAsync(id, dto);
            if (updatedOpportunity == null)
            {
                return NotFound();
            }
            return Ok(updatedOpportunity);
        }

        // DELETE: api/Opportunities/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _service.DeleteAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}