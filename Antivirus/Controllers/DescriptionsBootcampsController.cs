using Antivirus.DTOs;
using Antivirus.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Antivirus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DescriptionsBootcampsController : ControllerBase
    {
        private readonly IDescriptionsBootcampsService _service;

        public DescriptionsBootcampsController(IDescriptionsBootcampsService service)
        {
            _service = service;
        }

        // GET: api/DescriptionsBootcamps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DescriptionsBootcampsDTO>>> GetAll()
        {
            var list = await _service.GetAllAsync();
            return Ok(list);
        }

        // GET: api/DescriptionsBootcamps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DescriptionsBootcampsDTO>> GetById(long id)
        {
            var dto = await _service.GetByIdAsync(id);
            if (dto == null)
            {
                return NotFound();
            }
            return Ok(dto);
        }

        // POST: api/DescriptionsBootcamps
        [HttpPost]
        public async Task<ActionResult<DescriptionsBootcampsDTO>> Create(DescriptionsBootcampsDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdDto = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = createdDto.id }, createdDto);
        }

        // PUT: api/DescriptionsBootcamps/5
        [HttpPut("{id}")]
        public async Task<ActionResult<DescriptionsBootcampsDTO>> Update(long id, DescriptionsBootcampsDTO dto)
        {
            if (id != dto.id)
            {
                return BadRequest("El ID del recurso no coincide con el ID de la petición.");
            }
            var updatedDto = await _service.UpdateAsync(id, dto);
            if (updatedDto == null)
            {
                return NotFound();
            }
            return Ok(updatedDto);
        }

        // DELETE: api/DescriptionsBootcamps/5
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
