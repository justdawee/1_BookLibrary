using AutoMapper;
using BookLibrary.Api.DTOs;
using BookLibrary.Core.Entities;
using BookLibrary.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorController(BookLibraryDbContext context, IMapper mapper) : ControllerBase
{
    //GET api/Author
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AuthorDto>>> GetAll()
    {
        var authors = await context.Authors.ToListAsync();
        return Ok(mapper.Map<IEnumerable<AuthorDto>>(authors));
    }

    //GET api/Author/5
    [HttpGet("{id}")]
    public async Task<ActionResult<AuthorDto>> GetById(int id)
    {
        var author = await context.Authors.FindAsync(id);
        if (author == null)
            return NotFound();

        return Ok(mapper.Map<AuthorDto>(author));
    }

    //POST api/authors
    [HttpPost]
    public async Task<ActionResult<AuthorDto>> Create(CreateAuthorDto createDto)
    {
        var author = mapper.Map<Author>(createDto);
        context.Authors.Add(author);
        await context.SaveChangesAsync();

        var authorDto = mapper.Map<AuthorDto>(author);
        return CreatedAtAction(nameof(GetById), new { id = author.Id }, authorDto);
    }

    //PUT api/authors/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateAuthorDto updateDto)
    {
        var author = await context.Authors.FindAsync(id);
        if (author == null)
            return NotFound();
        mapper.Map(updateDto, author);
        await context.SaveChangesAsync();
        return NoContent();
    }

    //DELETE api/authors/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var author = await context.Authors.FindAsync(id);
        if (author == null)
            return NotFound();
        context.Authors.Remove(author);
        await context.SaveChangesAsync();
        return NoContent();
    }
}