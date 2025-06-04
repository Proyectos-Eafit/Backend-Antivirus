using Microsoft.AspNetCore.Mvc;
using Antivirus.Models;
using Antivirus.Services;
using Antivirus.DTOs;
using System.Security.Cryptography;
using System.Text;
using Antivirus.config;
using Antivirus.Data;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace Antivirus.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly AuthService _authService;

        public AuthController(AppDbContext context, AuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterDTO registerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Verificar si el correo ya está registrado
            var existingUser = _context.Users.FirstOrDefault(u => u.Email == registerDto.Email);
            if (existingUser != null)
            {
                return BadRequest(new { message = "El correo electrónico ya está registrado." });
            }

            // Verificar si ya existe un administrador registrado
            var existingAdmin = _context.UserRoles.FirstOrDefault(ur => ur.RoleId == 2);
            if (existingAdmin != null)
            {
                return BadRequest(new { message = "Ya existe un administrador registrado." });
            }

            // Mapear el DTO a la entidad User (solo email y password)
            var user = new User
            {
                Email = registerDto.Email,
                Password = PasswordHasher.HashPassword(registerDto.Password)
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            // Asignar el rol "admin" automáticamente (rol con ID 2)
            var adminRole = _context.Roles.FirstOrDefault(r => r.Id == 2);
            if (adminRole != null)
            {
                var userRole = new UserRole
                {
                    UserId = user.Id,
                    RoleId = adminRole.Id
                };

                _context.UserRoles.Add(userRole);
                _context.SaveChanges();
            }

            return Ok(new { message = "Administrador registrado exitosamente." });
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginUserDto loginDto)
        {
            // Buscar el usuario por correo electrónico
            var existingUser = _context.Users.FirstOrDefault(u => u.Email == loginDto.Email);

            if (existingUser == null)
            {
                return Unauthorized(new { message = "Usuario no encontrado." });
            }

            // Verificar la contraseña encriptada
            string hashedPassword = PasswordHasher.HashPassword(loginDto.Password);

            if (existingUser.Password != hashedPassword)
            {
                return Unauthorized(new { message = "Contraseña incorrecta." });
            }

            // Obtener el rol del usuario
            var userRole = _context.UserRoles
                .Where(ur => ur.UserId == existingUser.Id)
                .Join(_context.Roles, ur => ur.RoleId, r => r.Id, (ur, r) => r.Name)
                .FirstOrDefault();

            if (userRole == null)
            {
                return Unauthorized(new { message = "El usuario no tiene un rol asignado." });
            }

            // Generar el token JWT
            var token = _authService.GenerateJwtToken(existingUser);

            // Configurar el token como una cookie HTTP-only
            Response.Cookies.Append("token", token, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Lax,
                Path = "/",
            });

            // Retornar el token y el rol en el cuerpo de la respuesta
            return Ok(new
            {
                message = "Inicio de sesión exitoso.",
                token = token,
                role = userRole
            });
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            // Eliminar la cookie del token
            Response.Cookies.Delete("token");

            return Ok(new { message = "Sesión cerrada exitosamente." });
        }
    }
}