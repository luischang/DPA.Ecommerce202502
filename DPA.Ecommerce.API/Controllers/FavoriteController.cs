using DPA.Ecommerce.CORE.Core.DTOs;
using DPA.Ecommerce.CORE.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DPA.Ecommerce.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FavoriteController : ControllerBase
{
    private readonly IFavoriteService _favoriteService;

    public FavoriteController(IFavoriteService favoriteService)
    {
        _favoriteService = favoriteService;
    }

    [HttpGet]
    public async Task<ActionResult<FavoriteListResponseDTO>> GetAllFavorites()
    {
        var result = await _favoriteService.GetAllFavoritesAsync();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Insert([FromBody] FavoriteDTO favoriteDto)
    {
        await _favoriteService.AddAsync(favoriteDto);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] FavoriteDTO favoriteDto)
    {
        await _favoriteService.UpdateAsync(favoriteDto);
        return Ok();
    }
}
