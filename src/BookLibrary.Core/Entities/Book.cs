namespace BookLibrary.Core.Entities;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime PublishDate { get; set; }
    public int AuthorId { get; set; }
    public Author Author { get; set; } = null!;
    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;
    
}