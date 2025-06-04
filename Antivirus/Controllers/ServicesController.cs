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
    public class ServicesController : ControllerBase
    {
        private readonly IServiceService _service;

        public ServicesController(IServiceService service)
        {
            _service = service;
        }

        // GET: api/Services
        [HttpGet]
        [AllowAnonymous] 
        public async Task<ActionResult<IEnumerable<ServiceReadDTO>>> GetAll()
        {
            var services = await _service.GetAllAsync();
            return Ok(services);
        }

        // GET: api/Services/{id}
        [HttpGet("{id}")]
        [AllowAnonymous] 
        public async Task<ActionResult<ServiceReadDTO>> GetById(long id)
        {
            var service = await _service.GetByIdAsync(id);
            if (service == null) return NotFound();
            return Ok(service);
        }

        // POST: api/Services
        [HttpPost]
        public async Task<ActionResult<ServiceReadDTO>> Create(ServiceCreateDTO dto)
        {
            var createdService = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = createdService.Id }, createdService);
        }

        // PUT: api/Services/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceReadDTO>> Update(long id, ServiceCreateDTO dto)
        {
            var updatedService = await _service.UpdateAsync(id, dto);
            if (updatedService == null) return NotFound();
            return Ok(updatedService);
        }

        // DELETE: api/Services/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}