using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Antivirus.Services;
using Antivirus.DTOs;
using Antivirus.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Antivirus.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UbicationsInstitutionsController : ControllerBase
    {
        private readonly IUbicationInstitutionService _ubicationInstitutionService;

        public UbicationsInstitutionsController(IUbicationInstitutionService ubicationInstitutionService)
        {
            _ubicationInstitutionService = ubicationInstitutionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UbicationInstitutionResponseDto>>> GetAll()
        {
            return Ok(await _ubicationInstitutionService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UbicationInstitutionResponseDto>> GetById(long id)
        {
            var ubication = await _ubicationInstitutionService.GetByIdAsync(id);
            if (ubication == null)
                return NotFound();
            return Ok(ubication);
        }

        [HttpPost]
        public async Task<ActionResult> Create(UbicationInstitutionRequestDto ubicationDto)
        {
            var createdUbication = await _ubicationInstitutionService.CreateAsync(ubicationDto);
            return CreatedAtAction(nameof(GetById), new { id = createdUbication.Id }, createdUbication);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, UbicationInstitutionRequestDto ubicationDto)
        {
            var updated = await _ubicationInstitutionService.UpdateAsync(id, ubicationDto);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deleted = await _ubicationInstitutionService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}