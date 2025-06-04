using Antivirus.DTOs;
using Antivirus.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Antivirus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // Obtener todos los usuarios (sin autorización)
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        // Obtener un usuario por ID (requiere autorización)
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(long id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null) return NotFound(new { message = "Usuario no encontrado." });
            return Ok(user);
        }

        // Crear un nuevo usuario (sin autorización)
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UsersCreateDTO userDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var createdUser = await _userService.CreateUserAsync(userDto);
            return CreatedAtAction(nameof(GetUserById), new { id = createdUser.Id }, createdUser);
        }

        // Actualizar un usuario existente (requiere autorización)
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(long id, [FromBody] UsersCreateDTO userDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var updatedUser = await _userService.UpdateUserAsync(id, userDto);
            if (updatedUser == null) return NotFound(new { message = "Usuario no encontrado." });
            return Ok(updatedUser);
        }

        // Eliminar un usuario por ID (requiere autorización)
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(long id)
        {
            var result = await _userService.DeleteUserAsync(id);
            if (!result) return NotFound(new { message = "Usuario no encontrado." });
            return NoContent();
        }
    }
}