using DPA.Ecommerce.CORE.Core.DTOs;
using DPA.Ecommerce.CORE.Core.Entities;
using DPA.Ecommerce.CORE.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DPA.Ecommerce.CORE.Core.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<IEnumerable<ProductDTO>> GetAllAsync()
    {
        var products = await _productRepository.GetAllAsync();
        return products.Select(p => new ProductDTO
        {
            Id = p.Id,
            Description = p.Description,
            ImageUrl = p.ImageUrl,
            Stock = p.Stock,
            Price = p.Price,
            Discount = p.Discount,
            Category = p.Category == null ? null : new CategoryListDTO
            {
                Id = p.Category.Id,
                Description = p.Category.Description
            },
            IsActive = p.IsActive
        });
    }

    public async Task<ProductDTO?> GetByIdAsync(int id)
    {
        var p = await _productRepository.GetByIdAsync(id);
        if (p == null) return null;
        return new ProductDTO
        {
            Id = p.Id,
            Description = p.Description,
            ImageUrl = p.ImageUrl,
            Stock = p.Stock,
            Price = p.Price,
            Discount = p.Discount,
            Category = p.Category == null ? null : new CategoryListDTO
            {
                Id = p.Category.Id,
                Description = p.Category.Description
            },
            IsActive = p.IsActive
        };
    }

    public async Task AddAsync(ProductDTO productDto)
    {
        var product = new Product
        {
            Description = productDto.Description,
            ImageUrl = productDto.ImageUrl,
            Stock = productDto.Stock,
            Price = productDto.Price,
            Discount = productDto.Discount,
            CategoryId = productDto.Category?.Id,
            IsActive = productDto.IsActive
        };
        await _productRepository.AddAsync(product);
    }

    public async Task UpdateAsync(ProductDTO productDto)
    {
        var product = new Product
        {
            Id = productDto.Id,
            Description = productDto.Description,
            ImageUrl = productDto.ImageUrl,
            Stock = productDto.Stock,
            Price = productDto.Price,
            Discount = productDto.Discount,
            CategoryId = productDto.Category?.Id,
            IsActive = productDto.IsActive
        };
        await _productRepository.UpdateAsync(product);
    }

    public async Task DeleteAsync(int id)
    {
        await _productRepository.DeleteAsync(id);
    }
}
