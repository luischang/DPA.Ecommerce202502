using DPA.Ecommerce.CORE.Core.DTOs;
using DPA.Ecommerce.CORE.Core.Entities;
using DPA.Ecommerce.CORE.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DPA.Ecommerce.CORE.Core.Services;

public class FavoriteService : IFavoriteService
{
    private readonly IFavoriteRepository _favoriteRepository;

    public FavoriteService(IFavoriteRepository favoriteRepository)
    {
        _favoriteRepository = favoriteRepository;
    }

    public async Task<FavoriteListResponseDTO> GetAllFavoritesAsync()
    {
        var favorites = await _favoriteRepository.GetAllAsync();
        var grouped = favorites
            .Where(f => f.User != null && f.Product != null)
            .GroupBy(f => f.UserId)
            .Select(g => new FavoriteUserDTO
            {
                UserId = g.Key ?? 0,
                FullName = g.First().User!.FirstName + " " + g.First().User!.LastName,
                Products = g.Select(f => new FavoriteProductDTO
                {
                    ProductId = f.ProductId ?? 0,
                    Description = f.Product!.Description
                }).ToList()
            }).ToList();
        return new FavoriteListResponseDTO { Favorites = grouped };
    }

    public async Task AddAsync(FavoriteDTO favoriteDto)
    {
        var favorite = new Favorite
        {
            UserId = favoriteDto.UserId,
            ProductId = favoriteDto.ProductId,
            CreatedAt = favoriteDto.CreatedAt
        };
        await _favoriteRepository.AddAsync(favorite);
    }

    public async Task UpdateAsync(FavoriteDTO favoriteDto)
    {
        var favorite = await _favoriteRepository.GetByIdAsync(favoriteDto.Id);
        if (favorite != null)
        {
            favorite.UserId = favoriteDto.UserId;
            favorite.ProductId = favoriteDto.ProductId;
            favorite.CreatedAt = favoriteDto.CreatedAt;
            await _favoriteRepository.UpdateAsync(favorite);
        }
    }
}
