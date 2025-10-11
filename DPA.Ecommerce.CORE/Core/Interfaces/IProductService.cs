using DPA.Ecommerce.CORE.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DPA.Ecommerce.CORE.Core.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductDTO>> GetAllAsync();
    Task<ProductDTO?> GetByIdAsync(int id);
    Task AddAsync(ProductDTO productDto);
    Task UpdateAsync(ProductDTO productDto);
    Task DeleteAsync(int id);
}
