using DPA.Ecommerce.CORE.Core.Entities;
using DPA.Ecommerce.CORE.Core.Interfaces;
using DPA.Ecommerce.CORE.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DPA.Ecommerce.CORE.Infrastructure.Repositories;

public class FavoriteRepository : IFavoriteRepository
{
    private readonly StoreDbueContext _context;

    public FavoriteRepository(StoreDbueContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Favorite>> GetAllAsync()
    {
        return await _context.Favorite
            .Include(f => f.User)
            .Include(f => f.Product)
            .ToListAsync();
    }

    public async Task<Favorite?> GetByIdAsync(int id)
    {
        return await _context.Favorite
            .Include(f => f.User)
            .Include(f => f.Product)
            .FirstOrDefaultAsync(f => f.Id == id);
    }

    public async Task AddAsync(Favorite favorite)
    {
        _context.Favorite.Add(favorite);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Favorite favorite)
    {
        _context.Favorite.Update(favorite);
        await _context.SaveChangesAsync();
    }
}
