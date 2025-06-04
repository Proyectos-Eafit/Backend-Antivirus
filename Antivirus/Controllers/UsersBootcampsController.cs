using Microsoft.AspNetCore.Mvc;
using Antivirus.DTOs;
using Antivirus.Services;
using Microsoft.AspNetCore.Authorization;

namespace Antivirus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersBootcampsController : ControllerBase
    {
        private readonly IUserBootcampService _userBootcampService;

        public UsersBootcampsController(IUserBootcampService userBootcampService)
        {
            _userBootcampService = userBootcampService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsersBootcampsReadDTO>>> GetAll()
        {
            return Ok(await _userBootcampService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsersBootcampsReadDTO>> GetById(long id)
        {
            var userBootcamp = await _userBootcampService.GetByIdAsync(id);
            if (userBootcamp == null)
                return NotFound();

            return Ok(userBootcamp);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] UsersBootcampsCreateDTO dto)
        {
            var createdEntity = await _userBootcampService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = createdEntity.Id }, createdEntity);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(long id, [FromBody] UsersBootcampsCreateDTO dto)
        {
            bool updated = await _userBootcampService.UpdateAsync(id, dto);
            if (!updated)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            bool deleted = await _userBootcampService.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}