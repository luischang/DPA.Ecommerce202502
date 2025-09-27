using DPA.Ecommerce.CORE.Core.Entities;
using DPA.Ecommerce.CORE.Core.Interfaces;
using DPA.Ecommerce.CORE.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA.Ecommerce.CORE.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly StoreDbueContext _context;

        public CategoryRepository(StoreDbueContext context)
        {
            _context = context;
        }


        public IEnumerable<Category> GetAll()
        {
            //var context = new StoreDbueContext();
            var categories = _context.Category.ToList();
            return categories;
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            //var context = new StoreDbueContext();
            var categories = await _context.Category.ToListAsync();
            return categories;
        }

        public async Task<Category> GetCategoryById(int id)
        {
            var category = await _context
                                .Category
                                .Where(c => c.Id == id).FirstOrDefaultAsync();
            return category;
        }

        public async Task<int> Create(Category category)
        {
            await _context.Category.AddAsync(category);
            await _context.SaveChangesAsync();

            return category.Id;
        }



    }
}
