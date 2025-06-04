using Antivirus.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Antivirus.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Antivirus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BootcampController : ControllerBase
    {
        private readonly IBootcampService _bootcampService;

        public BootcampController(IBootcampService bootcampService)
        {
            _bootcampService = bootcampService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BootcampReadDTO>>> GetAll()
        {
            var bootcamps = await _bootcampService.GetAllAsync();
            return Ok(bootcamps);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BootcampReadDTO>> GetById(long id)
        {
            var bootcamp = await _bootcampService.GetByIdAsync(id);
            if (bootcamp == null) return NotFound();
            return Ok(bootcamp);
        }

        [HttpPost]
        public async Task<ActionResult<BootcampReadDTO>> Create([FromBody] BootcampCreateDTO dto)
        {
            await _bootcampService.CreateAsync(dto);
            // Puedes devolver el bootcamp creado si tu servicio lo retorna, aquí solo devuelvo el DTO recibido
            return CreatedAtAction(nameof(GetById), new { id = dto.Name }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, BootcampCreateDTO bootcampDto)
        {
            var bootcamp = await _bootcampService.UpdateAsync(id, bootcampDto);
            if (bootcamp == null) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _bootcampService.DeleteAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}