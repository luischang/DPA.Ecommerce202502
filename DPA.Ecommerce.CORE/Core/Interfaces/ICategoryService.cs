using DPA.Ecommerce.CORE.Core.DTOs;

namespace DPA.Ecommerce.CORE.Core.Interfaces
{
    public interface ICategoryService
    {
        Task<int> Create(CategoryCreateDTO categoryCreateDTO);
        Task<IEnumerable<CategoryListDTO>> GetCategories();
        Task<CategoryListDTO> GetCategoryById(int id);
    }
}