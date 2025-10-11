using DPA.Ecommerce.CORE.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DPA.Ecommerce.CORE.Core.Interfaces;

public interface IFavoriteService
{
    Task<FavoriteListResponseDTO> GetAllFavoritesAsync();
    Task AddAsync(FavoriteDTO favoriteDto);
    Task UpdateAsync(FavoriteDTO favoriteDto);
}
