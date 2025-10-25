namespace DPA.Ecommerce.CORE.Core.DTOs
{
    public class UserResponseDTO
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public bool? IsActive { get; set; }
        public string? Type { get; set; }
        public string? Token { get; set; }
	}
}
