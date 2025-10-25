using DPA.Ecommerce.CORE.Core.DTOs;
using DPA.Ecommerce.CORE.Core.Entities;
using DPA.Ecommerce.CORE.Core.Interfaces;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DPA.Ecommerce.CORE.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJWTService _jwtService;

		public UserService(IUserRepository userRepository, IJWTService jwtService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
        }

        public async Task<UserResponseDTO?> SignInAsync(SignInDTO dto)
        {
            var user = await _userRepository.GetByEmailAsync(dto.Email);
            if (user == null) return null;

            var hashed = HashPassword(dto.Password);
            if (user.Password != hashed) return null;

            var token = _jwtService.GenerateJWToken(user); // Aquí se generaría un token JWT real

			return new UserResponseDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                IsActive = user.IsActive,
                Type = user.Type,
                Token = token
			};
        }

        public async Task<int> SignUpAsync(SignUpDTO dto)
        {
            var existing = await _userRepository.GetByEmailAsync(dto.Email);
            if (existing != null)
            {
                return 0;
            }

            var user = new User
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                DateOfBirth = dto.DateOfBirth,
                Country = dto.Country,
                Address = dto.Address,
                Email = dto.Email,
                Password = HashPassword(dto.Password),
                IsActive = true,
                Type = dto.Type
            };

            var id = await _userRepository.CreateAsync(user);
            return id;
        }

        private static string HashPassword(string password)
        {
            if (password == null) return string.Empty;
            using var sha = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha.ComputeHash(bytes);
            var sb = new StringBuilder();
            foreach (var b in hash) sb.Append(b.ToString("x2"));
            return sb.ToString();
        }
    }
}
