using Microsoft.AspNetCore.Mvc;
using Antivirus.DTOs;
using Antivirus.Services;
using Microsoft.AspNetCore.Authorization;

namespace Antivirus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRolesController : ControllerBase
    {
        private readonly UserRoleService _userRolesService;

        public UserRolesController(UserRoleService userRolesService)
        {
            _userRolesService = userRolesService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserRolesReadDTO>>> GetAll()
        {
            return Ok(await _userRolesService.GetAllAsync());
        }

        [HttpGet("{userId}/{roleId}")]
        public async Task<ActionResult<UserRolesReadDTO>> Get(long userId, long roleId)
        {
            var userRole = await _userRolesService.GetByIdAsync(userId, roleId);
            if (userRole == null)
                return NotFound(new { message = "La relación usuario-rol no existe." });
            return Ok(userRole);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] UserRolesCreateDTO dto)
        {
            await _userRolesService.CreateAsync(dto);
            return CreatedAtAction(nameof(Get), new { userId = dto.UserId, roleId = dto.RoleId }, dto);
        }

        [Authorize]
        [HttpPut("{userId}/{roleId}")]
        public async Task<ActionResult> Update(long userId, long roleId, [FromBody] UserRolesCreateDTO dto)
        {
            var existingUserRole = await _userRolesService.GetByIdAsync(userId, roleId);
            if (existingUserRole == null)
                return NotFound(new { message = "La relación usuario-rol no existe." });

            await _userRolesService.UpdateAsync(userId, roleId, dto);
            return NoContent();
        }

        [Authorize]
        [HttpDelete("{userId}/{roleId}")]
        public async Task<ActionResult> Delete(long userId, long roleId)
        {
            // Verificar si el rol tiene usuarios asignados
            var hasUsersAssigned = await _userRolesService.HasUsersAssignedAsync(roleId);
            if (hasUsersAssigned)
                return BadRequest(new { message = "El rol no puede ser eliminado porque tiene usuarios asignados." });

            var existingUserRole = await _userRolesService.GetByIdAsync(userId, roleId);
            if (existingUserRole == null)
                return NotFound(new { message = "La relación usuario-rol no existe." });

            await _userRolesService.DeleteAsync(userId, roleId);
            return NoContent();
        }
    }
}