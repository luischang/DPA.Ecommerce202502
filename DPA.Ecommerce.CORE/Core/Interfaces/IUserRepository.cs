using DPA.Ecommerce.CORE.Core.Entities;
using System.Threading.Tasks;

namespace DPA.Ecommerce.CORE.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAsync(string email);
        Task<int> CreateAsync(User user);
    }
}
