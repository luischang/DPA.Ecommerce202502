using DPA.Ecommerce.CORE.Core.Entities;
using DPA.Ecommerce.CORE.Core.Interfaces;
using DPA.Ecommerce.CORE.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DPA.Ecommerce.CORE.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly StoreDbueContext _context;

    public ProductRepository(StoreDbueContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _context
                    .Product
                    .Include(p => p.Category)
                    .ToListAsync();
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        return await _context.Product.FindAsync(id);
    }

    public async Task AddAsync(Product product)
    {
        _context.Product.Add(product);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Product product)
    {
        _context.Product.Update(product);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var product = await _context.Product.FindAsync(id);
        if (product != null)
        {
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}
