using System.Collections.Generic;

namespace DPA.Ecommerce.CORE.Core.DTOs;

public class FavoriteListResponseDTO
{
    public List<FavoriteUserDTO> Favorites { get; set; } = new();
}
