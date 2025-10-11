using DPA.Ecommerce.CORE.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DPA.Ecommerce.CORE.Core.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(int id);
    Task AddAsync(Product product);
    Task UpdateAsync(Product product);
    Task DeleteAsync(int id);
}
