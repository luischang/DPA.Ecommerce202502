using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DPA.Ecommerce.CORE.Core.DTOs;
using DPA.Ecommerce.CORE.Core.Entities;
using DPA.Ecommerce.CORE.Core.Interfaces;

namespace DPA.Ecommerce.CORE.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<CategoryListDTO>> GetCategories()
        {
            var categories = await _categoryRepository.GetCategories();
            var categoriesDTO = new List<CategoryListDTO>();

            foreach (var category in categories)
            {
                var categoryDTO = new CategoryListDTO();
                categoryDTO.Id = category.Id;
                categoryDTO.Description = category.Description;

                categoriesDTO.Add(categoryDTO);
            }
            return categoriesDTO;
        }

        public async Task<CategoryListDTO> GetCategoryById(int id)
        {
            var category = await _categoryRepository.GetCategoryById(id);
            if (category == null)
            {
                return null;
            }
            var categoryDTO = new CategoryListDTO
            {
                Id = category.Id,
                Description = category.Description
            };
            return categoryDTO;
        }

        public async Task<int> Create(CategoryCreateDTO categoryCreateDTO)
        {
            var category = new Category();
            category.Description = categoryCreateDTO.Description;
            category.IsActive = true;// Default value for new categories

            var createdCategoryId = await _categoryRepository.Create(category);
            return createdCategoryId;
        }
    }
}
