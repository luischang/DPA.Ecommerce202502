using DPA.Ecommerce.CORE.Core.DTOs;
using DPA.Ecommerce.CORE.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DPA.Ecommerce.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("signin")]
        public async Task<IActionResult> SignIn([FromBody] SignInDTO dto)
        {
            if (dto == null || string.IsNullOrWhiteSpace(dto.Email) || string.IsNullOrWhiteSpace(dto.Password))
                return BadRequest("Email y Password son obligatorios.");

            var user = await _userService.SignInAsync(dto);
            if (user == null) return Unauthorized();

            return Ok(user);
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] SignUpDTO dto)
        {
            if (dto == null || string.IsNullOrWhiteSpace(dto.Email) || string.IsNullOrWhiteSpace(dto.Password) || string.IsNullOrWhiteSpace(dto.FirstName))
                return BadRequest("FirstName, Email y Password son obligatorios.");

            var id = await _userService.SignUpAsync(dto);
            if (id == 0) return Conflict("El email ya está registrado.");

            return CreatedAtAction(null, new { id }, dto);
        }
    }
}
