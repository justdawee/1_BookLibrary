namespace BookLibrary.Api.DTOs;

public class BookDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime PublishDate { get; set; }
}