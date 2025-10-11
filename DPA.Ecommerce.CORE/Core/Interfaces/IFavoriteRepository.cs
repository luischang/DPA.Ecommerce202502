using DPA.Ecommerce.CORE.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DPA.Ecommerce.CORE.Core.Interfaces;

public interface IFavoriteRepository
{
    Task<IEnumerable<Favorite>> GetAllAsync();
    Task<Favorite?> GetByIdAsync(int id);
    Task AddAsync(Favorite favorite);
    Task UpdateAsync(Favorite favorite);
}
