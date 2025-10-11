using DPA.Ecommerce.CORE.Core.DTOs;
using DPA.Ecommerce.CORE.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DPA.Ecommerce.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAll()
    {
        var products = await _productService.GetAllAsync();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDTO>> GetById(int id)
    {
        var product = await _productService.GetByIdAsync(id);
        if (product == null) return NotFound();
        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> Add(ProductDTO productDto)
    {
        await _productService.AddAsync(productDto);
        return CreatedAtAction(nameof(GetById), new { id = productDto.Id }, productDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, ProductDTO productDto)
    {
        if (id != productDto.Id) return BadRequest();
        await _productService.UpdateAsync(productDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _productService.DeleteAsync(id);
        return NoContent();
    }
}
