using System.Collections.Generic;

namespace DPA.Ecommerce.CORE.Core.DTOs;

public class FavoriteUserDTO
{
    public int UserId { get; set; }
    public string? FullName { get; set; }
    public List<FavoriteProductDTO> Products { get; set; } = new();
}
