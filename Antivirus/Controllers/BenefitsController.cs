using Microsoft.AspNetCore.Mvc;
using Antivirus.Models;
using Antivirus.Services;
using Antivirus.config;
using Antivirus.DTOs;

namespace Antivirus.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BenefitsController : ControllerBase
    {
        private readonly IBenefitService _benefitService;

        public BenefitsController(IBenefitService benefitService)
        {
            _benefitService = benefitService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var benefits = await _benefitService.GetAllAsync();
            return Ok(benefits);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var benefit = await _benefitService.GetByIdAsync(id);
            if (benefit == null) return NotFound(new { message = "Beneficio no encontrado." });
            return Ok(benefit);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BenefitsCreateDTO dto)
        {
            // El ID se asigna automáticamente en la base de datos
            var benefit = await _benefitService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = benefit.Id }, benefit);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] BenefitsCreateDTO dto)
        {
            // Ignorar cualquier intento de modificar el ID
            var benefit = await _benefitService.UpdateAsync(id, dto);
            if (benefit == null) return NotFound(new { message = "Beneficio no encontrado." });
            return Ok(benefit);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deleted = await _benefitService.DeleteAsync(id);
            if (!deleted) return NotFound(new { message = "Beneficio no encontrado." });
            return NoContent();
        }
    }
}