using AutoMapper;
using BookLibrary.Api.DTOs;
using BookLibrary.Core.Entities;
using BookLibrary.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Api.Controllers;

[ApiController]
[Route("api/[controller]")]

public class BookController(BookLibraryDbContext context, IMapper mapper) : ControllerBase
{
    //GET api/books
    [HttpGet]
    public async Task<ActionResult<IEnumerable<BookDto>>> GetAll()
    {
        var books = await context.Books.ToListAsync();
        return Ok(mapper.Map<IEnumerable<BookDto>>(books));
    }
    
    //GET api/books/5
    [HttpGet("{id}")]
    public async Task<ActionResult<BookDto>> GetById(int id)
    {
        var book = await context.Books.FindAsync(id);
        if (book == null)
            return NotFound();
        return Ok(mapper.Map<BookDto>(book));
    }
    
    //POST api/books
    [HttpPost]
    public async Task<ActionResult<BookDto>> Create(CreateBookDto createDto)
    {
        var author = await context.Authors.FindAsync(createDto.AuthorId);
        if (author == null)
            return NotFound($"Author with ID {createDto.AuthorId} not found.");

        var category = await context.Categories.FindAsync(createDto.CategoryId);
        if (category == null)
            return NotFound($"Category with ID {createDto.CategoryId} not found.");
        
        var book = mapper.Map<Book>(createDto);
        context.Books.Add(book);
        await context.SaveChangesAsync();

        var bookDto = mapper.Map<BookDto>(book);
        return CreatedAtAction(nameof(GetById), new { id = book.Id }, bookDto);
    }
    
    //PUT api/books/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateBookDto updateDto)
    {
        var book = await context.Books.FindAsync(id);
        if (book == null)
            return NotFound();
        mapper.Map(updateDto, book);
        await context.SaveChangesAsync();
        return NoContent();
    }
    
    //DELETE api/books/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var book = await context.Books.FindAsync(id);
        if (book == null)
            return NotFound();
        context.Books.Remove(book);
        await context.SaveChangesAsync();
        return NoContent();   
    }
}