using System;

namespace DPA.Ecommerce.CORE.Core.DTOs
{
    public class SignUpDTO
    {
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public string? Country { get; set; }
        public string? Address { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Type { get; set; }
    }
}
