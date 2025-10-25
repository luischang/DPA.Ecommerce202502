using DPA.Ecommerce.CORE.Core.DTOs;
using System.Threading.Tasks;

namespace DPA.Ecommerce.CORE.Core.Interfaces
{
    public interface IUserService
    {
        Task<UserResponseDTO?> SignInAsync(SignInDTO dto);
        Task<int> SignUpAsync(SignUpDTO dto);
    }
}
