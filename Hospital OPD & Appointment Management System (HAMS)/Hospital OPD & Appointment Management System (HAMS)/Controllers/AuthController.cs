using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Hospital_OPD___Appointment_Management_System__HAMS_.Data;
using Hospital_OPD___Appointment_Management_System__HAMS_.Modal.Dto.UserDtos;
using Hospital_OPD___Appointment_Management_System__HAMS_.Modal.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Hospital_OPD___Appointment_Management_System__HAMS_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly ApplicationDBcontext _context;
        private readonly IConfiguration _configure;

        public AuthController(ApplicationDBcontext context, IConfiguration configure)
        {
            _context = context;
            _configure = configure;
        }


        //Register the User
        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserRegistrationDto dto)
        {
            var user = new User
            {
                Username = dto.Username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                Role = dto.Role
            };

            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();

            return Ok("User Profile Created");
        }

        //User Login
        [HttpPost("Login")]
        public async Task<IActionResult> Login (UserLoginDto dto)
        {
            var user = await _context.User.FirstOrDefaultAsync(x => x.Username == dto.Username);
            if (user == null || BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
            {
                return Unauthorized();
            }

            var token = GenerateJwtToken(user);
            return Ok(new { Token = token });
        }

        private string GenerateJwtToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configure["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(8),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
