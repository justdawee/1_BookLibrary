using BookLibrary.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Infrastructure;

public class BookLibraryDbContext(DbContextOptions<BookLibraryDbContext> options) : DbContext(options)
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Category> Categories { get; set; }
}