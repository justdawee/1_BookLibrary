using AutoMapper;
using BookLibrary.Api.DTOs;
using BookLibrary.Core.Entities;
using BookLibrary.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController(BookLibraryDbContext context, IMapper mapper) : ControllerBase
{
    //GET api/categories
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAll()
    {
        var categories = await context.Categories.ToListAsync();
        return Ok(mapper.Map<IEnumerable<CategoryDto>>(categories));
    }
    
    //GET api/categories/5
    [HttpGet("{id}")]
    public async Task<ActionResult<CategoryDto>> GetById(int id)
    {
        var category = await context.Categories.FindAsync(id);
        if (category == null)
            return NotFound();
        return Ok(mapper.Map<CategoryDto>(category));
    }
    
    //POST api/categories
    [HttpPost]
    public async Task<ActionResult<CategoryDto>> Create(CreateCategoryDto createDto)
    {
        var category = mapper.Map<Category>(createDto);
        context.Categories.Add(category);
        await context.SaveChangesAsync();

        var categoryDto = mapper.Map<CategoryDto>(category);
        return CreatedAtAction(nameof(GetById), new { id = category.Id }, categoryDto);
    }
    
    //PUT api/categories/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateCategoryDto updateDto)
    {
        var category = await context.Categories.FindAsync(id);
        if (category == null)
            return NotFound();
        mapper.Map(updateDto, category);
        await context.SaveChangesAsync();
        return NoContent();
    }
    
    //DELETE api/categories/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var category = await context.Categories.FindAsync(id);
        if (category == null)
            return NotFound();
        context.Categories.Remove(category);
        await context.SaveChangesAsync();
        return NoContent();   
    }
}