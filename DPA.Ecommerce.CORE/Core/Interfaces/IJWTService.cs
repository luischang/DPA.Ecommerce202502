using DPA.Ecommerce.CORE.Core.Entities;
using DPA.Ecommerce.CORE.Core.Settings;

namespace DPA.Ecommerce.CORE.Core.Interfaces
{
    public interface IJWTService
    {
        JWTSettings _settings { get; }

        string GenerateJWToken(User user);
    }
}