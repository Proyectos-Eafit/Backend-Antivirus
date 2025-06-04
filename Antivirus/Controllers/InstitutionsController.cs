using Microsoft.AspNetCore.Mvc;
using Antivirus.Services;
using Antivirus.DTOs;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Antivirus.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class InstitutionsController : ControllerBase
    {
        private readonly IInstitutionService _institutionService;

        public InstitutionsController(IInstitutionService institutionService)
        {
            _institutionService = institutionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InstitutionsReadDTO>>> GetAll()
        {
            return Ok(await _institutionService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InstitutionsReadDTO>> GetById(long id)
        {
            var institution = await _institutionService.GetByIdAsync(id);
            if (institution == null)
                return NotFound();
            return Ok(institution);
        }

        [HttpPost]
        public async Task<ActionResult<InstitutionsReadDTO>> Create(InstitutionsCreateDTO institutionDto)
        {
            var createdInstitution = await _institutionService.CreateAsync(institutionDto);
            return CreatedAtAction(nameof(GetById), new { id = createdInstitution.Id }, createdInstitution);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, InstitutionsCreateDTO institutionDto)
        {
            var updated = await _institutionService.UpdateAsync(id, institutionDto);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deleted = await _institutionService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}