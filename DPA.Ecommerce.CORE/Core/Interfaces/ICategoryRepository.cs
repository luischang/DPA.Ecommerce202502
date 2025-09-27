using DPA.Ecommerce.CORE.Core.Entities;

namespace DPA.Ecommerce.CORE.Core.Interfaces
{
    public interface ICategoryRepository
    {
        Task<int> Create(Category category);
        IEnumerable<Category> GetAll();
        Task<IEnumerable<Category>> GetCategories();
        Task<Category> GetCategoryById(int id);
    }
}